using System.Windows.Forms;
using System;
namespace NvnInstaller
{
    partial class UIControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlDialog = new System.Windows.Forms.Panel();
            this.pbDialog = new System.Windows.Forms.PictureBox();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.pgLabelProperty = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlDialog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgLabelProperty);
            this.splitContainer1.Size = new System.Drawing.Size(853, 542);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.TabIndex = 2;
            // 
            // pnlDialog
            // 
            this.pnlDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDialog.Controls.Add(this.pbDialog);
            this.pnlDialog.Controls.Add(this.pbBanner);
            this.pnlDialog.Location = new System.Drawing.Point(3, 3);
            this.pnlDialog.Name = "pnlDialog";
            this.pnlDialog.Size = new System.Drawing.Size(501, 378);
            this.pnlDialog.TabIndex = 0;
            // 
            // pbDialog
            // 
            this.pbDialog.Location = new System.Drawing.Point(3, 61);
            this.pbDialog.Name = "pbDialog";
            this.pbDialog.Size = new System.Drawing.Size(493, 312);
            this.pbDialog.TabIndex = 3;
            this.pbDialog.TabStop = false;
            // 
            // pbBanner
            // 
            this.pbBanner.ImageLocation = "Bitmaps\\banner.bmp";
            this.pbBanner.Location = new System.Drawing.Point(3, 3);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(493, 58);
            this.pbBanner.TabIndex = 2;
            this.pbBanner.TabStop = false;
            // 
            // pgLabelProperty
            // 
            this.pgLabelProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgLabelProperty.HelpVisible = false;
            this.pgLabelProperty.Location = new System.Drawing.Point(0, 0);
            this.pgLabelProperty.Name = "pgLabelProperty";
            this.pgLabelProperty.Size = new System.Drawing.Size(269, 542);
            this.pgLabelProperty.TabIndex = 0;
            this.pgLabelProperty.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgLabelProperty_PropertyValueChanged);
            // 
            // UIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UIControl";
            this.Size = new System.Drawing.Size(853, 542);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private PropertyGrid pgLabelProperty;
        private Panel pnlDialog;
        private PictureBox pbDialog;
        private PictureBox pbBanner;
    }
}
