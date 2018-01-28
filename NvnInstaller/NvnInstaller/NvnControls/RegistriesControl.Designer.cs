namespace NvnInstaller
{
    partial class RegistriesControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistriesControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("HKEY_CLASSES_ROOT");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_USER");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("HKEY_LOCAL_MACHINE");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("HKEY_USERS");
            this.cmsRegistries = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmsRegistry2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integerValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandableStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.registriesCompleteSplitter = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.tvRegistries = new System.Windows.Forms.TreeView();
            this.registriesPropertiesSplitter = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRegistries = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pgRegistry = new System.Windows.Forms.PropertyGrid();
            this.cmsRegistries.SuspendLayout();
            this.cmsRegistry2.SuspendLayout();
            this.registriesCompleteSplitter.Panel1.SuspendLayout();
            this.registriesCompleteSplitter.Panel2.SuspendLayout();
            this.registriesCompleteSplitter.SuspendLayout();
            this.registriesPropertiesSplitter.Panel1.SuspendLayout();
            this.registriesPropertiesSplitter.Panel2.SuspendLayout();
            this.registriesPropertiesSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsRegistries
            // 
            this.cmsRegistries.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeyToolStripMenuItem,
            this.toolStripSeparator6,
            this.editToolStripMenuItem2,
            this.deleteToolStripMenuItem2});
            this.cmsRegistries.Name = "cmsRegistries";
            this.cmsRegistries.Size = new System.Drawing.Size(119, 76);
            // 
            // addKeyToolStripMenuItem
            // 
            this.addKeyToolStripMenuItem.Name = "addKeyToolStripMenuItem";
            this.addKeyToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.addKeyToolStripMenuItem.Text = "Add Key";
            this.addKeyToolStripMenuItem.Click += new System.EventHandler(this.addKey_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(115, 6);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.editToolStripMenuItem2.Text = "Edit";
            this.editToolStripMenuItem2.Click += new System.EventHandler(this.edit_Registry_Click);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.delete_Registry_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FolderClosed.bmp");
            this.imageList.Images.SetKeyName(1, "File.bmp");
            // 
            // cmsRegistry2
            // 
            this.cmsRegistry2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addValueToolStripMenuItem});
            this.cmsRegistry2.Name = "contextMenuStrip1";
            this.cmsRegistry2.Size = new System.Drawing.Size(129, 26);
            // 
            // addValueToolStripMenuItem
            // 
            this.addValueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binaryValueToolStripMenuItem,
            this.integerValueToolStripMenuItem,
            this.stringValueToolStripMenuItem,
            this.multipleStringValueToolStripMenuItem,
            this.expandableStringToolStripMenuItem});
            this.addValueToolStripMenuItem.Name = "addValueToolStripMenuItem";
            this.addValueToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addValueToolStripMenuItem.Text = "Add Value";
            // 
            // binaryValueToolStripMenuItem
            // 
            this.binaryValueToolStripMenuItem.Name = "binaryValueToolStripMenuItem";
            this.binaryValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.binaryValueToolStripMenuItem.Text = "Binary Value";
            this.binaryValueToolStripMenuItem.Click += new System.EventHandler(this.binaryValue_Click);
            // 
            // integerValueToolStripMenuItem
            // 
            this.integerValueToolStripMenuItem.Name = "integerValueToolStripMenuItem";
            this.integerValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.integerValueToolStripMenuItem.Text = "Integer Value";
            this.integerValueToolStripMenuItem.Click += new System.EventHandler(this.IntegerValue_Click);
            // 
            // stringValueToolStripMenuItem
            // 
            this.stringValueToolStripMenuItem.Name = "stringValueToolStripMenuItem";
            this.stringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.stringValueToolStripMenuItem.Text = "String Value";
            this.stringValueToolStripMenuItem.Click += new System.EventHandler(this.stringValue_Click);
            // 
            // multipleStringValueToolStripMenuItem
            // 
            this.multipleStringValueToolStripMenuItem.Name = "multipleStringValueToolStripMenuItem";
            this.multipleStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.multipleStringValueToolStripMenuItem.Text = "Multiple String Value";
            this.multipleStringValueToolStripMenuItem.Click += new System.EventHandler(this.multipleStringValue_Click);
            // 
            // expandableStringToolStripMenuItem
            // 
            this.expandableStringToolStripMenuItem.Name = "expandableStringToolStripMenuItem";
            this.expandableStringToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.expandableStringToolStripMenuItem.Text = "Expandable String Value";
            this.expandableStringToolStripMenuItem.Click += new System.EventHandler(this.ExpandableString_Click);
            // 
            // registriesCompleteSplitter
            // 
            this.registriesCompleteSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registriesCompleteSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.registriesCompleteSplitter.Location = new System.Drawing.Point(0, 0);
            this.registriesCompleteSplitter.Name = "registriesCompleteSplitter";
            // 
            // registriesCompleteSplitter.Panel1
            // 
            this.registriesCompleteSplitter.Panel1.Controls.Add(this.label2);
            this.registriesCompleteSplitter.Panel1.Controls.Add(this.tvRegistries);
            // 
            // registriesCompleteSplitter.Panel2
            // 
            this.registriesCompleteSplitter.Panel2.Controls.Add(this.registriesPropertiesSplitter);
            this.registriesCompleteSplitter.Size = new System.Drawing.Size(619, 378);
            this.registriesCompleteSplitter.SplitterDistance = 232;
            this.registriesCompleteSplitter.TabIndex = 2;
            this.registriesCompleteSplitter.SizeChanged += new System.EventHandler(this.Splitter_SizeChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Registry keys";
            // 
            // tvRegistries
            // 
            this.tvRegistries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRegistries.ContextMenuStrip = this.cmsRegistries;
            this.tvRegistries.ImageIndex = 0;
            this.tvRegistries.ImageList = this.imageList;
            this.tvRegistries.LabelEdit = true;
            this.tvRegistries.Location = new System.Drawing.Point(3, 21);
            this.tvRegistries.Name = "tvRegistries";
            treeNode1.Name = "Node0";
            treeNode1.Text = "HKEY_CLASSES_ROOT";
            treeNode2.Name = "Node1";
            treeNode2.Text = "HKEY_CURRENT_USER";
            treeNode3.Name = "Node2";
            treeNode3.Text = "HKEY_LOCAL_MACHINE";
            treeNode4.Name = "Node3";
            treeNode4.Text = "HKEY_USERS";
            this.tvRegistries.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.tvRegistries.SelectedImageIndex = 0;
            this.tvRegistries.Size = new System.Drawing.Size(227, 354);
            this.tvRegistries.TabIndex = 1;
            this.tvRegistries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvRegistries_MouseClick);
            this.tvRegistries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRegistries_AfterSelect);
            this.tvRegistries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvRegistries_KeyDown);
            // 
            // registriesPropertiesSplitter
            // 
            this.registriesPropertiesSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registriesPropertiesSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.registriesPropertiesSplitter.Location = new System.Drawing.Point(0, 0);
            this.registriesPropertiesSplitter.Name = "registriesPropertiesSplitter";
            // 
            // registriesPropertiesSplitter.Panel1
            // 
            this.registriesPropertiesSplitter.Panel1.Controls.Add(this.label1);
            this.registriesPropertiesSplitter.Panel1.Controls.Add(this.lstRegistries);
            // 
            // registriesPropertiesSplitter.Panel2
            // 
            this.registriesPropertiesSplitter.Panel2.Controls.Add(this.label3);
            this.registriesPropertiesSplitter.Panel2.Controls.Add(this.pgRegistry);
            this.registriesPropertiesSplitter.Size = new System.Drawing.Size(383, 378);
            this.registriesPropertiesSplitter.SplitterDistance = 174;
            this.registriesPropertiesSplitter.TabIndex = 0;
            this.registriesPropertiesSplitter.SizeChanged += new System.EventHandler(this.Splitter_SizeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registry values";
            // 
            // lstRegistries
            // 
            this.lstRegistries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRegistries.ContextMenuStrip = this.cmsRegistry2;
            this.lstRegistries.DisplayMember = "Name";
            this.lstRegistries.FormattingEnabled = true;
            this.lstRegistries.Location = new System.Drawing.Point(0, 21);
            this.lstRegistries.Name = "lstRegistries";
            this.lstRegistries.Size = new System.Drawing.Size(174, 355);
            this.lstRegistries.TabIndex = 0;
            this.lstRegistries.SelectedIndexChanged += new System.EventHandler(this.lstRegistries_SelectedIndexChanged);
            this.lstRegistries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstRegistries_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Properties";
            // 
            // pgRegistry
            // 
            this.pgRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgRegistry.Location = new System.Drawing.Point(0, 21);
            this.pgRegistry.Name = "pgRegistry";
            this.pgRegistry.Size = new System.Drawing.Size(205, 354);
            this.pgRegistry.TabIndex = 0;
            this.pgRegistry.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgRegistry_PropertyValueChanged);
            // 
            // RegistriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.registriesCompleteSplitter);
            this.Name = "RegistriesControl";
            this.Size = new System.Drawing.Size(619, 378);
            this.cmsRegistries.ResumeLayout(false);
            this.cmsRegistry2.ResumeLayout(false);
            this.registriesCompleteSplitter.Panel1.ResumeLayout(false);
            this.registriesCompleteSplitter.Panel1.PerformLayout();
            this.registriesCompleteSplitter.Panel2.ResumeLayout(false);
            this.registriesCompleteSplitter.ResumeLayout(false);
            this.registriesPropertiesSplitter.Panel1.ResumeLayout(false);
            this.registriesPropertiesSplitter.Panel1.PerformLayout();
            this.registriesPropertiesSplitter.Panel2.ResumeLayout(false);
            this.registriesPropertiesSplitter.Panel2.PerformLayout();
            this.registriesPropertiesSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip cmsRegistries;
        private System.Windows.Forms.ToolStripMenuItem addKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip cmsRegistry2;
        private System.Windows.Forms.ToolStripMenuItem addValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleStringValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandableStringToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer registriesCompleteSplitter;
        private System.Windows.Forms.TreeView tvRegistries;
        private System.Windows.Forms.SplitContainer registriesPropertiesSplitter;
        private System.Windows.Forms.ListBox lstRegistries;
        private System.Windows.Forms.PropertyGrid pgRegistry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem integerValueToolStripMenuItem;
    }
}
