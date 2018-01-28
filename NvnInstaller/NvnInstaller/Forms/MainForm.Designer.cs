namespace NvnInstaller
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveaasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuResetApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDefaultWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.defaltProductInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveProductInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearProductInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.buildMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBuildPathFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstallPatchFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.summaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemoveProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSamples = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTermsAndConditions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutNvnInstaller = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.lblApplicationCategory = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonsControl1 = new NvnInstaller.ButtonsControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuOptions,
            this.buildMainToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1115, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveaasToolStripMenuItem,
            this.toolStripSeparator2,
            this.mnuRecentFiles,
            this.toolStripSeparator7,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.New_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveaasToolStripMenuItem
            // 
            this.saveaasToolStripMenuItem.Name = "saveaasToolStripMenuItem";
            this.saveaasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.saveaasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveaasToolStripMenuItem.Text = "Save &As";
            this.saveaasToolStripMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuRecentFiles
            // 
            this.mnuRecentFiles.Name = "mnuRecentFiles";
            this.mnuRecentFiles.Size = new System.Drawing.Size(186, 22);
            this.mnuRecentFiles.Text = "Recent Files";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsToolStripMenuItem,
            this.toolStripSeparator5,
            this.mnuResetApplication,
            this.mnuDefaultWindow,
            this.defaltProductInformationToolStripMenuItem});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(61, 20);
            this.mnuOptions.Text = "Options";
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.logsToolStripMenuItem.Text = "Logs Viewer";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.viewLogs_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(213, 6);
            // 
            // mnuResetApplication
            // 
            this.mnuResetApplication.Name = "mnuResetApplication";
            this.mnuResetApplication.Size = new System.Drawing.Size(216, 22);
            this.mnuResetApplication.Text = "Reset Application";
            this.mnuResetApplication.Click += new System.EventHandler(this.mnuResetApplication_Click);
            // 
            // mnuDefaultWindow
            // 
            this.mnuDefaultWindow.Name = "mnuDefaultWindow";
            this.mnuDefaultWindow.Size = new System.Drawing.Size(216, 22);
            this.mnuDefaultWindow.Text = "Use Defualt Layout";
            this.mnuDefaultWindow.ToolTipText = "Clear saved window layout to default window layout.";
            this.mnuDefaultWindow.Click += new System.EventHandler(this.mnuDefaultWindow_Click);
            // 
            // defaltProductInformationToolStripMenuItem
            // 
            this.defaltProductInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaveProductInformation,
            this.mnuClearProductInformation});
            this.defaltProductInformationToolStripMenuItem.Name = "defaltProductInformationToolStripMenuItem";
            this.defaltProductInformationToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.defaltProductInformationToolStripMenuItem.Text = "Defalt Product Information";
            this.defaltProductInformationToolStripMenuItem.Visible = false;
            // 
            // mnuSaveProductInformation
            // 
            this.mnuSaveProductInformation.Name = "mnuSaveProductInformation";
            this.mnuSaveProductInformation.Size = new System.Drawing.Size(212, 22);
            this.mnuSaveProductInformation.Text = "Save Product Information";
            this.mnuSaveProductInformation.Click += new System.EventHandler(this.mnuSaveProductInformation_Click);
            // 
            // mnuClearProductInformation
            // 
            this.mnuClearProductInformation.Name = "mnuClearProductInformation";
            this.mnuClearProductInformation.Size = new System.Drawing.Size(212, 22);
            this.mnuClearProductInformation.Text = "Clear Product Information";
            this.mnuClearProductInformation.Click += new System.EventHandler(this.mnuClearProductInformation_Click);
            // 
            // buildMainToolStripMenuItem
            // 
            this.buildMainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem,
            this.runToolStripMenuItem,
            this.toolStripSeparator3,
            this.mnuBuildPathFile,
            this.mnuInstallPatchFile,
            this.toolStripSeparator6,
            this.summaryToolStripMenuItem1,
            this.addRemoveProgramsToolStripMenuItem});
            this.buildMainToolStripMenuItem.Name = "buildMainToolStripMenuItem";
            this.buildMainToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.buildMainToolStripMenuItem.Text = "Project";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.buildToolStripMenuItem.Text = "Build MSI File";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.BuildMSI_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.runToolStripMenuItem.Text = "Install MSI File";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.InstallMSI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // mnuBuildPathFile
            // 
            this.mnuBuildPathFile.Name = "mnuBuildPathFile";
            this.mnuBuildPathFile.Size = new System.Drawing.Size(198, 22);
            this.mnuBuildPathFile.Text = "Build Path File";
            this.mnuBuildPathFile.Visible = false;
            this.mnuBuildPathFile.Click += new System.EventHandler(this.BuildPathFile_Click);
            // 
            // mnuInstallPatchFile
            // 
            this.mnuInstallPatchFile.Name = "mnuInstallPatchFile";
            this.mnuInstallPatchFile.Size = new System.Drawing.Size(198, 22);
            this.mnuInstallPatchFile.Text = "Install Patch File";
            this.mnuInstallPatchFile.Visible = false;
            this.mnuInstallPatchFile.Click += new System.EventHandler(this.InstallPatchFile_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(195, 6);
            // 
            // summaryToolStripMenuItem1
            // 
            this.summaryToolStripMenuItem1.Name = "summaryToolStripMenuItem1";
            this.summaryToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.summaryToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.summaryToolStripMenuItem1.Text = "Summary";
            this.summaryToolStripMenuItem1.Click += new System.EventHandler(this.summary_Click);
            // 
            // addRemoveProgramsToolStripMenuItem
            // 
            this.addRemoveProgramsToolStripMenuItem.Name = "addRemoveProgramsToolStripMenuItem";
            this.addRemoveProgramsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addRemoveProgramsToolStripMenuItem.Text = "Add/Remove Programs";
            this.addRemoveProgramsToolStripMenuItem.Click += new System.EventHandler(this.addRemovePrograms_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnuSamples,
            this.toolStripSeparator4,
            this.mnuRegister,
            this.mnuTermsAndConditions,
            this.mnuAboutNvnInstaller});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(193, 22);
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuSamples
            // 
            this.mnuSamples.Name = "mnuSamples";
            this.mnuSamples.Size = new System.Drawing.Size(193, 22);
            this.mnuSamples.Text = "Samples";
            this.mnuSamples.Visible = false;
            this.mnuSamples.Click += new System.EventHandler(this.mnuSamples_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuRegister
            // 
            this.mnuRegister.Name = "mnuRegister";
            this.mnuRegister.Size = new System.Drawing.Size(193, 22);
            this.mnuRegister.Text = "Register";
            this.mnuRegister.Click += new System.EventHandler(this.mnuRegister_Click);
            // 
            // mnuTermsAndConditions
            // 
            this.mnuTermsAndConditions.Name = "mnuTermsAndConditions";
            this.mnuTermsAndConditions.Size = new System.Drawing.Size(193, 22);
            this.mnuTermsAndConditions.Text = "Terms And Conditions";
            this.mnuTermsAndConditions.Click += new System.EventHandler(this.mnuTermsAndConditions_Click);
            // 
            // mnuAboutNvnInstaller
            // 
            this.mnuAboutNvnInstaller.Name = "mnuAboutNvnInstaller";
            this.mnuAboutNvnInstaller.Size = new System.Drawing.Size(193, 22);
            this.mnuAboutNvnInstaller.Text = "About Nvn Installer";
            this.mnuAboutNvnInstaller.Click += new System.EventHandler(this.mnuAboutNvnInstaller_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(0, 52);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lblApplicationCategory);
            this.splitContainerMain.Panel1.Controls.Add(this.lblVersion);
            this.splitContainerMain.Panel1.Controls.Add(this.lblApplicationName);
            this.splitContainerMain.Panel1.Controls.Add(this.pictureBox);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonsControl1);
            this.splitContainerMain.Size = new System.Drawing.Size(1115, 655);
            this.splitContainerMain.SplitterDistance = 256;
            this.splitContainerMain.TabIndex = 1;
            // 
            // lblApplicationCategory
            // 
            this.lblApplicationCategory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblApplicationCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblApplicationCategory.Location = new System.Drawing.Point(78, 634);
            this.lblApplicationCategory.Name = "lblApplicationCategory";
            this.lblApplicationCategory.Size = new System.Drawing.Size(60, 13);
            this.lblApplicationCategory.TabIndex = 4;
            this.lblApplicationCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(138, 636);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.Location = new System.Drawing.Point(59, 605);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(158, 29);
            this.lblApplicationName.TabIndex = 2;
            this.lblApplicationName.Text = "Nvn Installer";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox.Location = new System.Drawing.Point(3, 602);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(50, 50);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // buttonsControl1
            // 
            this.buttonsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsControl1.Location = new System.Drawing.Point(3, 3);
            this.buttonsControl1.Name = "buttonsControl1";
            this.buttonsControl1.Size = new System.Drawing.Size(250, 271);
            this.buttonsControl1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator9,
            this.btnRun,
            this.toolStripSeparator10,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1115, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.New_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.Open_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRun
            // 
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(23, 22);
            this.btnRun.Text = "Build";
            this.btnRun.Click += new System.EventHandler(this.BuildMSI_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 707);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nvn Installer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveaasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuDefaultWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem addRemoveProgramsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private ButtonsControl buttonsControl1;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuTermsAndConditions;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutNvnInstaller;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuRegister;
        private System.Windows.Forms.ToolStripMenuItem mnuSamples;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem defaltProductInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveProductInformation;
        private System.Windows.Forms.ToolStripMenuItem mnuClearProductInformation;
        private System.Windows.Forms.ToolStripMenuItem mnuResetApplication;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.Label lblApplicationCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildPathFile;
        private System.Windows.Forms.ToolStripMenuItem mnuInstallPatchFile;
    }
}

