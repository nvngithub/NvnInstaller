namespace NvnInstaller
{
    partial class FileAssociationControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrExtensions = new System.Windows.Forms.DataGridView();
            this.indexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrowseColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrExtensions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrExtensions
            // 
            this.dgrExtensions.AllowUserToAddRows = false;
            this.dgrExtensions.AllowUserToDeleteRows = false;
            this.dgrExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrExtensions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrExtensions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexColumn,
            this.extensionColumn,
            this.DescriptionColumn,
            this.applicationColumn,
            this.BrowseColumn,
            this.deleteColumn,
            this.IdColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrExtensions.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrExtensions.Location = new System.Drawing.Point(3, 19);
            this.dgrExtensions.Name = "dgrExtensions";
            this.dgrExtensions.RowHeadersVisible = false;
            this.dgrExtensions.Size = new System.Drawing.Size(594, 181);
            this.dgrExtensions.TabIndex = 18;
            this.dgrExtensions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrExtensions_CellContentClick);
            // 
            // indexColumn
            // 
            this.indexColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.indexColumn.FillWeight = 63.196F;
            this.indexColumn.HeaderText = "Index";
            this.indexColumn.Name = "indexColumn";
            this.indexColumn.ReadOnly = true;
            this.indexColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.indexColumn.Width = 50;
            // 
            // extensionColumn
            // 
            this.extensionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.extensionColumn.FillWeight = 88.02254F;
            this.extensionColumn.HeaderText = "Extension";
            this.extensionColumn.Name = "extensionColumn";
            this.extensionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.FillWeight = 191.6945F;
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // applicationColumn
            // 
            this.applicationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.applicationColumn.FillWeight = 80.94476F;
            this.applicationColumn.HeaderText = "Application";
            this.applicationColumn.Name = "applicationColumn";
            this.applicationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.applicationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.applicationColumn.Width = 150;
            // 
            // BrowseColumn
            // 
            this.BrowseColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BrowseColumn.HeaderText = "";
            this.BrowseColumn.Name = "BrowseColumn";
            this.BrowseColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrowseColumn.Width = 60;
            // 
            // deleteColumn
            // 
            this.deleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteColumn.FillWeight = 76.14214F;
            this.deleteColumn.HeaderText = "Delete";
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deleteColumn.Width = 60;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Extensions";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 206);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "New Extension";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FileAssociationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgrExtensions);
            this.Controls.Add(this.label4);
            this.Name = "FileAssociationControl";
            this.Size = new System.Drawing.Size(610, 347);
            ((System.ComponentModel.ISupportInitialize)(this.dgrExtensions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrExtensions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn applicationColumn;
        private System.Windows.Forms.DataGridViewButtonColumn BrowseColumn;
        private System.Windows.Forms.DataGridViewLinkColumn deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
    }
}
