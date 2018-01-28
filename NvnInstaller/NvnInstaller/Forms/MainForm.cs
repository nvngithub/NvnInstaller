using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnInstaller;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using NvnInstaller.Properties;

namespace NvnInstaller {
    delegate void ControlsManager_ControlSelectionChangedDelegate(object sender, ControlSelectedEventArgs e);
    public partial class MainForm : Form {
        RecentFiles recentFiles = new RecentFiles(Globals.recentFileName);
        string projectFile = string.Empty;
        bool autoBuild = false, isResettingApp = false;
        SysImageList sysilsSmall = new SysImageList(SysImageListSize.smallIcons);

        public MainForm() {
            InitializeComponent();

            pictureBox.Image = new Bitmap(Globals.imagesFolder + "NvnInstaller-48.bmp");
            lblVersion.Text = "Version " + Globals.version;
            lblApplicationCategory.Text = Globals.applicationCategory;
            this.Text = lblApplicationName.Text = Globals.applicationName;
            ControlsManager.ControlSelectionChanged += new EventHandler<ControlSelectedEventArgs>(ControlsManager_ControlSelectionChanged);

            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show();

            for (int i = 0; i < 5; i++) {
                loadingForm.SetLoadingStatus(5);
                Thread.Sleep(150);
            }

            Support.RunSanityCheck();
            LoadApplication();

            for (int i = 0; i < 15; i++) {
                loadingForm.SetLoadingStatus(5);
                Thread.Sleep(150);
            }
            loadingForm.Close();
        }

        public MainForm(string projectFile, bool build, bool autoClose)
            : this() {
            this.projectFile = projectFile;
            this.autoBuild = build && this.projectFile != string.Empty;
            Globals.closeAfterBuild = autoClose && build;
        }

