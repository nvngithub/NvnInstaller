using System;
using System.Collections.Generic;
using System.Text;
using NvnInstaller.WixClasses;
using Forms = System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using IO = System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;

namespace NvnInstaller {
    public static class MsiBuilder {
        private static Wix wix;
        public static Product Product;
        public static Directory TargetDirectory;
        public static Directory InstallDirectory;
        public static Feature Feature;
        public static bool IsCustomLocation;
        public static string UILocalizedFile;
        public static Dictionary<string, Feature> FeatureTable = new Dictionary<string, Feature>();
        public static List<object> RegistryComponents = new List<object>();
        public static List<object> EnvironmentComponents = new List<object>();
        public static List<UIRef> UIRef = new List<UIRef>();
        public static Dictionary<string, object> PropertyElements = new Dictionary<string, object>();
        public static List<object> ConditionElements = new List<object>();
        public static List<object> ProductMiscElements = new List<object>();
        public static object[] CustomActionItems;
        public static BackgroundWorker buildThread = new BackgroundWorker();
        public static BuildTypes BuildType = BuildTypes.Msi;

        static MsiBuilder() {
            Init();

            buildThread.WorkerReportsProgress = buildThread.WorkerSupportsCancellation = true;
            buildThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BuildThread_RunWorkerCompleted);
            buildThread.ProgressChanged += new ProgressChangedEventHandler(BuildThread_ProgressChanged);
            buildThread.DoWork += new DoWorkEventHandler(BuildThread_StartBuild);
        }

        private static void Init() {
            wix = new Wix(); Product = new Product(); Feature = new Feature();
            TargetDirectory = new Directory(); InstallDirectory = new Directory();
            CustomActionItems = null; UILocalizedFile = "WixUI_en-us.wxl";
            RegistryComponents.Clear(); UIRef.Clear(); PropertyElements.Clear();
            ProductMiscElements.Clear(); FeatureTable.Clear(); EnvironmentComponents.Clear();
            ConditionElements.Clear(); MsiCompiler.BootstrapperName = string.Empty;            

            // delete all *.url files
            string[] files = IO.Directory.GetFiles(Globals.localFolder, "*.url");
            foreach (string filePath in files) {
                IO.File.Delete(filePath);
            }
        }

        public static void Build(BuildTypes buildType) {
            if (buildThread.IsBusy == false) {
                BuildType = buildType;
                // Build in a seperate Thread(Asynchronous)
                buildThread.RunWorkerAsync();
            }
        }

        private static bool BuildControls() {
            // 1. validate
            buildThread.ReportProgress(10, "Start validation");
            foreach (Forms.Control control in ControlsManager.Controls.Values) {
                if (control is INvnControl) {
                    INvnControl ctrl = (INvnControl)control;
                    ctrl.InitializeBuild();
                    ctrl.Validate();
                }
            }

            if (BuildLogger.ErrorCount > 0) {
                return false;
            }

            buildThread.ReportProgress(10, "Validation complete");
            //2. Build if there is no error
            if (BuildLogger.ErrorCount == 0) {
                foreach (Forms.Control control in ControlsManager.Controls.Values) {
                    if (control is INvnControl) {
                        INvnControl ctrl = (INvnControl)control;
                        ctrl.Build();
                        buildThread.ReportProgress(3, "Building " + control.ToString());
                    }
                }
                //3. Combile all wix objects and serialize to a XML file
                CombineWixObjects();

                buildThread.ReportProgress(1, "Saving application file");
                XmlSerializer serializer = new XmlSerializer(typeof(Wix));
                using (XmlTextWriter writer = new XmlTextWriter(Globals.wixFile, Encoding.UTF8)) {
                    writer.Formatting = Formatting.Indented;
                    writer.QuoteChar = '\'';
                    serializer.Serialize(writer, wix);
                }
                buildThread.ReportProgress(5, "Application file saved");

                string xmlText = string.Empty;
                using (System.IO.StreamReader stream = new System.IO.StreamReader(Globals.wixFile)) {
                    xmlText = stream.ReadToEnd();
                }
                if (String.IsNullOrEmpty(xmlText) == false) {
                    using (System.IO.TextWriter streamWriter = new System.IO.StreamWriter(Globals.wixFile, false, Encoding.UTF8)) {
                        // This used to get rid of xml escape characters like &amp;
                        System.Web.HttpUtility.HtmlDecode(xmlText, streamWriter);
                    }
                }
                // show serialized text in Wix Code Editor
                ControlsManager.WixCodeEditorControl.LoadWixFileText(Globals.wixFile);                
            }
            return true;
        }

