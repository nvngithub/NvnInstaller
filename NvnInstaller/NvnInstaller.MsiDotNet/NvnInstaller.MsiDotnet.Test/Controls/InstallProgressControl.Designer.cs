namespace WindowsFormsApplication1 {
  partial class InstallProgressControl {
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
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnBack = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.lblInstallMessage = new System.Windows.Forms.Label();
      this.txtMessage = new System.Windows.Forms.TextBox();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnBack);
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Controls.Add(this.btnNext);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 306);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(694, 53);
      this.panel2.TabIndex = 7;
      // 
      // btnBack
      // 
      this.btnBack.Location = new System.Drawing.Point(443, 18);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(75, 23);
      this.btnBack.TabIndex = 2;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(605, 18);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnNext
      // 
      this.btnNext.Location = new System.Drawing.Point(524, 18);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new System.Drawing.Size(75, 23);
      this.btnNext.TabIndex = 0;
      this.btnNext.Text = "Next";
      this.btnNext.UseVisualStyleBackColor = true;
      this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
      // 
      // progressBar1
      // 
      this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar1.Location = new System.Drawing.Point(25, 60);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(638, 23);
      this.progressBar1.TabIndex = 8;
      // 
      // lblInstallMessage
      // 
      this.lblInstallMessage.AutoSize = true;
      this.lblInstallMessage.Location = new System.Drawing.Point(22, 44);
      this.lblInstallMessage.Name = "lblInstallMessage";
      this.lblInstallMessage.Size = new System.Drawing.Size(0, 13);
      this.lblInstallMessage.TabIndex = 9;
      // 
      // txtMessage
      // 
      this.txtMessage.Location = new System.Drawing.Point(25, 114);
      this.txtMessage.Multiline = true;
      this.txtMessage.Name = "txtMessage";
      this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtMessage.Size = new System.Drawing.Size(638, 150);
      this.txtMessage.TabIndex = 10;
      // 
      // InstallProgressControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtMessage);
      this.Controls.Add(this.lblInstallMessage);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.panel2);
      this.Name = "InstallProgressControl";
      this.Size = new System.Drawing.Size(694, 359);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lblInstallMessage;
    private System.Windows.Forms.TextBox txtMessage;
  }
}
