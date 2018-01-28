namespace WindowsFormsApplication1 {
  partial class LicenseControl {
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
      this.txtLicense = new System.Windows.Forms.RichTextBox();
      this.rbYes = new System.Windows.Forms.RadioButton();
      this.rbNo = new System.Windows.Forms.RadioButton();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnBack = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtLicense
      // 
      this.txtLicense.Location = new System.Drawing.Point(3, 3);
      this.txtLicense.Name = "txtLicense";
      this.txtLicense.Size = new System.Drawing.Size(690, 282);
      this.txtLicense.TabIndex = 0;
      this.txtLicense.Text = "";
      // 
      // rbYes
      // 
      this.rbYes.AutoSize = true;
      this.rbYes.Checked = true;
      this.rbYes.Location = new System.Drawing.Point(12, 291);
      this.rbYes.Name = "rbYes";
      this.rbYes.Size = new System.Drawing.Size(43, 17);
      this.rbYes.TabIndex = 1;
      this.rbYes.TabStop = true;
      this.rbYes.Text = "Yes";
      this.rbYes.UseVisualStyleBackColor = true;
      // 
      // rbNo
      // 
      this.rbNo.AutoSize = true;
      this.rbNo.Location = new System.Drawing.Point(61, 291);
      this.rbNo.Name = "rbNo";
      this.rbNo.Size = new System.Drawing.Size(39, 17);
      this.rbNo.TabIndex = 2;
      this.rbNo.TabStop = true;
      this.rbNo.Text = "No";
      this.rbNo.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnBack);
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Controls.Add(this.btnNext);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 310);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(696, 53);
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
      // LicenseControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.rbNo);
      this.Controls.Add(this.rbYes);
      this.Controls.Add(this.txtLicense);
      this.Name = "LicenseControl";
      this.Size = new System.Drawing.Size(696, 363);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox txtLicense;
    private System.Windows.Forms.RadioButton rbYes;
    private System.Windows.Forms.RadioButton rbNo;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnNext;
  }
}
