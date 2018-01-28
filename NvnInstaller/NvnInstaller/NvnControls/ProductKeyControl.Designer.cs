#if Standard
namespace NvnInstaller
{
    partial class ProductKeyControl
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
            this.label31 = new System.Windows.Forms.Label();
            this.txtProperty = new System.Windows.Forms.TextBox();
            this.txtFalseValue = new System.Windows.Forms.TextBox();
            this.txtTrueValue = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtDllEntry = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtValidationDll = new System.Windows.Forms.TextBox();
            this.btnBrowseDll = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(344, 35);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(195, 13);
            this.label31.TabIndex = 15;
            this.label31.Text = "Enter public method to call for validation";
            // 
            // txtProperty
            // 
            this.txtProperty.Location = new System.Drawing.Point(92, 61);
            this.txtProperty.Name = "txtProperty";
            this.txtProperty.Size = new System.Drawing.Size(101, 20);
            this.txtProperty.TabIndex = 14;
            // 
            // txtFalseValue
            // 
            this.txtFalseValue.Location = new System.Drawing.Point(415, 61);
            this.txtFalseValue.Name = "txtFalseValue";
            this.txtFalseValue.Size = new System.Drawing.Size(74, 20);
            this.txtFalseValue.TabIndex = 13;
            // 
            // txtTrueValue
            // 
            this.txtTrueValue.Location = new System.Drawing.Point(264, 61);
            this.txtTrueValue.Name = "txtTrueValue";
            this.txtTrueValue.Size = new System.Drawing.Size(74, 20);
            this.txtTrueValue.TabIndex = 12;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(199, 61);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 13);
            this.label30.TabIndex = 11;
            this.label30.Text = "True Value:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(344, 61);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 13);
            this.label27.TabIndex = 10;
            this.label27.Text = "False Value:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 13);
            this.label26.TabIndex = 9;
            this.label26.Text = "Property Name";
            // 
            // txtDllEntry
            // 
            this.txtDllEntry.Location = new System.Drawing.Point(92, 35);
            this.txtDllEntry.Name = "txtDllEntry";
            this.txtDllEntry.Size = new System.Drawing.Size(246, 20);
            this.txtDllEntry.TabIndex = 8;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(32, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "DLL Entry";
            // 
            // txtValidationDll
            // 
            this.txtValidationDll.Enabled = false;
            this.txtValidationDll.Location = new System.Drawing.Point(92, 9);
            this.txtValidationDll.Name = "txtValidationDll";
            this.txtValidationDll.Size = new System.Drawing.Size(366, 20);
            this.txtValidationDll.TabIndex = 5;
            // 
            // btnBrowseDll
            // 
            this.btnBrowseDll.Location = new System.Drawing.Point(464, 7);
            this.btnBrowseDll.Name = "btnBrowseDll";
            this.btnBrowseDll.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDll.TabIndex = 4;
            this.btnBrowseDll.Text = "Browse...";
            this.btnBrowseDll.UseVisualStyleBackColor = true;
            this.btnBrowseDll.Click += new System.EventHandler(this.btnBrowseDll_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Validating DLL";
            // 
            // ProductKeyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtProperty);
            this.Controls.Add(this.txtFalseValue);
            this.Controls.Add(this.txtTrueValue);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnBrowseDll);
            this.Controls.Add(this.txtDllEntry);
            this.Controls.Add(this.txtValidationDll);
            this.Controls.Add(this.label25);
            this.Name = "ProductKeyControl";
            this.Size = new System.Drawing.Size(739, 551);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtProperty;
        private System.Windows.Forms.TextBox txtFalseValue;
        private System.Windows.Forms.TextBox txtTrueValue;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtDllEntry;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtValidationDll;
        private System.Windows.Forms.Button btnBrowseDll;
        private System.Windows.Forms.Label label16;
    }
}
#endif