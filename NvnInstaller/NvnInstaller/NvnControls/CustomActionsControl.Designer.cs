namespace NvnInstaller
{
    partial class CustomActionsControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Fireball.Windows.Forms.LineMarginRender lineMarginRender2 = new Fireball.Windows.Forms.LineMarginRender();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbCustomActionType = new System.Windows.Forms.ComboBox();
            this.syntaxDocument = new Fireball.Syntax.SyntaxDocument(this.components);
            this.dgActions = new System.Windows.Forms.DataGridView();
            this.CustomActionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeEditorControl = new Fireball.Windows.Forms.CodeEditorControl();
            this.label7 = new System.Windows.Forms.Label();
            this.dgProperties = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.lblHelpFunctionCall = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.PropertyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrowseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 290);
            this.listBox1.TabIndex = 0;
            this.toolTip.SetToolTip(this.listBox1, "Right click to add custom actions AFTER this installtion sequence.");
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer3.Size = new System.Drawing.Size(552, 302);
            this.splitContainer3.SplitterDistance = 334;
            this.splitContainer3.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.listBox2);
            this.splitContainer4.Size = new System.Drawing.Size(334, 302);
            this.splitContainer4.SplitterDistance = 154;
            this.splitContainer4.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(176, 290);
            this.listBox2.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(214, 302);
            this.propertyGrid1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select custom action type";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(410, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Custom Action";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbCustomActionType
            // 
            this.cmbCustomActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomActionType.FormattingEnabled = true;
            this.cmbCustomActionType.Location = new System.Drawing.Point(141, 2);
            this.cmbCustomActionType.Name = "cmbCustomActionType";
            this.cmbCustomActionType.Size = new System.Drawing.Size(263, 21);
            this.cmbCustomActionType.TabIndex = 4;
            // 
            // syntaxDocument
            // 
            this.syntaxDocument.Lines = new string[] {
        ""};
            this.syntaxDocument.MaxUndoBufferSize = 1000;
            this.syntaxDocument.Modified = false;
            this.syntaxDocument.UndoStep = 0;
            // 
            // dgActions
            // 
            this.dgActions.AllowUserToAddRows = false;
            this.dgActions.AllowUserToResizeRows = false;
            this.dgActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgActions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomActionColumn});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgActions.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgActions.Location = new System.Drawing.Point(35, 57);
            this.dgActions.MultiSelect = false;
            this.dgActions.Name = "dgActions";
            this.dgActions.ReadOnly = true;
            this.dgActions.RowHeadersVisible = false;
            this.dgActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgActions.Size = new System.Drawing.Size(299, 150);
            this.dgActions.TabIndex = 47;
            this.dgActions.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgActions_UserDeletedRow);
            this.dgActions.SelectionChanged += new System.EventHandler(this.dgActions_SelectionChanged);
            // 
            // CustomActionColumn
            // 
            this.CustomActionColumn.HeaderText = "Custom Actions";
            this.CustomActionColumn.Name = "CustomActionColumn";
            this.CustomActionColumn.ReadOnly = true;
            // 
            // codeEditorControl
            // 
            this.codeEditorControl.ActiveView = Fireball.Windows.Forms.CodeEditor.ActiveView.BottomRight;
            this.codeEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeEditorControl.AutoListPosition = null;
            this.codeEditorControl.AutoListSelectedText = "a123";
            this.codeEditorControl.AutoListVisible = false;
            this.codeEditorControl.CopyAsRTF = false;
            this.codeEditorControl.Document = this.syntaxDocument;
            this.codeEditorControl.Enabled = false;
            this.codeEditorControl.InfoTipCount = 1;
            this.codeEditorControl.InfoTipPosition = null;
            this.codeEditorControl.InfoTipSelectedIndex = 1;
            this.codeEditorControl.InfoTipVisible = false;
            lineMarginRender2.Bounds = new System.Drawing.Rectangle(19, 0, 19, 16);
            this.codeEditorControl.LineMarginRender = lineMarginRender2;
            this.codeEditorControl.Location = new System.Drawing.Point(0, 243);
            this.codeEditorControl.LockCursorUpdate = false;
            this.codeEditorControl.Name = "codeEditorControl";
            this.codeEditorControl.Saved = false;
            this.codeEditorControl.ShowScopeIndicator = false;
            this.codeEditorControl.Size = new System.Drawing.Size(872, 268);
            this.codeEditorControl.SmoothScroll = false;
            this.codeEditorControl.SplitviewH = -4;
            this.codeEditorControl.SplitviewV = -4;
            this.codeEditorControl.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.codeEditorControl.TabIndex = 65;
            this.codeEditorControl.Text = "codeEditorControl1";
            this.codeEditorControl.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(337, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Properties";
            // 
            // dgProperties
            // 
            this.dgProperties.AllowUserToAddRows = false;
            this.dgProperties.AllowUserToDeleteRows = false;
            this.dgProperties.AllowUserToResizeColumns = false;
            this.dgProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyCol,
            this.ValueCol,
            this.BrowseColumn});
            this.dgProperties.Location = new System.Drawing.Point(340, 57);
            this.dgProperties.MultiSelect = false;
            this.dgProperties.Name = "dgProperties";
            this.dgProperties.RowHeadersVisible = false;
            this.dgProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgProperties.Size = new System.Drawing.Size(532, 150);
            this.dgProperties.TabIndex = 63;
            this.dgProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProperties_CellValueChanged);
            this.dgProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProperties_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Script";
            // 
            // lblHelpFunctionCall
            // 
            this.lblHelpFunctionCall.AutoSize = true;
            this.lblHelpFunctionCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpFunctionCall.Location = new System.Drawing.Point(464, 191);
            this.lblHelpFunctionCall.Name = "lblHelpFunctionCall";
            this.lblHelpFunctionCall.Size = new System.Drawing.Size(0, 13);
            this.lblHelpFunctionCall.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Selected Custom Actions";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 517);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save Script";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(3, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 23);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(3, 110);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(26, 23);
            this.btnUp.TabIndex = 69;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(3, 139);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(26, 23);
            this.btnDown.TabIndex = 70;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // PropertyCol
            // 
            this.PropertyCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.PropertyCol.DefaultCellStyle = dataGridViewCellStyle7;
            this.PropertyCol.Frozen = true;
            this.PropertyCol.HeaderText = "Property";
            this.PropertyCol.Name = "PropertyCol";
            this.PropertyCol.ReadOnly = true;
            this.PropertyCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyCol.Width = 52;
            // 
            // ValueCol
            // 
            this.ValueCol.HeaderText = "Value";
            this.ValueCol.Name = "ValueCol";
            this.ValueCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BrowseColumn
            // 
            this.BrowseColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.BrowseColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.BrowseColumn.HeaderText = "";
            this.BrowseColumn.Name = "BrowseColumn";
            this.BrowseColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BrowseColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BrowseColumn.Width = 30;
            // 
            // CustomActionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeEditorControl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgProperties);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblHelpFunctionCall);
            this.Controls.Add(this.dgActions);
            this.Controls.Add(this.cmbCustomActionType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Name = "CustomActionsControl";
            this.Size = new System.Drawing.Size(875, 543);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbCustomActionType;
        private System.Windows.Forms.DataGridView dgActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomActionColumn;
        private Fireball.Syntax.SyntaxDocument syntaxDocument;
        private Fireball.Windows.Forms.CodeEditorControl codeEditorControl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgProperties;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblHelpFunctionCall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrowseColumn;

    }
}
