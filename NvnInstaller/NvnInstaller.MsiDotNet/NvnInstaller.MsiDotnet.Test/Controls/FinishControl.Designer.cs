namespace WindowsFormsApplication1 {
  partial class FinishControl {
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
      this.chkVisitWebsite = new System.Windows.Forms.CheckBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.chkStartApplication = new System.Windows.Forms.CheckBox();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // chkVisitWebsite
      // 
      this.chkVisitWebsite.AutoSize = true;
      this.chkVisitWebsite.Location = new System.Drawing.Point(128, 62);
      this.chkVisitWebsite.Name = "chkVisitWebsite";
      this.chkVisitWebsite.Size = new System.Drawing.Size(111, 17);
      this.chkVisitWebsite.TabIndex = 0;
      this.chkVisitWebsite.Text = "Visit our website...";
      this.chkVisitWebsite.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 273);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(694, 53);
      this.panel2.TabIndex = 7;
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(605, 18);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Finish";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // chkStartApplication
      // 
      this.chkStartApplication.AutoSize = true;
      this.chkStartApplication.Location = new System.Drawing.Point(128, 85);
      this.chkStartApplication.Name = "chkStartApplication";
      this.chkStartApplication.Size = new System.Drawing.Size(205, 17);
      this.chkStartApplication.TabIndex = 8;
      this.chkStartApplication.Text = "Start Application (ex: Internet explorer)";
      this.chkStartApplication.UseVisualStyleBackColor = true;
      // 
      // FinishControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.chkStartApplication);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.chkVisitWebsite);
      this.Name = "FinishControl";
      this.Size = new System.Drawing.Size(694, 326);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkVisitWebsite;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkStartApplication;
  }
}
