#define DEBUG1
#define NotLicensed1

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace NvnInstaller.MsiDotNet {
    public class MsiInstaller {
        private Thread installThread;
        private string msiFile;
        private List<MsiFeature> features = new List<MsiFeature>();
        private List<MsiFeature> featureTree = new List<MsiFeature>();
        private string installDir = string.Empty;
        private MsiResponse userAction = 0;
        private bool userActed = false;
        private Guid[] productIds;

#if DEBUG
        public event EventHandler<LogMessage> MessageLogged;
#endif
        /// <summary>Messages received from Windows Installer which can be used in .Net user interface.</summary>
        public event EventHandler<InstallerMessageEventArgs> InstallerMessageReceived;

        /// <summary>List of root feature nodes. Child nodes of each feature can be used to construct complete feature tree.</summary>
        public List<MsiFeature> FeatureTree { get { return featureTree; } }
        /// <summary>True if the MSI file is already installed on local machine.</summary>
        public bool IsAlreadyInstalled { get { return !(productIds == null || productIds.Length == 0); } }

        /// <summary>Specify the location of directory where MSI package to be installed.</summary>
        public string InstallDirectory {
            get { return installDir; }
            set { installDir = value; }
        }

        private MsiInstaller() { }

        /// <summary>
        /// <param name="msiFile">Complete file path of MSI file.</param>
        /// <exception cref="FileNotFoundException">If the given MSI file not found.</exception>
        /// </summary>
        public MsiInstaller(string msiFile):this() {
            msiFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + Path.GetFileName(msiFile);
            if (File.Exists(msiFile) == false) {
                throw new FileNotFoundException(msiFile + " not found!");
            }

            this.msiFile = msiFile;

            LoadFeatures();

            CheckInstalled();

            GetInstalledFeatures();
        }


        #region Check Software Installed
        private void CheckInstalled() {
            //1. Get upgrade code
            string upgradeCode = string.Empty;
            using (MsiConnection conn = new MsiConnection(msiFile)) {
                conn.Open();

                using (MsiCommand cmd = new MsiCommand("SELECT Property, Value FROM Property WHERE Property='UpgradeCode'", conn)) {
                    using (MsiDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            upgradeCode = reader.GetString(1);
                        }
                    }
                }
            }
            //2. Check any software is already installed  
            productIds = EnumRelatedProducts(upgradeCode);
        }

        private void GetInstalledFeatures() {
            //1. Get product code
            string productCode = string.Empty;
            using (MsiConnection conn = new MsiConnection(msiFile)) {
                conn.Open();

                using (MsiCommand cmd = new MsiCommand("SELECT Property, Value FROM Property WHERE Property='ProductCode'", conn)) {
                    using (MsiDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            productCode = reader.GetString(1);
                        }
                    }
                }
            }
            //2. get all features
            EnumRelatedFeatures(productCode);
        }

        private Guid[] EnumRelatedProducts(string UpgradeCode) {
            Guid[] guids = new Guid[0];

            MsiError ret;
            uint i = 0;
            StringBuilder buffer = new StringBuilder(38);
            while ((ret = MsiInterop.MsiEnumRelatedProducts(UpgradeCode, 0, i, buffer)) == 0) {
                Guid[] temp = new Guid[i + 1];
                Array.Copy(guids, temp, i);
                temp[i] = new Guid(buffer.ToString());
                guids = temp;
                i++;
            }

            return guids;
        }

        private void EnumRelatedFeatures(string productcode) {
            MsiError ret;
            StringBuilder featureParent = new StringBuilder(64);
            StringBuilder feature = new StringBuilder(64);
            uint i = 0;
            while ((ret = MsiInterop.MsiEnumFeatures(productcode, i, feature, featureParent)) == 0) {
                MsiInstallState installState = MsiInterop.MsiQueryFeatureState(productcode, feature.ToString());
                if (installState == MsiInstallState.Local) {
                    foreach (MsiFeature msiFeature in features) {
                        if (msiFeature.Id == feature.ToString()) msiFeature.SetIsAlreadyInstalled(true);
                    }
                }
                i++;
            }
        }

        #endregion

        #region Load Features and Install Directory
        private void LoadFeatures() {
            using (MsiConnection conn = new MsiConnection(msiFile)) {
                conn.Open();

                // GET ALL FEATURES
                features.Clear();
                Dictionary<string, MsiFeature> dicFeatures = new Dictionary<string, MsiFeature>();
                using (MsiCommand cmd = new MsiCommand("SELECT Feature, Feature_Parent, Title, Description, Display, Directory_ FROM Feature", conn)) {
                    using (MsiDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            MsiFeature feature = new MsiFeature();
                            feature.SetId(reader.GetString(0));
                            feature.ParentId = reader.GetString(1);
                            feature.SetTitle(reader.GetString(2));
                            feature.SetDescription(reader.GetString(3));
                            feature.SetDisplay(reader.GetInteger(4));
                            feature.SetDirectory(reader.GetString(5));

                            dicFeatures.Add(feature.Id, feature);
                            features.Add(feature);
                        }
                    }
                }

                // CREATE FEATURE TREE
                // 1. Set all feature parent and child nodes
                foreach (MsiFeature feature in features) {
                    if (String.IsNullOrEmpty(feature.ParentId) == false) {
                        feature.SetParent(dicFeatures[feature.ParentId]);
                        if (feature.ParentFeature.ChildFeatures == null) {
                            feature.ParentFeature.SetChildFeature(new List<MsiFeature>());
                        }

                        feature.ParentFeature.ChildFeatures.Add(feature);
                    }
                }
                // 2. Get only root nodes
                featureTree.Clear();
                foreach (MsiFeature feature in features) {
                    if (feature.ParentFeature == null) {
                        featureTree.Add(feature);
                    }
                }

                // SET INSTALLDIR
                using (MsiCommand cmd = new MsiCommand("SELECT Value FROM Property WHERE Property='INSTALLDIR'", conn)) {
                    using (MsiDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            installDir = reader.GetString(0);
                        }
                    }
                }

                // CALCULATE FEATURE COST
                // 1. Get all components
                Dictionary<string, MsiComponent> files = new Dictionary<string, MsiComponent>();
                using (MsiCommand cmd = new MsiCommand("SELECT Component_, FileSize FROM File", conn)) {
                    using (MsiDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            MsiComponent component = new MsiComponent();
                            component.Id = reader.GetString(0);
                            component.FileSize = reader.GetInteger(1);

                            files.Add(component.Id, component);
                        }
                    }
                }

                // 2. Get feature component mapping
                Dictionary<string, List<string>> featureComponents = new Dictionary<string, List<string>>();
                using (MsiCommand cmd = new MsiCommand("SELECT Feature_, Component_ FROM FeatureComponents", conn)) {
                    using (MsiDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            string feature = reader.GetString(0);
                            if (featureComponents.ContainsKey(feature) == false) {
                                featureComponents.Add(feature, new List<string>());
                            }
                            featureComponents[feature].Add(reader.GetString(1));
                        }
                    }
                }

                // 3. calculate feature cost
                foreach (string feature in featureComponents.Keys) {
                    int cost = 0;
                    foreach (string component in featureComponents[feature]) {
                        if (files.ContainsKey(component)) {
                            cost += files[component].FileSize;
                        }
                    }

                    dicFeatures[feature].SetFeatureCost(cost);
                }

                // 4. Get total feature cost
                foreach (MsiFeature feature in featureTree) {
                    CalculateTotalFeatureCost(feature);
                }
            }
        }

        private void CalculateTotalFeatureCost(MsiFeature parentFeature) {
            long totalCost = parentFeature.FeatureCost;
            if (parentFeature.ChildFeatures != null) {
                foreach (MsiFeature feature in parentFeature.ChildFeatures) {
                    CalculateTotalFeatureCost(feature);

                    totalCost += feature.FeatureCost;
                }
            }

            parentFeature.SetTotalCost(totalCost);
        }
        #endregion

        /// <summary>Install ALL features and components assigned to it.</summary>
        /// <returns>InstallationStatus</returns>
        public InstallationStatus Install() {
            string installFeatures = "ADDLOCAL=ALL";

            return StartInstallationThread(installFeatures);
        }

        /// <summary>Installs list of features supplied by the user.</summary>
        /// <param name="features">Specific list of features to be installed. Child nodes are NOT included.</param>
        /// <returns>InstallationStatus</returns>
        public InstallationStatus Install(List<MsiFeature> features) {
            if (features == null || features.Count == 0) {
                throw new ApplicationException("Installation failed as list of feature to install is not supplied");
            }

            string alreadyInstalled = GetAlreadyInstalledFeatures(features);
            string alreadyNotInstalled = GetAlreadyNotInstalledFeatures(features);

            string installFeatures = (alreadyInstalled == "" ? "" : "REINSTALL=" + alreadyInstalled) + " " + (alreadyNotInstalled == "" ? "" : "ADDLOCAL=" + alreadyNotInstalled);

            return StartInstallationThread(installFeatures);
        }

        /// <summary>Repairs components which are already installed on local machine.</summary>
        /// <returns>InstallationStatus</returns>
        public InstallationStatus Repair() {
            string repairFeatures = "REINSTALL=" + GetAlreadyInstalledFeatures();

            return StartInstallationThread(repairFeatures);
        }

        /// <summary>Removes ALL features, components installed on location machine.</summary>
        /// <returns>InstallationStatus</returns>
        public InstallationStatus Uninstall() {
            string removeFeatures = "REMOVE=ALL";

            return StartInstallationThread(removeFeatures);
        }

        /// <summary>Uninstalls list of features supplied by the user.</summary>
        /// <param name="features">Specific list of features to be uninstalled. Child nodes are NOT included.</param>
        /// <returns>InstallationStatus</returns>
        public InstallationStatus Uninstall(List<MsiFeature> features) {
            if (features == null || features.Count == 0) {
                throw new ApplicationException("Installation failed as feature to install is not supplied");
            }

            string removeFeatures = "REMOVE=" + GetFeatureList(features);

            return StartInstallationThread(removeFeatures);
        }

        /// <summary>Selectively install, uninstall specific features.</summary>
        /// <param name="installFeatures">Specific list of features to be installed. Already installed features are re-installed</param>
        /// <param name="uninstallFeatures">Spefici list of features to be uninstalled.</param>
        /// <returns>InstallationStatus</returns>
        public InstallationStatus Update(List<MsiFeature> installFeatures, List<MsiFeature> uninstallFeatures) {
            if ((installFeatures == null || installFeatures.Count == 0) && (uninstallFeatures == null && uninstallFeatures.Count == 0)) {
                throw new ApplicationException("Installation failed as list of feature to install/uninstall is not supplied");
            }

            string alreadyInstalled = GetAlreadyInstalledFeatures(installFeatures);
            string alreadyNotInstalled = GetAlreadyNotInstalledFeatures(installFeatures);

            string strInstallFeatures = (alreadyInstalled == "" ? "" : "REINSTALL=" + alreadyInstalled) + " " + (alreadyNotInstalled == "" ? "" : "ADDLOCAL=" + alreadyNotInstalled);

            string removeFeatures = "REMOVE=" + GetFeatureList(uninstallFeatures);

            string updatefeaturs = (installFeatures.Count == 0 ? "" : strInstallFeatures) + " " + (uninstallFeatures.Count == 0 ? "" : removeFeatures);

            return StartInstallationThread(updatefeaturs);
        }

        /// <summary>Send user response back to Windows Installer. Ex: MsiResponse.Cancel will cancel installation. MsiResponse.OK is the default value.</summary>
        /// <param name="userAction">Input supplied by the user. Use MsiResponse</param>
        public void SetUserAction(MsiResponse userAction) {
            userActed = true;
            this.userAction = userAction;
        }

        #region Get Installed Features
        private string GetFeatureList(List<MsiFeature> fs) {
            string installFeatures = string.Empty;
            foreach (MsiFeature feature in fs) {
                if (feature.Enabled) {
                    installFeatures += feature.Id + ",";
                }
            }

            return installFeatures.Trim(",".ToCharArray());
        }
        private string GetAlreadyInstalledFeatures() {
            return GetAlreadyInstalledFeatures(this.features);
        }

        private string GetAlreadyInstalledFeatures(List<MsiFeature> features) {
            string installFeatures = string.Empty;
            foreach (MsiFeature feature in features) {
                if (feature.Enabled && feature.IsAlreadyInstalled) {
                    installFeatures += feature.Id + ",";
                }
            }

            return installFeatures.Trim(",".ToCharArray());
        }

        private string GetAlreadyNotInstalledFeatures(List<MsiFeature> features) {
            string installFeatures = string.Empty;
            foreach (MsiFeature feature in features) {
                if (feature.Enabled && feature.IsAlreadyInstalled == false) {
                    installFeatures += feature.Id + ",";
                }
            }

            return installFeatures.Trim(",".ToCharArray());
        }
        #endregion

        private InstallationStatus StartInstallationThread(string args) {
            try {
                if (installThread != null && ((installThread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) == 0)) {
                    return InstallationStatus.AlreadyRunning;
                }

                // Add Install dir to arguments
                if (String.IsNullOrEmpty(installDir) == false) {
                    args += " INSTALLDIR=\"" + installDir + "\"";
                }

                installThread = new Thread(new ParameterizedThreadStart(StartInstallation));
                installThread.IsBackground = true;
                installThread.Start(args);
                return InstallationStatus.Started;
            } catch {
                return InstallationStatus.UnknownError;
            }
        }

        private void StartInstallation(object args) {
            IntPtr parent = IntPtr.Zero;
            MsiInstallUILevel oldLevel = MsiInterop.MsiSetInternalUI(MsiInstallUILevel.None | MsiInstallUILevel.SourceResOnly, ref parent);
            MsiInstallUIHandler oldHandler = null;

            try {
                MsiInstallUIHandler uiHandler = new MsiInstallUIHandler(OnExternalUI);
                oldHandler = MsiInterop.MsiSetExternalUI(uiHandler, MsiInstallLogMode.ExternalUI, IntPtr.Zero);
                Application.DoEvents();
                MsiError ret = MsiInterop.MsiInstallProduct(msiFile, (string)args);

                InstallCompleteMessage installCompleteMessage = new InstallCompleteMessage();
                installCompleteMessage.SetSuccessStatus(ret == MsiError.Success);
                SendInstallerMessageReceived(installCompleteMessage);

            } catch (Exception exc) {
                WriteLogMessage("Unknown error occured: " + exc.ToString());
            } finally {
                if (oldHandler != null) {
                    MsiInterop.MsiSetExternalUI(oldHandler, MsiInstallLogMode.None, IntPtr.Zero);
                }
                MsiInterop.MsiSetInternalUI(oldLevel, ref parent);

#if NotLicensed
                FinishForm finishForm = new FinishForm();
                finishForm.ShowDialog();
#endif
            }
        }

        //http://msdn.microsoft.com/en-us/library/aa370573%28VS.85%29.aspx
        private int OnExternalUI(IntPtr context, uint messageType, string message) {
            MsiInstallMessage msg = (MsiInstallMessage)(MsiInterop.MessageTypeMask & messageType);
#if DEBUG
            WriteLogMessage(string.Format("MSI:  {0} {1}", msg, message));
#endif

            try {
                switch (msg) {
                    /* Formatted error or info messages. No additional processing is needed by external UI */
                    case MsiInstallMessage.FatalExit:
                        ErrorMessage fatalErrorMessage = new ErrorMessage();
                        fatalErrorMessage.SetErrorMessageType(ErrorMessageType.FatalExit);
                        fatalErrorMessage.SetFormattedMessage(message);
                        SendInstallerMessageReceived(fatalErrorMessage, true);
                        return (int)(userActed ? userAction : MsiResponse.OK);

                    case MsiInstallMessage.Error:
                        if (CheckFileInUseMessage(message) == false) {
                            ErrorMessage errorMessage = new ErrorMessage();
                            errorMessage.SetErrorMessageType(ErrorMessageType.FatalExit);
                            errorMessage.SetFormattedMessage(message);
                            SendInstallerMessageReceived(errorMessage, true);
                        }
                        return (int)(userActed ? userAction : MsiResponse.OK);

                    case MsiInstallMessage.Warning:
                        ErrorMessage warningMessage = new ErrorMessage();
                        warningMessage.SetErrorMessageType(ErrorMessageType.Warning);
                        warningMessage.SetFormattedMessage(message);
                        SendInstallerMessageReceived(warningMessage, true);
                        return (int)(userActed ? userAction : MsiResponse.OK);

                    case MsiInstallMessage.Info:
                        InformationMessage infoMessage = new InformationMessage();
                        infoMessage.SetFormattedMessage(message);
                        SendInstallerMessageReceived(infoMessage);
                        Application.DoEvents();
                        return (int)MsiResponse.OK;

                    case MsiInstallMessage.User:
                        InformationMessage userMessage = new InformationMessage();
                        userMessage.SetFormattedMessage(message);
                        SendInstallerMessageReceived(userMessage);
                        Application.DoEvents();
                        return (int)MsiResponse.OK;

                    case MsiInstallMessage.OutOfDiskSpace:
                        Application.DoEvents();
                        return (int)MsiResponse.OK;

                    /* Windows installer UI sequence messages. ALL THESE MESSAGES (UI SEQUENCE) ARE IGNORED */
                    case MsiInstallMessage.Terminate:
                        Application.DoEvents();
                        return (int)MsiResponse.OK;
                    case MsiInstallMessage.Initialize:
                        Application.DoEvents();
                        return (int)MsiResponse.OK;
                    case MsiInstallMessage.ShowDialog:
                        Application.DoEvents();
                        return (int)MsiResponse.OK;

                    /* Windows installer messages which need input from the user */
                    case MsiInstallMessage.ResolveSource:
                        /*The external user interface handler must return 0 and allow Windows Installer to handle the message.*/
                        Application.DoEvents();
                        return 0;

                    case MsiInstallMessage.FilesInUse:
                        /*Display files in use message*/
                        Application.DoEvents();
                        return 0;

                    case MsiInstallMessage.ActionStart:
                        Process_ActionStart_Message(message);
                        Application.DoEvents();
                        return (int)(userActed ? userAction : MsiResponse.OK);

                    case MsiInstallMessage.ActionData:
                        ActionDataMessage actionDataMessage = new ActionDataMessage();
                        actionDataMessage.SetFormattedMessage(message);
                        SendInstallerMessageReceived(actionDataMessage, true);
                        Application.DoEvents();
                        return (int)(userActed ? userAction : MsiResponse.OK);

                    case MsiInstallMessage.CommonData:
                        /****** IGNORED ******/
                        //int commonDataStatus = Process_CommonData_Message(message);
                        //Application.DoEvents();
                        //return commonDataStatus;
                        Application.DoEvents();
                        return (int)MsiResponse.OK;

                    /* Progress bar messages */
                    case MsiInstallMessage.Progress:
                        bool parsed = Process_Progress_Message(message);
                        Application.DoEvents();
                        return (int)(parsed ? (userActed ? userAction : MsiResponse.OK) : MsiResponse.OK);

                    default: break;
                }
            } catch (Exception e) {
                WriteLogMessage("Unknown error occured: " + e.ToString());
            }

            Application.DoEvents();

            return 0;
        }

        private bool CheckFileInUseMessage(string message) {
            bool isFileInUseMessage = false;
            Regex matchPattern = new Regex(@"Another application has exclusive access to the file '(?<file>.*)'.*");
            if (matchPattern.IsMatch(message)) {
                Match match = matchPattern.Match(message);
                string filename = match.Groups["file"].Value;
                FileInUseMessage installerMessage = new FileInUseMessage();
                installerMessage.SetFilePath(filename);
                SendInstallerMessageReceived(installerMessage, true);
                isFileInUseMessage = true;
            }
            return isFileInUseMessage;
        }

        //1: 2 2: 25 3: 0 4: 1 
        private bool Process_Progress_Message(string message) {
            string[] progressItems = message.Split(": ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (progressItems == null || progressItems.Length == 0 || progressItems[0] == null) {
                Application.DoEvents();
            }

            List<string> fields = new List<string>();
            for (int i = 0; i < progressItems.Length; i++) {
                if (i % 2 == 1) fields.Add(progressItems[i]);
            }

            if (fields.Count == 0) return false;

            //http://msdn.microsoft.com/en-us/library/aa370573%28VS.85%29.aspx
            InstallerMessage progressMessage = null;
            switch (fields[0]) {
                case "0":
                    ResetMessage resetMessage = new ResetMessage();
                    if (fields.Count > 1) {
                        resetMessage.SetTicks(Int32.Parse(fields[1]));
                    }
                    if (fields.Count > 2) {
                        if (fields[2] == "0")
                            resetMessage.SetDirection(ProgressDirection.Forward);
                        else
                            resetMessage.SetDirection(ProgressDirection.Backward);
                    }
                    if (fields.Count > 3) {
                        if (fields[3] == "0") {
                            resetMessage.SetIsApproximate(false);
                        } else if (fields[3] == "1") {
                            resetMessage.SetIsApproximate(true);
                        }
                    }

                    progressMessage = resetMessage;
                    break;
                case "1":
                    //ActionInfoMessage actionInfoMessage = new ActionInfoMessage();
                    //if (fields.Count > 1) {
                    //  actionInfoMessage.SetTicksPerActionData(Int32.Parse(fields[1]));
                    //}
                    //if (fields.Count > 2) {
                    //  if (fields[2] == "0")
                    //    actionInfoMessage.SetIgnoreTicksPerActionData(true);
                    //  else
                    //    actionInfoMessage.SetIgnoreTicksPerActionData(false);
                    //}

                    //progressMessage = actionInfoMessage;
                    break;
                case "2":
                    ProgressReportMessage progressReportMessage = new ProgressReportMessage();
                    if (fields.Count > 1)
                        progressReportMessage.SetTicksMoved(Int32.Parse(fields[1]));

                    progressMessage = progressReportMessage;
                    break;
                case "3":
                    //ProgressAdditionMessage progressAddition = new ProgressAdditionMessage();
                    //if (fields.Count > 1) {
                    //  progressAddition.SetTicks(Int32.Parse(fields[1]));
                    //}

                    //progressMessage = progressAddition;
                    break;
                default: break;
            }

            SendInstallerMessageReceived(progressMessage);

            return true;
        }

        //1: 0 2: 1033 3: 1252 
        /*
        private int Process_CommonData_Message(string message) {
          InstallerMessage commonData = null;
          if (String.IsNullOrEmpty(message) == false) {
            Regex matchPattern = new Regex(@"1: (?<f1>\d) 2:(?<f2>[\w\s\d]+) 3: (?<f3>[\w\s\d]+)");
            if (matchPattern.IsMatch(message)) {
              Match match = matchPattern.Match(message);
              switch (match.Groups["f1"].Value) {
                case "0":
                  LanguageInformation languageData = new LanguageInformation();
                  if (String.IsNullOrEmpty(match.Groups["f2"].Value) == false) {
                    languageData.SetLanguageId(Int32.Parse(match.Groups["f2"].Value));
                  }
                  if (String.IsNullOrEmpty(match.Groups["f3"].Value) == false) {
                    languageData.SetCodePage(Int32.Parse(match.Groups["f3"].Value));
                  }

                  commonData = languageData;
                  break;
                case "1":
                  UserInterfaceCaption captionData = new UserInterfaceCaption();
                  if (String.IsNullOrEmpty(match.Groups["f2"].Value) == false) {
                    captionData.SetCaption(match.Groups["f2"].Value);
                  }

                  commonData = captionData;
                  break;
                case "2":
                  CancelShowMessage cancelShow = new CancelShowMessage();
                  if (String.IsNullOrEmpty(match.Groups["f2"].Value) == false) {
                    cancelShow.SetShowCancelButton(match.Groups["f2"].Value.Equals("1", StringComparison.OrdinalIgnoreCase));
                  }

                  commonData = cancelShow;
                  break;
              }
            }
          }

          SendInstallerMessageReceived(commonData);

          return (int)MsiResponse.OK;
        }
        */

        //11:51:36: CostInitialize. Computing space requirements
        private void Process_ActionStart_Message(string message) {
            if (String.IsNullOrEmpty(message) == false) {
                Regex matchPattern = new Regex(@"(?<time>[\d:]+): (?<action>[\w]+)\. (?<description>[\w\d\s]+)*");
                if (matchPattern.IsMatch(message)) {
                    Match match = matchPattern.Match(message);
                    ActionStartMessage actionStartMessage = new ActionStartMessage();
                    actionStartMessage.SetTime(match.Groups["time"].Value);
                    actionStartMessage.SetAction(match.Groups["action"].Value);
                    actionStartMessage.SetDescription(match.Groups["description"].Value);

                    SendInstallerMessageReceived((InstallerMessage)actionStartMessage);
                }
            }
        }

        private void SendInstallerMessageReceived(InstallerMessage installerMessage) {
            SendInstallerMessageReceived(installerMessage, false);
        }

        private void SendInstallerMessageReceived(InstallerMessage installerMessage, bool needsUserAction) {
            if (installerMessage != null && InstallerMessageReceived != null) {
                this.userActed = false;
                InstallerMessageEventArgs args = new InstallerMessageEventArgs(installerMessage, needsUserAction);
                InstallerMessageReceived(this, args);
            }
        }


        private void WriteLogMessage(string message) {
#if DEBUG
            if (MessageLogged != null) {
                MessageLogged(this, new LogMessage(message));
            }
#endif
        }

        //private void RequestUserToAct(InstallerMessageEventArgs installerMsg) {
        //  Thread requestThread = new Thread(delegate() { if (InstallerMessageReceived != null) InstallerMessageReceived(this, installerMsg); });
        //  requestThread.Start();
        //  if (installerMsg.IsWaitingUserAction) {
        //    waitUserAction.WaitOne();
        //  }
        //}
    }
}