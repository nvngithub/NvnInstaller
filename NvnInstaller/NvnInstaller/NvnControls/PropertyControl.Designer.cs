namespace NvnInstaller {
    partial class PropertyControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyControl));
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.lblCollapse = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSummaryControls = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgrPropertySearch = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNewProperty1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveSelectedProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteSelectedProperty1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearAllProperties1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewProperty = new System.Windows.Forms.Button();
            this.propertyItems = new NvnInstaller.GridItemsControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPropertySearch)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Location = new System.Drawing.Point(390, 34);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(283, 20);
            this.txtPropertyName.TabIndex = 2;
            this.txtPropertyName.TextChanged += new System.EventHandler(this.txtPropertyName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Property Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Default Value";
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(390, 86);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(283, 20);
            this.txtDefaultValue.TabIndex = 5;
            // 
            // lblCollapse
            // 
            this.lblCollapse.AutoSize = true;
            this.lblCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollapse.Location = new System.Drawing.Point(9, 303);
            this.lblCollapse.Name = "lblCollapse";
            this.lblCollapse.Size = new System.Drawing.Size(20, 25);
            this.lblCollapse.TabIndex = 7;
            this.lblCollapse.Text = "-";
            this.lblCollapse.Click += new System.EventHandler(this.lblCollapse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Windows Installer Property Reference";
            // 
            // pnlSummaryControls
            // 
            this.pnlSummaryControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummaryControls.AutoScroll = true;
            this.pnlSummaryControls.Location = new System.Drawing.Point(35, 333);
            this.pnlSummaryControls.Name = "pnlSummaryControls";
            this.pnlSummaryControls.Size = new System.Drawing.Size(1139, 204);
            this.pnlSummaryControls.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(390, 60);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(283, 20);
            this.txtDescription.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Description";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Location = new System.Drawing.Point(390, 138);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(283, 21);
            this.cmbSearchType.TabIndex = 79;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Search Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(313, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "Assign Property Value";
            // 
            // dgrPropertySearch
            // 
            this.dgrPropertySearch.AllowUserToAddRows = false;
            this.dgrPropertySearch.AllowUserToDeleteRows = false;
            this.dgrPropertySearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrPropertySearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrPropertySearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPropertySearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ValueColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrPropertySearch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrPropertySearch.Location = new System.Drawing.Point(319, 165);
            this.dgrPropertySearch.Name = "dgrPropertySearch";
            this.dgrPropertySearch.RowHeadersVisible = false;
            this.dgrPropertySearch.Size = new System.Drawing.Size(354, 104);
            this.dgrPropertySearch.TabIndex = 82;
            this.dgrPropertySearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrPropertySearch_CellClick);
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.NameColumn.FillWeight = 101.5228F;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.FillWeight = 98.47716F;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNewProperty1,
            this.mnuSaveSelectedProperty,
            this.mnuDeleteSelectedProperty1,
            this.toolStripSeparator2,
            this.mnuClearAllProperties1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 98);
            // 
            // mnuAddNewProperty1
            // 
            this.mnuAddNewProperty1.Name = "mnuAddNewProperty1";
            this.mnuAddNewProperty1.Size = new System.Drawing.Size(201, 22);
            this.mnuAddNewProperty1.Text = "Add new property";
            this.mnuAddNewProperty1.Click += new System.EventHandler(this.AddNewProperty_Click);
            // 
            // mnuSaveSelectedProperty
            // 
            this.mnuSaveSelectedProperty.Name = "mnuSaveSelectedProperty";
            this.mnuSaveSelectedProperty.Size = new System.Drawing.Size(201, 22);
            this.mnuSaveSelectedProperty.Text = "Save selected property";
            this.mnuSaveSelectedProperty.Click += new System.EventHandler(this.SaveSelectedProperty_Click);
            // 
            // mnuDeleteSelectedProperty1
            // 
            this.mnuDeleteSelectedProperty1.Name = "mnuDeleteSelectedProperty1";
            this.mnuDeleteSelectedProperty1.Size = new System.Drawing.Size(201, 22);
            this.mnuDeleteSelectedProperty1.Text = "Delete selected property";
            this.mnuDeleteSelectedProperty1.Click += new System.EventHandler(this.mnuDeleteSelectedProperty_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuClearAllProperties1
            // 
            this.mnuClearAllProperties1.Name = "mnuClearAllProperties1";
            this.mnuClearAllProperties1.Size = new System.Drawing.Size(201, 22);
            this.mnuClearAllProperties1.Text = "Clear all properties";
            this.mnuClearAllProperties1.Click += new System.EventHandler(this.mnuClearAllProperties_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNewProperty);
            this.groupBox1.Controls.Add(this.propertyItems);
            this.groupBox1.Controls.Add(this.txtPropertyName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgrPropertySearch);
            this.groupBox1.Controls.Add(this.txtDefaultValue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 306);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(175, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveSelectedProperty_Click);
            // 
            // btnNewProperty
            // 
            this.btnNewProperty.Location = new System.Drawing.Point(43, 277);
            this.btnNewProperty.Name = "btnNewProperty";
            this.btnNewProperty.Size = new System.Drawing.Size(126, 23);
            this.btnNewProperty.TabIndex = 84;
            this.btnNewProperty.Text = "New Property";
            this.btnNewProperty.UseVisualStyleBackColor = true;
            this.btnNewProperty.Click += new System.EventHandler(this.AddNewProperty_Click);
            // 
            // propertyItems
            // 
            this.propertyItems.GridContextMenu = this.contextMenuStrip1;
            this.propertyItems.Items = ((System.Collections.ArrayList)(resources.GetObject("propertyItems.Items")));
            this.propertyItems.Location = new System.Drawing.Point(6, 19);
            this.propertyItems.Name = "propertyItems";
            this.propertyItems.Size = new System.Drawing.Size(301, 255);
            this.propertyItems.TabIndex = 83;
            // 
            // PropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlSummaryControls);
            this.Controls.Add(this.lblCollapse);
            this.Name = "PropertyControl";
            this.Size = new System.Drawing.Size(1177, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dgrPropertySearch)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label lblCollapse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel pnlSummaryControls;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgrPropertySearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private GridItemsControl propertyItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewProperty1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSelectedProperty1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAllProperties1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewProperty;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveSelectedProperty;

    }
}