        // this is not form load event handler
        private void LoadApplication() {
            // Set toolbar images
            btnNew.Image = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgNew, true)).ToBitmap();
            btnOpen.Image = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgOpen, true)).ToBitmap();
            btnSave.Image = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgSave, true)).ToBitmap();
            btnRun.Image = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgNvnInstallerIcon, true)).ToBitmap();
            btnHelp.Image = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgHelp, true)).ToBitmap();

            // load each controls
            foreach (Control control in ControlsManager.Controls.Values) {
                if (control is INvnControl) {
                    ((INvnControl)control).InitializeLoad();
                    ((INvnControl)control).Load();
                }
            }
            // validate license key
            LicenceKeyValidator.Validate();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            recentFiles.Load();
            UpdateRecentMenuItems();

            LoadProfile();

            // load project file is application is started from command prompt
            if (Globals.isByCommand) {
                OpenFile(projectFile);
                if (autoBuild) {
                    Logger.ApplicationLog(new LogMessage("Autobuild started"+Globals.closeAfterBuild, null));
                    BuildMSI_Click(null, null);
                }
            }
        }

        private void LoadProfile() {
            Profile.ProfilePath = Globals.profilePath;
            Profile.Load();
            string value = Profile.Get(this.Name + ".WindowState");
            this.WindowState = String.IsNullOrEmpty(value) ? this.WindowState : (FormWindowState)Enum.Parse(typeof(FormWindowState), value);
            value = Profile.Get(this.Name + ".Top");
            this.Top = String.IsNullOrEmpty(value) ? this.Top : Int32.Parse(value);
            value = Profile.Get(this.Name + ".Left");
            this.Left = String.IsNullOrEmpty(value) ? this.Left : Int32.Parse(value);
            value = Profile.Get(this.Name + ".Width");
            this.Width = String.IsNullOrEmpty(value) ? this.Width : Int32.Parse(value);
            value = Profile.Get(this.Name + ".Height");
            this.Height = String.IsNullOrEmpty(value) ? this.Height : Int32.Parse(value);
            value = Profile.Get(splitContainerMain.Name);
            splitContainerMain.SplitterDistance = String.IsNullOrEmpty(value) ? splitContainerMain.SplitterDistance : Int32.Parse(value);
        }

        void ControlsManager_ControlSelectionChanged(object sender, ControlSelectedEventArgs e) {
            if (InvokeRequired) {
                Invoke(new ControlsManager_ControlSelectionChangedDelegate(ControlsManager_ControlSelectionChanged), sender, e);
            } else {
                Control selectedControl = e.Control;
                if (selectedControl != null) {
                    selectedControl.Dock = DockStyle.Fill;
                    splitContainerMain.Panel2.Controls.Clear();
                    splitContainerMain.Panel2.Controls.Add(selectedControl);
                }
            }
        }

        private void BuildMSI_Click(object sender, EventArgs e) {
            ControlsManager.SelectControl(ControlType.Output);
            MsiBuilder.Build(BuildTypes.Msi);
        }

        private void InstallMSI_Click(object sender, EventArgs e) {
            // start MSI file given in properties
            string msiPath = ControlsManager.ProductInformation.Output.Text;
            if (String.IsNullOrEmpty(msiPath) == false || File.Exists(msiPath)) {
                Process.Start(msiPath);
            }
        }

        private void BuildPathFile_Click(object sender, EventArgs e) {
            ControlsManager.SelectControl(ControlType.Output);
            PatchBuilder.Build();
        }

        private void InstallPatchFile_Click(object sender, EventArgs e) {
            //// start Patch file given in properties
            //string msiPath = ControlsManager.ProductInformation.Output.Text;
            //if (String.IsNullOrEmpty(msiPath) == false || File.Exists(msiPath)) {
            //    Process.Start(msiPath);
            //}
        }

        private void New_Click(object sender, EventArgs e) {
            foreach (Control control in ControlsManager.Controls.Values) {
                if (control is INvnControl) {
                    ((INvnControl)control).InitializeLoad();
                }
            }
        }

        private void Open_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                OpenFile(dlg.FileName);
            }
        }

        private void OpenFile(string filename) {
            if (File.Exists(filename) == false) return;
            // Initialize load... ex clear tree nodes etc
            foreach (Control control in ControlsManager.Controls.Values) {
                if (control is INvnControl) {
                    ((INvnControl)control).InitializeLoad();
                }
            }
            // Load project
            projectFile = filename;
            // deserialize
            Stream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Dictionary<string, object> objects = (Dictionary<string, object>)bf.Deserialize(fileStream);
            fileStream.Close();
            // load each controls(Specific implementations)
            foreach (Control control in ControlsManager.Controls.Values) {
                if (control is INvnControl) {
                    ((INvnControl)control).Open(objects);
                }
            }
            // add to recent files
            recentFiles.Append(filename);
            UpdateRecentMenuItems();
        }

        private void Save_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(projectFile)) {
                // save current project to the given file
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "nvn";
                dlg.Filter = "NVN Installer files|*.nvn";
                dlg.InitialDirectory = Environment.CurrentDirectory;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    Save(dlg.FileName);
                }
            } else {
                Save(projectFile);
            }
        }

        private void SaveAs_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "nvn";
            dlg.Filter = "NVN Installer files|*.nvn";
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Save(dlg.FileName);
            }
        }

        private void Save(string filename) {
            Dictionary<string, object> objects = new Dictionary<string, object>();
            // Initialise save Specific implementations
            foreach (Control control in ControlsManager.Controls.Values) {
                if (control is INvnControl) {
                    ((INvnControl)control).Saving();
                    ((INvnControl)control).LoadSaveObjects(objects);
                }
            }
            // serialise
            Stream file = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, objects);
            file.Close();
            // update recent menu items
            recentFiles.Append(filename);
            UpdateRecentMenuItems();
        }

        private void exit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CloseApplication() {
            if (isResettingApp == false) {
                recentFiles.Save();

                Profile.Set(this.Name + ".Top", this.Top.ToString());
                Profile.Set(this.Name + ".Left", this.Left.ToString());
                Profile.Set(this.Name + ".Width", this.Width.ToString());
                Profile.Set(this.Name + ".Height", this.Height.ToString());
                Profile.Set(splitContainerMain.Name, splitContainerMain.SplitterDistance.ToString());
                Profile.Set(this.Name + ".WindowState", this.WindowState.ToString());
                Profile.Save();
                // close all user controls
                foreach (Control control in ControlsManager.Controls.Values) {
                    if (control is INvnControl) {
                        ((INvnControl)control).Close();
                    }
                }
                Globals.NotifyApplicationClosing();
            }
        }

        private void UpdateRecentMenuItems() {
            mnuRecentFiles.DropDownItems.Clear();
            for (int i = 0; i < recentFiles.Files.Count; i++) {
                string fileName = recentFiles.Files[i];
                FileInfo fileInfo = new FileInfo(fileName);
                ToolStripMenuItem item = new ToolStripMenuItem(fileInfo.Name);
                item.Click += new EventHandler(RecentFile_Click);
                item.ToolTipText = fileName;
                mnuRecentFiles.DropDownItems.Add(item);
            }
        }

        void RecentFile_Click(object sender, EventArgs e) {
            ToolStripMenuItem selectedItem = (ToolStripMenuItem)sender;
            string selectedFileName = (string)selectedItem.ToolTipText;
            OpenFile(selectedFileName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            CloseApplication();
        }

        private void summary_Click(object sender, EventArgs e) {
            (new SummaryForm()).ShowDialog();
        }

        private void addRemovePrograms_Click(object sender, EventArgs e) {
            Process.Start("appwiz.cpl");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {            
            Globals.NotifyKeyDown(ControlsManager.SelectedControlType, e);
        }

        #region Settings menu items
        private void viewLogs_Click(object sender, EventArgs e) {
            LogViewerForm logViewer = new LogViewerForm();
            logViewer.ShowDialog();
        }

        private void mnuSaveProductInformation_Click(object sender, EventArgs e) {
            if (File.Exists(Globals.productInformationFile) == false) {
                FileInfo fileInfo = new FileInfo(Globals.productInformationFile);
                if (Directory.Exists(fileInfo.Directory.FullName) == false) {
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                }
                FileStream stream = File.Create(Globals.productInformationFile);
                stream.Close();
            }
            ProductInformation information = ControlsManager.ProductInformation.SetProductInformation();
            ControlsManager.ProductInformation.SaveDefaultInfo(information);
        }

        private void mnuClearProductInformation_Click(object sender, EventArgs e) {
            if (System.IO.File.Exists(Globals.productInformationFile))
                System.IO.File.Delete(Globals.productInformationFile);
        }

        private void mnuResetApplication_Click(object sender, EventArgs e) {
            if (MessageBox.Show("This change will not take effect until after you quit and launch the application again. Would you like restart now ?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                isResettingApp = true;
                // Delete all files and folders in Local applications folder
                string[] dirs = Directory.GetDirectories(Globals.localFolder);
                foreach (string dir in dirs) {
                    Directory.Delete(dir, true);
                }
                string[] files = Directory.GetFiles(Globals.localFolder, "*.*", SearchOption.AllDirectories);
                foreach (string file in files) {
                    if (file != Globals.productKeyFile) {
                        File.Delete(file);
                    }
                }
                Application.Restart();
            }
        }

        private void mnuDefaultWindow_Click(object sender, EventArgs e) {
            if (File.Exists(Globals.profilePath)) {
                File.Delete(Globals.profilePath);
            }
        }
        #endregion

        #region Help Menu options

        private void mnuSamples_Click(object sender, EventArgs e) {
            if (Directory.Exists(Globals.samplesFolder)) {
                Process.Start(Globals.samplesFolder);
            } else {
                MessageBox.Show("Certain required files were not found in the Nvn Installer application folder. Reinstall the application may fix this problem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuHelp_Click(object sender, EventArgs e) {
            Process.Start("www.nvninstaller.com/help");
        }

        private void mnuRegister_Click(object sender, EventArgs e) {
            (new RegisterForm()).ShowDialog();
        }

        private void mnuTermsAndConditions_Click(object sender, EventArgs e) {
            (new TermsForm()).ShowDialog();
        }

        private void mnuAboutNvnInstaller_Click(object sender, EventArgs e) {
            (new AboutUsForm()).ShowDialog();
        }
        #endregion

        private void lnkSeekingProjects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            (new SeekingProjectsForm()).ShowDialog();
        }
    }
}