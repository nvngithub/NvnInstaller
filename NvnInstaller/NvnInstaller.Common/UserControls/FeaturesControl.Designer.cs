namespace NvnInstaller
{
    partial class FeaturesControl
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
            this.tvFreatures = new System.Windows.Forms.TreeView();
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tvFreatures
            // 
            this.tvFreatures.Location = new System.Drawing.Point(0, 0);
            this.tvFreatures.Name = "tvFreatures";
            this.tvFreatures.Size = new System.Drawing.Size(271, 252);
            this.tvFreatures.TabIndex = 0;
            this.tvFreatures.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFreatures_NodeMouseDoubleClick);
            // 
            // lnkClose
            // 
            this.lnkClose.AutoSize = true;
            this.lnkClose.Location = new System.Drawing.Point(235, 255);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(33, 13);
            this.lnkClose.TabIndex = 1;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "Close";
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClose_LinkClicked);
            // 
            // FeaturesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkClose);
            this.Controls.Add(this.tvFreatures);
            this.Name = "FeaturesControl";
            this.Size = new System.Drawing.Size(271, 268);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFreatures;
        private System.Windows.Forms.LinkLabel lnkClose;
    }
}
