namespace WindowsFormsApplication1 {
  partial class InstallTypeControl {
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
      this.btnUpdate = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnRepair = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnBack = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnRemoveAll = new System.Windows.Forms.Button();
      this.btnInstallAll = new System.Windows.Forms.Button();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnUpdate
      // 
      this.btnUpdate.Location = new System.Drawing.Point(71, 150);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new System.Drawing.Size(75, 23);
      this.btnUpdate.TabIndex = 1;
      this.btnUpdate.Text = "Change";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.btnUpdate.Click += new System.EventHandler(this.btnChange_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(71, 92);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(75, 23);
      this.btnRemove.TabIndex = 2;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnRepair
      // 
      this.btnRepair.Location = new System.Drawing.Point(71, 209);
      this.btnRepair.Name = "btnRepair";
      this.btnRepair.Size = new System.Drawing.Size(75, 23);
      this.btnRepair.TabIndex = 3;
      this.btnRepair.Text = "Repair";
      this.btnRepair.UseVisualStyleBackColor = true;
      this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnBack);
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 335);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(693, 53);
      this.panel2.TabIndex = 8;
      // 
      // btnBack
      // 
      this.btnBack.Location = new System.Drawing.Point(524, 18);
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
      this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnRemoveAll
      // 
      this.btnRemoveAll.Location = new System.Drawing.Point(152, 92);
      this.btnRemoveAll.Name = "btnRemoveAll";
      this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
      this.btnRemoveAll.TabIndex = 9;
      this.btnRemoveAll.Text = "Remove All";
      this.btnRemoveAll.UseVisualStyleBackColor = true;
      this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
      // 
      // btnInstallAll
      // 
      this.btnInstallAll.Location = new System.Drawing.Point(71, 42);
      this.btnInstallAll.Name = "btnInstallAll";
      this.btnInstallAll.Size = new System.Drawing.Size(75, 23);
      this.btnInstallAll.TabIndex = 10;
      this.btnInstallAll.Text = "Install All";
      this.btnInstallAll.UseVisualStyleBackColor = true;
      this.btnInstallAll.Click += new System.EventHandler(this.btnInstallAll_Click);
      // 
      // InstallTypeContro
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnInstallAll);
      this.Controls.Add(this.btnRemoveAll);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.btnRepair);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.btnUpdate);
      this.Name = "InstallTypeContro";
      this.Size = new System.Drawing.Size(693, 388);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnRepair;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnRemoveAll;
    private System.Windows.Forms.Button btnInstallAll;
  }
}
