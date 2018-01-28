namespace NvnInstaller
{
    partial class OutputControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnErrors = new System.Windows.Forms.ToolStripButton();
            this.btnWarnings = new System.Windows.Forms.ToolStripButton();
            this.btnInformation = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblWarningCount = new System.Windows.Forms.Label();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblWarnings = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.dgrOutputMessages = new System.Windows.Forms.DataGridView();
            this.logTypeColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.indexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrOutputMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 27);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnErrors,
            this.btnWarnings,
            this.btnInformation});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(625, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnErrors
            // 
            this.btnErrors.Checked = true;
            this.btnErrors.CheckOnClick = true;
            this.btnErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnErrors.Image = ((System.Drawing.Image)(resources.GetObject("btnErrors.Image")));
            this.btnErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnErrors.Name = "btnErrors";
            this.btnErrors.Size = new System.Drawing.Size(57, 22);
            this.btnErrors.Text = "Errors";
            this.btnErrors.Click += new System.EventHandler(this.btnErrors_Click);
            // 
            // btnWarnings
            // 
            this.btnWarnings.Checked = true;
            this.btnWarnings.CheckOnClick = true;
            this.btnWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnWarnings.Image = ((System.Drawing.Image)(resources.GetObject("btnWarnings.Image")));
            this.btnWarnings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWarnings.Name = "btnWarnings";
            this.btnWarnings.Size = new System.Drawing.Size(77, 22);
            this.btnWarnings.Text = "Warnings";
            this.btnWarnings.Click += new System.EventHandler(this.btnWarnings_Click);
            // 
            // btnInformation
            // 
            this.btnInformation.Checked = true;
            this.btnInformation.CheckOnClick = true;
            this.btnInformation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnInformation.Image = ((System.Drawing.Image)(resources.GetObject("btnInformation.Image")));
            this.btnInformation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(78, 22);
            this.btnInformation.Text = "Messages";
            this.btnInformation.Click += new System.EventHandler(this.btnInformation_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMessage);
            this.panel2.Controls.Add(this.lblWarningCount);
            this.panel2.Controls.Add(this.lblErrorCount);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.lblWarnings);
            this.panel2.Controls.Add(this.lblErrors);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 338);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 29);
            this.panel2.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(399, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 6;
            // 
            // lblWarningCount
            // 
            this.lblWarningCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarningCount.AutoSize = true;
            this.lblWarningCount.Location = new System.Drawing.Point(164, 8);
            this.lblWarningCount.Name = "lblWarningCount";
            this.lblWarningCount.Size = new System.Drawing.Size(13, 13);
            this.lblWarningCount.TabIndex = 5;
            this.lblWarningCount.Text = "0";
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErrorCount.AutoSize = true;
            this.lblErrorCount.Location = new System.Drawing.Point(45, 8);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(13, 13);
            this.lblErrorCount.TabIndex = 4;
            this.lblErrorCount.Text = "0";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(271, 6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(122, 15);
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // lblWarnings
            // 
            this.lblWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarnings.AutoSize = true;
            this.lblWarnings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnings.Location = new System.Drawing.Point(103, 8);
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.Size = new System.Drawing.Size(64, 13);
            this.lblWarnings.TabIndex = 1;
            this.lblWarnings.Text = "Warnings:";
            // 
            // lblErrors
            // 
            this.lblErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErrors.AutoSize = true;
            this.lblErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrors.Location = new System.Drawing.Point(3, 8);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(44, 13);
            this.lblErrors.TabIndex = 0;
            this.lblErrors.Text = "Errors:";
            // 
            // dgrOutputMessages
            // 
            this.dgrOutputMessages.AllowUserToAddRows = false;
            this.dgrOutputMessages.AllowUserToDeleteRows = false;
            this.dgrOutputMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrOutputMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrOutputMessages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrOutputMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrOutputMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logTypeColumn,
            this.indexColumn,
            this.messageColumn,
            this.moduleColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrOutputMessages.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrOutputMessages.Location = new System.Drawing.Point(0, 26);
            this.dgrOutputMessages.Name = "dgrOutputMessages";
            this.dgrOutputMessages.ReadOnly = true;
            this.dgrOutputMessages.RowHeadersVisible = false;
            this.dgrOutputMessages.Size = new System.Drawing.Size(625, 306);
            this.dgrOutputMessages.TabIndex = 4;
            // 
            // logTypeColumn
            // 
            this.logTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.logTypeColumn.FillWeight = 80.6289F;
            this.logTypeColumn.HeaderText = "";
            this.logTypeColumn.Name = "logTypeColumn";
            this.logTypeColumn.ReadOnly = true;
            this.logTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.logTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.logTypeColumn.Width = 40;
            // 
            // indexColumn
            // 
            this.indexColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.indexColumn.FillWeight = 68.23684F;
            this.indexColumn.HeaderText = "";
            this.indexColumn.Name = "indexColumn";
            this.indexColumn.ReadOnly = true;
            this.indexColumn.Width = 34;
            // 
            // messageColumn
            // 
            this.messageColumn.FillWeight = 149.6114F;
            this.messageColumn.HeaderText = "Description";
            this.messageColumn.Name = "messageColumn";
            this.messageColumn.ReadOnly = true;
            // 
            // moduleColumn
            // 
            this.moduleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.moduleColumn.FillWeight = 101.5228F;
            this.moduleColumn.HeaderText = "Module";
            this.moduleColumn.Name = "moduleColumn";
            this.moduleColumn.ReadOnly = true;
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrOutputMessages);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OutputControl";
            this.Size = new System.Drawing.Size(625, 367);
            this.Load += new System.EventHandler(this.OutputControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrOutputMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWarnings;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dgrOutputMessages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnErrors;
        private System.Windows.Forms.ToolStripButton btnWarnings;
        private System.Windows.Forms.ToolStripButton btnInformation;
        private System.Windows.Forms.Label lblWarningCount;
        private System.Windows.Forms.Label lblErrorCount;
        private System.Windows.Forms.DataGridViewImageColumn logTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleColumn;
        private System.Windows.Forms.Label lblMessage;
    }
}
