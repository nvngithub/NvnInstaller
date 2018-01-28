namespace WindowsFormsApplication1 {
  partial class FeatureSelectControl {
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
      this.tvFeatures = new System.Windows.Forms.TreeView();
      this.lblLocation = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblTotalFeatureCost = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      this.lblFileCost = new System.Windows.Forms.Label();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnBack = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tvFeatures
      // 
      this.tvFeatures.CheckBoxes = true;
      this.tvFeatures.Location = new System.Drawing.Point(3, 3);
      this.tvFeatures.Name = "tvFeatures";
      this.tvFeatures.Size = new System.Drawing.Size(236, 232);
      this.tvFeatures.TabIndex = 0;
      this.tvFeatures.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFeatures_AfterSelect);
      // 
      // lblLocation
      // 
      this.lblLocation.AutoSize = true;
      this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLocation.Location = new System.Drawing.Point(3, 253);
      this.lblLocation.Name = "lblLocation";
      this.lblLocation.Size = new System.Drawing.Size(0, 13);
      this.lblLocation.TabIndex = 1;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.lblTotalFeatureCost);
      this.groupBox1.Controls.Add(this.lblDescription);
      this.groupBox1.Controls.Add(this.lblFileCost);
      this.groupBox1.Location = new System.Drawing.Point(245, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(443, 232);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      // 
      // lblTotalFeatureCost
      // 
      this.lblTotalFeatureCost.AutoSize = true;
      this.lblTotalFeatureCost.Location = new System.Drawing.Point(6, 29);
      this.lblTotalFeatureCost.Name = "lblTotalFeatureCost";
      this.lblTotalFeatureCost.Size = new System.Drawing.Size(200, 13);
      this.lblTotalFeatureCost.TabIndex = 2;
      this.lblTotalFeatureCost.Text = "Total feature cost inclusing child features";
      // 
      // lblDescription
      // 
      this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDescription.Location = new System.Drawing.Point(6, 67);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(431, 162);
      this.lblDescription.TabIndex = 1;
      this.lblDescription.Text = "[No description available]";
      // 
      // lblFileCost
      // 
      this.lblFileCost.AutoSize = true;
      this.lblFileCost.Location = new System.Drawing.Point(6, 16);
      this.lblFileCost.Name = "lblFileCost";
      this.lblFileCost.Size = new System.Drawing.Size(66, 13);
      this.lblFileCost.TabIndex = 0;
      this.lblFileCost.Text = "Feature cost";
      // 
      // btnBrowse
      // 
      this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowse.Location = new System.Drawing.Point(613, 248);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 23);
      this.btnBrowse.TabIndex = 3;
      this.btnBrowse.Text = "Browse...";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnBack);
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Controls.Add(this.btnNext);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 287);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(691, 53);
      this.panel2.TabIndex = 6;
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
      // FeatureSelectControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.lblLocation);
      this.Controls.Add(this.tvFeatures);
      this.Name = "FeatureSelectControl";
      this.Size = new System.Drawing.Size(691, 340);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvFeatures;
    private System.Windows.Forms.Label lblLocation;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblFileCost;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Label lblTotalFeatureCost;
  }
}