        private static void CombineWixObjects() {
            int totalItems = 6; //+ BinaryElements.Count + InstallationExeSequences.Count + CustomActions.Count;
            Product.Items = new object[totalItems];//new object[6 + wixVariables.Count];
            Product.Items[0] = GetMediaNode();
            Product.Items[1] = GetPropertyNode();
            Product.Items[2] = TargetDirectory;
            Product.Items[3] = Feature;
            wix.Items = new Product[1];
            wix.Items[0] = Product;

            TargetDirectory.Items = Common.AddItemToArray(TargetDirectory.Items, RegistryComponents);
            InstallDirectory.Items = Common.AddItemToArray(InstallDirectory.Items, EnvironmentComponents);

            Product.Items[4] = UIRef[0];
            Product.Items[5] = UIRef[1];

            if (CustomActionItems != null && CustomActionItems.Length > 0) {
                Product.Items = Common.AddItemToArray(Product.Items, CustomActionItems);
            }
            if (PropertyElements.Count > 0) {
                List<object> properties = new List<object>();
                foreach (string id in PropertyElements.Keys) {
                    properties.Add(PropertyElements[id]);
                }

                Product.Items = Common.AddItemToArray(Product.Items, properties);
            }
            if (ProductMiscElements.Count > 0) {
                Product.Items = Common.AddItemToArray(Product.Items, ProductMiscElements);
            }
            if (ConditionElements.Count > 0) {
                Product.Items = Common.AddItemToArray(Product.Items, ConditionElements);
            }
        }

        private static object GetPropertyNode() {
            Property property = new Property();
            property.Id = "DiskPrompt";
            property.Value = "Nvn Installtion";// TODO: set value here

            return property;
        }

        private static object GetMediaNode() {
            Media media = new Media();
            media.Id = "1";
            media.Cabinet = "NvnInstaller.cab";// TODO: set suitable name like product name
            media.EmbedCabSpecified = true;
            media.EmbedCab = YesNoType.yes;
            media.DiskPrompt = "CD-ROM #1";

            return media;
        }

        #region Build Thread events
        static void BuildThread_StartBuild(object sender, DoWorkEventArgs e) {
            buildThread.ReportProgress(0, "");

            Init();

            // lear logs and also output control
            BuildLogger.Initialize();
            ControlsManager.OutputControl.Clear();
            // Start validation and build
            bool buildSuccess = BuildControls();
            if (buildSuccess) {
                //Delete all .wixobj files
                string[] wixFiles = IO.Directory.GetFiles(Common.localWixFolder, "*.wixobj", IO.SearchOption.AllDirectories);
                foreach (string wixFile in wixFiles) {
                    IO.File.Delete(wixFile);
                }

                // compile wix object file
                MsiCompiler compiler = new MsiCompiler();
                if (Globals.isByCommand && Globals.outFile != string.Empty) {
                    compiler.Compile(Globals.outFile);
                } else {
                    compiler.Compile(ControlsManager.ProductInformation.Output.Text);
                }
            }
        }

        static void BuildThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Globals.NotifyBuildProgress(100, string.Empty);

            if (Globals.closeAfterBuild) { Application.Exit(); }
        }

        static void BuildThread_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            Globals.NotifyBuildProgress(e.ProgressPercentage, (string)e.UserState);
        }
        #endregion
    }
}
