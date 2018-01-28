namespace NvnInstaller
{
    partial class ViewUIControl
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.pbDialog = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDialog)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 2000;
            // 
            // pbBanner
            // 
            this.pbBanner.ImageLocation = "";
            this.pbBanner.Location = new System.Drawing.Point(0, 0);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(493, 58);
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // pbDialog
            // 
            this.pbDialog.Location = new System.Drawing.Point(0, 58);
            this.pbDialog.Name = "pbDialog";
            this.pbDialog.Size = new System.Drawing.Size(493, 312);
            this.pbDialog.TabIndex = 1;
            this.pbDialog.TabStop = false;
            // 
            // ViewUIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbDialog);
            this.Controls.Add(this.pbBanner);
            this.Name = "ViewUIControl";
            this.Size = new System.Drawing.Size(495, 384);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDialog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.PictureBox pbDialog;
    }
}
