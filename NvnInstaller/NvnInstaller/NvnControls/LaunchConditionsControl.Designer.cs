namespace NvnInstaller {
    partial class LaunchConditionsControl {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchConditionsControl));
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFailMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConditionName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgrUsefulConditions = new System.Windows.Forms.DataGridView();
            this.ConditionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrUserDefinedProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgrWindowsProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkPropertyReference = new System.Windows.Forms.LinkLabel();
            this.lnkConditionalSyntax = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNewCondition1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveSelectedCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteSelctedCondition1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearAllConditions1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewLaunchCondition = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.conoditionItems = new NvnInstaller.GridItemsControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUsefulConditions)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUserDefinedProperties)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrWindowsProperties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(94, 45);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(283, 20);
            this.txtCondition.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Condition";
            // 
            // txtFailMessage
            // 
            this.txtFailMessage.Location = new System.Drawing.Point(94, 71);
            this.txtFailMessage.Name = "txtFailMessage";
            this.txtFailMessage.Size = new System.Drawing.Size(283, 20);
            this.txtFailMessage.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Fail Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "Condition Name";
            // 
            // txtConditionName
            // 
            this.txtConditionName.Location = new System.Drawing.Point(94, 19);
            this.txtConditionName.Name = "txtConditionName";
            this.txtConditionName.Size = new System.Drawing.Size(283, 20);
            this.txtConditionName.TabIndex = 84;
            this.txtConditionName.TextChanged += new System.EventHandler(this.txtConditionName_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(38, 254);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(712, 280);
            this.tabControl1.TabIndex = 94;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrUsefulConditions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(704, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Useful conditions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrUsefulConditions
            // 
            this.dgrUsefulConditions.AllowUserToAddRows = false;
            this.dgrUsefulConditions.AllowUserToDeleteRows = false;
            this.dgrUsefulConditions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrUsefulConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrUsefulConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConditionColumn,
            this.DescriptionColumn});
            this.dgrUsefulConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrUsefulConditions.Location = new System.Drawing.Point(3, 3);
            this.dgrUsefulConditions.Name = "dgrUsefulConditions";
            this.dgrUsefulConditions.RowHeadersVisible = false;
            this.dgrUsefulConditions.Size = new System.Drawing.Size(698, 248);
            this.dgrUsefulConditions.TabIndex = 0;
            this.dgrUsefulConditions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrUsefulConditions_CellDoubleClick);
            // 
            // ConditionColumn
            // 
            this.ConditionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ConditionColumn.HeaderText = "Condition";
            this.ConditionColumn.Name = "ConditionColumn";
            this.ConditionColumn.Width = 76;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgrUserDefinedProperties);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(704, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User defined propertis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrUserDefinedProperties
            // 
            this.dgrUserDefinedProperties.AllowUserToAddRows = false;
            this.dgrUserDefinedProperties.AllowUserToDeleteRows = false;
            this.dgrUserDefinedProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrUserDefinedProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrUserDefinedProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgrUserDefinedProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrUserDefinedProperties.Location = new System.Drawing.Point(3, 3);
            this.dgrUserDefinedProperties.Name = "dgrUserDefinedProperties";
            this.dgrUserDefinedProperties.RowHeadersVisible = false;
            this.dgrUserDefinedProperties.Size = new System.Drawing.Size(698, 197);
            this.dgrUserDefinedProperties.TabIndex = 1;
            this.dgrUserDefinedProperties.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrUserDefinedProperties_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Property";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 71;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgrWindowsProperties);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(704, 203);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Windows properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgrWindowsProperties
            // 
            this.dgrWindowsProperties.AllowUserToAddRows = false;
            this.dgrWindowsProperties.AllowUserToDeleteRows = false;
            this.dgrWindowsProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrWindowsProperties.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrWindowsProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrWindowsProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgrWindowsProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrWindowsProperties.Location = new System.Drawing.Point(0, 0);
            this.dgrWindowsProperties.Name = "dgrWindowsProperties";
            this.dgrWindowsProperties.RowHeadersVisible = false;
            this.dgrWindowsProperties.Size = new System.Drawing.Size(704, 203);
            this.dgrWindowsProperties.TabIndex = 1;
            this.dgrWindowsProperties.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrWindowsProperties_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Property";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 71;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFailMessage);
            this.groupBox1.Controls.Add(this.txtConditionName);
            this.groupBox1.Controls.Add(this.txtCondition);
            this.groupBox1.Controls.Add(this.lnkPropertyReference);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lnkConditionalSyntax);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(298, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 138);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            // 
            // lnkPropertyReference
            // 
            this.lnkPropertyReference.AutoSize = true;
            this.lnkPropertyReference.Location = new System.Drawing.Point(91, 108);
            this.lnkPropertyReference.Name = "lnkPropertyReference";
            this.lnkPropertyReference.Size = new System.Drawing.Size(185, 13);
            this.lnkPropertyReference.TabIndex = 97;
            this.lnkPropertyReference.TabStop = true;
            this.lnkPropertyReference.Text = "Windows Installer Property Reference";
            this.lnkPropertyReference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPropertyReference_LinkClicked);
            // 
            // lnkConditionalSyntax
            // 
            this.lnkConditionalSyntax.AutoSize = true;
            this.lnkConditionalSyntax.Location = new System.Drawing.Point(91, 95);
            this.lnkConditionalSyntax.Name = "lnkConditionalSyntax";
            this.lnkConditionalSyntax.Size = new System.Drawing.Size(231, 13);
            this.lnkConditionalSyntax.TabIndex = 13;
            this.lnkConditionalSyntax.TabStop = true;
            this.lnkConditionalSyntax.Text = "Know more about Conditional Statement Syntax";
            this.lnkConditionalSyntax.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConditionalSyntax_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNewCondition1,
            this.mnuSaveSelectedCondition,
            this.mnuDeleteSelctedCondition1,
            this.toolStripSeparator2,
            this.mnuClearAllConditions1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 98);
            // 
            // mnuAddNewCondition1
            // 
            this.mnuAddNewCondition1.Name = "mnuAddNewCondition1";
            this.mnuAddNewCondition1.Size = new System.Drawing.Size(207, 22);
            this.mnuAddNewCondition1.Text = "Add new condition";
            this.mnuAddNewCondition1.Click += new System.EventHandler(this.mnuAddNewCondition_Click);
            // 
            // mnuSaveSelectedCondition
            // 
            this.mnuSaveSelectedCondition.Name = "mnuSaveSelectedCondition";
            this.mnuSaveSelectedCondition.Size = new System.Drawing.Size(207, 22);
            this.mnuSaveSelectedCondition.Text = "Save selected condition";
            this.mnuSaveSelectedCondition.Click += new System.EventHandler(this.SaveSelectedCondition_Click);
            // 
            // mnuDeleteSelctedCondition1
            // 
            this.mnuDeleteSelctedCondition1.Name = "mnuDeleteSelctedCondition1";
            this.mnuDeleteSelctedCondition1.Size = new System.Drawing.Size(207, 22);
            this.mnuDeleteSelctedCondition1.Text = "Delete selected condition";
            this.mnuDeleteSelctedCondition1.Click += new System.EventHandler(this.mnuDeleteSelectedCondition_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuClearAllConditions1
            // 
            this.mnuClearAllConditions1.Name = "mnuClearAllConditions1";
            this.mnuClearAllConditions1.Size = new System.Drawing.Size(207, 22);
            this.mnuClearAllConditions1.Text = "Clear all conditions";
            this.mnuClearAllConditions1.Click += new System.EventHandler(this.mnuClearAllConditions_Click);
            // 
            // btnAddNewLaunchCondition
            // 
            this.btnAddNewLaunchCondition.Location = new System.Drawing.Point(38, 225);
            this.btnAddNewLaunchCondition.Name = "btnAddNewLaunchCondition";
            this.btnAddNewLaunchCondition.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewLaunchCondition.TabIndex = 98;
            this.btnAddNewLaunchCondition.Text = "Add New Launch Condition";
            this.btnAddNewLaunchCondition.UseVisualStyleBackColor = true;
            this.btnAddNewLaunchCondition.Click += new System.EventHandler(this.mnuAddNewCondition_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveSelectedCondition_Click);
            // 
            // conoditionItems
            // 
            this.conoditionItems.GridContextMenu = this.contextMenuStrip1;
            this.conoditionItems.Items = ((System.Collections.ArrayList)(resources.GetObject("conoditionItems.Items")));
            this.conoditionItems.Location = new System.Drawing.Point(3, 3);
            this.conoditionItems.Name = "conoditionItems";
            this.conoditionItems.Size = new System.Drawing.Size(289, 216);
            this.conoditionItems.TabIndex = 97;
            // 
            // PrerequisitesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNewLaunchCondition);
            this.Controls.Add(this.conoditionItems);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrerequisitesControl";
            this.Size = new System.Drawing.Size(777, 534);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrUsefulConditions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrUserDefinedProperties)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrWindowsProperties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFailMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConditionName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgrUsefulConditions;
        private System.Windows.Forms.DataGridView dgrUserDefinedProperties;
        private System.Windows.Forms.DataGridView dgrWindowsProperties;
        private System.Windows.Forms.LinkLabel lnkConditionalSyntax;
        private System.Windows.Forms.LinkLabel lnkPropertyReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConditionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private GridItemsControl conoditionItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewCondition1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSelctedCondition1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAllConditions1;
        private System.Windows.Forms.Button btnAddNewLaunchCondition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveSelectedCondition;






    }
}
