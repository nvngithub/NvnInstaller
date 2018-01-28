namespace NvnInstaller
{
    partial class UserInterfaceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterfaceControl));
            this.tabUserInterface = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lnkDefaultDialog = new System.Windows.Forms.LinkLabel();
            this.lnkDefaultBanner = new System.Windows.Forms.LinkLabel();
            this.btnBrowseDialog = new System.Windows.Forms.Button();
            this.btnBrowseBanner = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDialog = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBanner = new System.Windows.Forms.TextBox();
            this.rbFeatureTree = new System.Windows.Forms.RadioButton();
            this.rbInstall = new System.Windows.Forms.RadioButton();
            this.rbMinimal = new System.Windows.Forms.RadioButton();
            this.rbComplete = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRestoreAll = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lstDialogs = new System.Windows.Forms.ListBox();
            this.viewUIControl = new NvnInstaller.ViewUIControl();
            this.tabUserInterface.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUserInterface
            // 
            this.tabUserInterface.Controls.Add(this.tabPage1);
            this.tabUserInterface.Controls.Add(this.tabPage2);
            this.tabUserInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserInterface.ItemSize = new System.Drawing.Size(100, 20);
            this.tabUserInterface.Location = new System.Drawing.Point(0, 0);
            this.tabUserInterface.Name = "tabUserInterface";
            this.tabUserInterface.SelectedIndex = 0;
            this.tabUserInterface.Size = new System.Drawing.Size(745, 714);
            this.tabUserInterface.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabUserInterface.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.viewUIControl);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(737, 686);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lnkDefaultDialog);
            this.groupBox3.Controls.Add(this.lnkDefaultBanner);
            this.groupBox3.Controls.Add(this.btnBrowseDialog);
            this.groupBox3.Controls.Add(this.btnBrowseBanner);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtDialog);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtBanner);
            this.groupBox3.Controls.Add(this.rbFeatureTree);
            this.groupBox3.Controls.Add(this.rbInstall);
            this.groupBox3.Controls.Add(this.rbMinimal);
            this.groupBox3.Controls.Add(this.rbComplete);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 103);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User interface type";
            // 
            // lnkDefaultDialog
            // 
            this.lnkDefaultDialog.AutoSize = true;
            this.lnkDefaultDialog.Location = new System.Drawing.Point(453, 75);
            this.lnkDefaultDialog.Name = "lnkDefaultDialog";
            this.lnkDefaultDialog.Size = new System.Drawing.Size(63, 13);
            this.lnkDefaultDialog.TabIndex = 25;
            this.lnkDefaultDialog.TabStop = true;
            this.lnkDefaultDialog.Text = "Use Default";
            this.lnkDefaultDialog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefaultDialog_LinkClicked);
            // 
            // lnkDefaultBanner
            // 
            this.lnkDefaultBanner.AutoSize = true;
            this.lnkDefaultBanner.Location = new System.Drawing.Point(453, 47);
            this.lnkDefaultBanner.Name = "lnkDefaultBanner";
            this.lnkDefaultBanner.Size = new System.Drawing.Size(63, 13);
            this.lnkDefaultBanner.TabIndex = 24;
            this.lnkDefaultBanner.TabStop = true;
            this.lnkDefaultBanner.Text = "Use Default";
            this.lnkDefaultBanner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefaultBanner_LinkClicked);
            // 
            // btnBrowseDialog
            // 
            this.btnBrowseDialog.Location = new System.Drawing.Point(372, 70);
            this.btnBrowseDialog.Name = "btnBrowseDialog";
            this.btnBrowseDialog.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDialog.TabIndex = 22;
            this.btnBrowseDialog.Text = "Browse...";
            this.btnBrowseDialog.UseVisualStyleBackColor = true;
            this.btnBrowseDialog.Click += new System.EventHandler(this.btnBrowseDialog_Click);
            // 
            // btnBrowseBanner
            // 
            this.btnBrowseBanner.Location = new System.Drawing.Point(372, 42);
            this.btnBrowseBanner.Name = "btnBrowseBanner";
            this.btnBrowseBanner.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBanner.TabIndex = 21;
            this.btnBrowseBanner.Text = "Browse...";
            this.btnBrowseBanner.UseVisualStyleBackColor = true;
            this.btnBrowseBanner.Click += new System.EventHandler(this.btnBrowseBanner_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Dialog image";
            // 
            // txtDialog
            // 
            this.txtDialog.Location = new System.Drawing.Point(84, 73);
            this.txtDialog.Name = "txtDialog";
            this.txtDialog.Size = new System.Drawing.Size(282, 20);
            this.txtDialog.TabIndex = 19;
            this.txtDialog.Text = "Bitmaps\\Dialog.bmp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Banner image";
            // 
            // txtBanner
            // 
            this.txtBanner.Location = new System.Drawing.Point(84, 44);
            this.txtBanner.Name = "txtBanner";
            this.txtBanner.Size = new System.Drawing.Size(282, 20);
            this.txtBanner.TabIndex = 17;
            this.txtBanner.Text = "Bitmaps\\Banner.bmp";
            // 
            // rbFeatureTree
            // 
            this.rbFeatureTree.AutoSize = true;
            this.rbFeatureTree.Location = new System.Drawing.Point(126, 19);
            this.rbFeatureTree.Name = "rbFeatureTree";
            this.rbFeatureTree.Size = new System.Drawing.Size(86, 17);
            this.rbFeatureTree.TabIndex = 3;
            this.rbFeatureTree.Text = "Feature Tree";
            this.rbFeatureTree.UseVisualStyleBackColor = true;
            this.rbFeatureTree.CheckedChanged += new System.EventHandler(this.rbFeatureTree_CheckedChanged);
            // 
            // rbInstall
            // 
            this.rbInstall.AutoSize = true;
            this.rbInstall.Location = new System.Drawing.Point(218, 19);
            this.rbInstall.Name = "rbInstall";
            this.rbInstall.Size = new System.Drawing.Size(85, 17);
            this.rbInstall.TabIndex = 2;
            this.rbInstall.Text = "Install wizard";
            this.rbInstall.UseVisualStyleBackColor = true;
            this.rbInstall.CheckedChanged += new System.EventHandler(this.rbInstall_CheckedChanged);
            // 
            // rbMinimal
            // 
            this.rbMinimal.AutoSize = true;
            this.rbMinimal.Location = new System.Drawing.Point(309, 19);
            this.rbMinimal.Name = "rbMinimal";
            this.rbMinimal.Size = new System.Drawing.Size(60, 17);
            this.rbMinimal.TabIndex = 1;
            this.rbMinimal.Text = "Minimal";
            this.rbMinimal.UseVisualStyleBackColor = true;
            this.rbMinimal.CheckedChanged += new System.EventHandler(this.rbMinimal_CheckedChanged);
            // 
            // rbComplete
            // 
            this.rbComplete.AutoSize = true;
            this.rbComplete.Checked = true;
            this.rbComplete.Location = new System.Drawing.Point(6, 19);
            this.rbComplete.Name = "rbComplete";
            this.rbComplete.Size = new System.Drawing.Size(114, 17);
            this.rbComplete.TabIndex = 0;
            this.rbComplete.TabStop = true;
            this.rbComplete.Text = "Complete Interface";
            this.rbComplete.UseVisualStyleBackColor = true;
            this.rbComplete.CheckedChanged += new System.EventHandler(this.rbComplete_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(3, 580);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(731, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Button Labels";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRestoreAll);
            this.tabPage2.Controls.Add(this.btnRestore);
            this.tabPage2.Controls.Add(this.splitContainer);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(737, 686);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Customization";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreAll.Location = new System.Drawing.Point(619, 532);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(115, 23);
            this.btnRestoreAll.TabIndex = 2;
            this.btnRestoreAll.Text = "Restore Default (All)";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.btnRestoreAll_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(506, 532);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(107, 23);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Restore Default";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lstDialogs);
            this.splitContainer.Size = new System.Drawing.Size(737, 526);
            this.splitContainer.SplitterDistance = 168;
            this.splitContainer.TabIndex = 0;
            // 
            // lstDialogs
            // 
            this.lstDialogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDialogs.FormattingEnabled = true;
            this.lstDialogs.Location = new System.Drawing.Point(0, 0);
            this.lstDialogs.Name = "lstDialogs";
            this.lstDialogs.Size = new System.Drawing.Size(168, 524);
            this.lstDialogs.TabIndex = 0;
            this.lstDialogs.SelectedIndexChanged += new System.EventHandler(this.lstDialogs_SelectedIndexChanged);
            // 
            // viewUIControl
            // 
            this.viewUIControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewUIControl.Dialogs = ((System.Collections.Generic.List<string>)(resources.GetObject("viewUIControl.Dialogs")));
            this.viewUIControl.Location = new System.Drawing.Point(3, 112);
            this.viewUIControl.Name = "viewUIControl";
            this.viewUIControl.Size = new System.Drawing.Size(493, 370);
            this.viewUIControl.TabIndex = 54;
            // 
            // UserInterfaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabUserInterface);
            this.Name = "UserInterfaceControl";
            this.Size = new System.Drawing.Size(745, 714);
            this.tabUserInterface.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserInterface;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox lstDialogs;
        private System.Windows.Forms.Button btnRestoreAll;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel lnkDefaultDialog;
        private System.Windows.Forms.LinkLabel lnkDefaultBanner;
        private System.Windows.Forms.Button btnBrowseDialog;
        private System.Windows.Forms.Button btnBrowseBanner;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox txtDialog;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtBanner;
        private System.Windows.Forms.RadioButton rbFeatureTree;
        private System.Windows.Forms.RadioButton rbInstall;
        private System.Windows.Forms.RadioButton rbMinimal;
        private System.Windows.Forms.RadioButton rbComplete;
        private ViewUIControl viewUIControl;

    }
}
