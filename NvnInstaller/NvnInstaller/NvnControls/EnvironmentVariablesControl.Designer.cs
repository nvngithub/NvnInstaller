namespace NvnInstaller {
    partial class EnvironmentVariablesControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvironmentVariablesControl));
            this.label1 = new System.Windows.Forms.Label();
            this.dgrExistingEnvironmentVariables = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNewEnvironmentVariable1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteSelectedItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearAll1 = new System.Windows.Forms.ToolStripMenuItem();
            this.environmentVaribaleItems = new NvnInstaller.GridItemsControl();
            this.btnAddNewEnvironmentVariable = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.mnuSaveSelectedEnvironmentVariable = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgrExistingEnvironmentVariables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrProperties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Environment variables in your system";
            // 
            // dgrExistingEnvironmentVariables
            // 
            this.dgrExistingEnvironmentVariables.AllowUserToAddRows = false;
            this.dgrExistingEnvironmentVariables.AllowUserToDeleteRows = false;
            this.dgrExistingEnvironmentVariables.AllowUserToResizeRows = false;
            this.dgrExistingEnvironmentVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrExistingEnvironmentVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrExistingEnvironmentVariables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrExistingEnvironmentVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrExistingEnvironmentVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ValueColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrExistingEnvironmentVariables.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrExistingEnvironmentVariables.Location = new System.Drawing.Point(31, 254);
            this.dgrExistingEnvironmentVariables.Name = "dgrExistingEnvironmentVariables";
            this.dgrExistingEnvironmentVariables.RowHeadersVisible = false;
            this.dgrExistingEnvironmentVariables.Size = new System.Drawing.Size(699, 194);
            this.dgrExistingEnvironmentVariables.TabIndex = 5;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 60;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            // 
            // dgrProperties
            // 
            this.dgrProperties.AllowUserToAddRows = false;
            this.dgrProperties.AllowUserToDeleteRows = false;
            this.dgrProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgrProperties.Location = new System.Drawing.Point(298, 9);
            this.dgrProperties.Name = "dgrProperties";
            this.dgrProperties.RowHeadersVisible = false;
            this.dgrProperties.Size = new System.Drawing.Size(432, 178);
            this.dgrProperties.TabIndex = 74;
            this.dgrProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrProperties_CellValueChanged);
            this.dgrProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrProperties_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Property";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 71;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNewEnvironmentVariable1,
            this.mnuSaveSelectedEnvironmentVariable,
            this.mnuDeleteSelectedItem1,
            this.toolStripSeparator2,
            this.mnuClearAll1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(260, 120);
            // 
            // mnuAddNewEnvironmentVariable1
            // 
            this.mnuAddNewEnvironmentVariable1.Name = "mnuAddNewEnvironmentVariable1";
            this.mnuAddNewEnvironmentVariable1.Size = new System.Drawing.Size(259, 22);
            this.mnuAddNewEnvironmentVariable1.Text = "Add new environment variable";
            this.mnuAddNewEnvironmentVariable1.Click += new System.EventHandler(this.AddNewEnvironmentVariabe_Click);
            // 
            // mnuDeleteSelectedItem1
            // 
            this.mnuDeleteSelectedItem1.Name = "mnuDeleteSelectedItem1";
            this.mnuDeleteSelectedItem1.Size = new System.Drawing.Size(259, 22);
            this.mnuDeleteSelectedItem1.Text = "Delete selected item";
            this.mnuDeleteSelectedItem1.Click += new System.EventHandler(this.mnuDeletedSelectedItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(256, 6);
            // 
            // mnuClearAll1
            // 
            this.mnuClearAll1.Name = "mnuClearAll1";
            this.mnuClearAll1.Size = new System.Drawing.Size(259, 22);
            this.mnuClearAll1.Text = "Clear All";
            this.mnuClearAll1.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // environmentVaribaleItems
            // 
            this.environmentVaribaleItems.GridContextMenu = this.contextMenuStrip1;
            this.environmentVaribaleItems.Items = ((System.Collections.ArrayList)(resources.GetObject("environmentVaribaleItems.Items")));
            this.environmentVaribaleItems.Location = new System.Drawing.Point(3, 5);
            this.environmentVaribaleItems.Name = "environmentVaribaleItems";
            this.environmentVaribaleItems.Size = new System.Drawing.Size(289, 185);
            this.environmentVaribaleItems.TabIndex = 75;
            // 
            // btnAddNewEnvironmentVariable
            // 
            this.btnAddNewEnvironmentVariable.Location = new System.Drawing.Point(40, 196);
            this.btnAddNewEnvironmentVariable.Name = "btnAddNewEnvironmentVariable";
            this.btnAddNewEnvironmentVariable.Size = new System.Drawing.Size(168, 23);
            this.btnAddNewEnvironmentVariable.TabIndex = 76;
            this.btnAddNewEnvironmentVariable.Text = "Add New Environment Variable";
            this.btnAddNewEnvironmentVariable.UseVisualStyleBackColor = true;
            this.btnAddNewEnvironmentVariable.Click += new System.EventHandler(this.AddNewEnvironmentVariabe_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(214, 196);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 77;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveSelectedEnvironmentVariable_Click);
            // 
            // mnuSaveSelectedEnvironmentVariable
            // 
            this.mnuSaveSelectedEnvironmentVariable.Name = "mnuSaveSelectedEnvironmentVariable";
            this.mnuSaveSelectedEnvironmentVariable.Size = new System.Drawing.Size(259, 22);
            this.mnuSaveSelectedEnvironmentVariable.Text = "Save selected environment variable";
            this.mnuSaveSelectedEnvironmentVariable.Click += new System.EventHandler(this.SaveSelectedEnvironmentVariable_Click);
            // 
            // EnvironmentVariablesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNewEnvironmentVariable);
            this.Controls.Add(this.environmentVaribaleItems);
            this.Controls.Add(this.dgrProperties);
            this.Controls.Add(this.dgrExistingEnvironmentVariables);
            this.Controls.Add(this.label1);
            this.Name = "EnvironmentVariablesControl";
            this.Size = new System.Drawing.Size(794, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgrExistingEnvironmentVariables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrProperties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrExistingEnvironmentVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridView dgrProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private GridItemsControl environmentVaribaleItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewEnvironmentVariable1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSelectedItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll1;
        private System.Windows.Forms.Button btnAddNewEnvironmentVariable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveSelectedEnvironmentVariable;
    }
}
