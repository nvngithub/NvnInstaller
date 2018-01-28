namespace NvnInstaller.Scheduler {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStartBuildScheduler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopBuildScheduler = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startBuildSchedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBuildSchedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildSchedulerControl2 = new NvnInstaller.Scheduler.BuildSchedulerControl();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.toolStripSeparator1,
            this.mnuStartBuildScheduler,
            this.mnuStopBuildScheduler,
            this.toolStripSeparator2,
            this.mnuClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(184, 104);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(183, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuStartBuildScheduler
            // 
            this.mnuStartBuildScheduler.Name = "mnuStartBuildScheduler";
            this.mnuStartBuildScheduler.Size = new System.Drawing.Size(183, 22);
            this.mnuStartBuildScheduler.Text = "Start Build Scheduler";
            this.mnuStartBuildScheduler.Click += new System.EventHandler(this.mnuStartBuildScheduler_Click);
            // 
            // mnuStopBuildScheduler
            // 
            this.mnuStopBuildScheduler.Name = "mnuStopBuildScheduler";
            this.mnuStopBuildScheduler.Size = new System.Drawing.Size(183, 22);
            this.mnuStopBuildScheduler.Text = "Stop Build Scheduler";
            this.mnuStopBuildScheduler.Click += new System.EventHandler(this.mnuStopBuildScheduler_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(183, 22);
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Nvn Installer Build Scheduler";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(775, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBuildSchedulerToolStripMenuItem,
            this.stopBuildSchedulerToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // startBuildSchedulerToolStripMenuItem
            // 
            this.startBuildSchedulerToolStripMenuItem.Name = "startBuildSchedulerToolStripMenuItem";
            this.startBuildSchedulerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.startBuildSchedulerToolStripMenuItem.Text = "Start Build Scheduler";
            this.startBuildSchedulerToolStripMenuItem.Click += new System.EventHandler(this.mnuStartBuildScheduler_Click);
            // 
            // stopBuildSchedulerToolStripMenuItem
            // 
            this.stopBuildSchedulerToolStripMenuItem.Name = "stopBuildSchedulerToolStripMenuItem";
            this.stopBuildSchedulerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.stopBuildSchedulerToolStripMenuItem.Text = "Stop Build Scheduler";
            this.stopBuildSchedulerToolStripMenuItem.Click += new System.EventHandler(this.mnuStopBuildScheduler_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // buildSchedulerControl2
            // 
            this.buildSchedulerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildSchedulerControl2.Location = new System.Drawing.Point(0, 24);
            this.buildSchedulerControl2.Name = "buildSchedulerControl2";
            this.buildSchedulerControl2.Size = new System.Drawing.Size(775, 529);
            this.buildSchedulerControl2.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 553);
            this.Controls.Add(this.buildSchedulerControl2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Build Scheduler";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuStartBuildScheduler;
        private System.Windows.Forms.ToolStripMenuItem mnuStopBuildScheduler;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private BuildSchedulerControl buildSchedulerControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startBuildSchedulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBuildSchedulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private BuildSchedulerControl buildSchedulerControl2;
    }
}