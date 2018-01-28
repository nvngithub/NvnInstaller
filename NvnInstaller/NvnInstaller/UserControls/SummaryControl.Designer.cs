namespace NvnInstaller
{
    partial class SummaryControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.dgrSummaryData = new System.Windows.Forms.DataGridView();
            this.lblCollapse = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrSummaryData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(18, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Location = new System.Drawing.Point(25, 6);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(459, 2);
            this.lblLine.TabIndex = 2;
            // 
            // dgrSummaryData
            // 
            this.dgrSummaryData.AllowUserToAddRows = false;
            this.dgrSummaryData.AllowUserToDeleteRows = false;
            this.dgrSummaryData.AllowUserToResizeRows = false;
            this.dgrSummaryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrSummaryData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrSummaryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrSummaryData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrSummaryData.Location = new System.Drawing.Point(3, 22);
            this.dgrSummaryData.Name = "dgrSummaryData";
            this.dgrSummaryData.ReadOnly = true;
            this.dgrSummaryData.RowHeadersVisible = false;
            this.dgrSummaryData.Size = new System.Drawing.Size(481, 150);
            this.dgrSummaryData.TabIndex = 3;
            // 
            // lblCollapse
            // 
            this.lblCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollapse.Location = new System.Drawing.Point(-2, -5);
            this.lblCollapse.Name = "lblCollapse";
            this.lblCollapse.Size = new System.Drawing.Size(21, 24);
            this.lblCollapse.TabIndex = 4;
            this.lblCollapse.Text = "-";
            this.lblCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCollapse.Click += new System.EventHandler(this.lblCollapse_Click);
            // 
            // SummaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCollapse);
            this.Controls.Add(this.dgrSummaryData);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLine);
            this.Name = "SummaryControl";
            this.Size = new System.Drawing.Size(487, 179);
            this.Load += new System.EventHandler(this.SummaryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrSummaryData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.DataGridView dgrSummaryData;
        private System.Windows.Forms.Label lblCollapse;
    }
}
