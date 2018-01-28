namespace NvnInstaller
{
    partial class WindowExplorerControl
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
            this.splitContainerWindowsControl = new System.Windows.Forms.SplitContainer();
            this.tvDirectories = new System.Windows.Forms.TreeView();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.nameColumn = new System.Windows.Forms.ColumnHeader();
            this.sizeColumn = new System.Windows.Forms.ColumnHeader();
            this.dateCreatedColumn = new System.Windows.Forms.ColumnHeader();
            this.dateModifiedColumn = new System.Windows.Forms.ColumnHeader();
            this.splitContainerWindowsControl.Panel1.SuspendLayout();
            this.splitContainerWindowsControl.Panel2.SuspendLayout();
            this.splitContainerWindowsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerWindowsControl
            // 
            this.splitContainerWindowsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWindowsControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWindowsControl.Name = "splitContainerWindowsControl";
            // 
            // splitContainerWindowsControl.Panel1
            // 
            this.splitContainerWindowsControl.Panel1.Controls.Add(this.tvDirectories);
            // 
            // splitContainerWindowsControl.Panel2
            // 
            this.splitContainerWindowsControl.Panel2.Controls.Add(this.lvFiles);
            this.splitContainerWindowsControl.Size = new System.Drawing.Size(780, 470);
            this.splitContainerWindowsControl.SplitterDistance = 303;
            this.splitContainerWindowsControl.TabIndex = 0;
            // 
            // tvDirectories
            // 
            this.tvDirectories.AllowDrop = true;
            this.tvDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectories.HideSelection = false;
            this.tvDirectories.Location = new System.Drawing.Point(0, 0);
            this.tvDirectories.Name = "tvDirectories";
            this.tvDirectories.Size = new System.Drawing.Size(303, 470);
            this.tvDirectories.TabIndex = 0;
            this.tvDirectories.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvDirectories_BeforeExpand);
            this.tvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectories_AfterSelect);
            this.tvDirectories.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvDirectories_DragEnter);
            this.tvDirectories.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvDirectories_ItemDrag);
            // 
            // lvFiles
            // 
            this.lvFiles.AllowDrop = true;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.sizeColumn,
            this.dateCreatedColumn,
            this.dateModifiedColumn});
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.LabelWrap = false;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(473, 470);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DoubleClick += new System.EventHandler(this.lvFiles_DoubleClick);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            this.lvFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvFiles_ItemDrag);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 100;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            // 
            // dateCreatedColumn
            // 
            this.dateCreatedColumn.Text = "Date Created";
            // 
            // dateModifiedColumn
            // 
            this.dateModifiedColumn.Text = "Date Modified";
            // 
            // WindowExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerWindowsControl);
            this.Name = "WindowExplorerControl";
            this.Size = new System.Drawing.Size(780, 470);
            this.Load += new System.EventHandler(this.WindowExplorerControl_Load);
            this.splitContainerWindowsControl.Panel1.ResumeLayout(false);
            this.splitContainerWindowsControl.Panel2.ResumeLayout(false);
            this.splitContainerWindowsControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerWindowsControl;
        private System.Windows.Forms.TreeView tvDirectories;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader dateCreatedColumn;
        private System.Windows.Forms.ColumnHeader dateModifiedColumn;
    }
}
