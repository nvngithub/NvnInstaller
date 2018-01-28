using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Threading;

namespace NvnInstaller
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            // making form transparent
            CheckForIllegalCrossThreadCalls = false;
            lblVersion.Text = "Version " + Globals.version;
            lblApplicationName.Text = Globals.applicationName;
            lblApplicationCategory.Text = Globals.applicationCategory;

            pbIcon.Image = new Bitmap(Globals.imagesFolder + "NvnInstaller-48.bmp");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint (e);
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();
            p.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
            p.AddLine(40, 0, this.Width - 40, 0);
            p.AddArc(new Rectangle(this.Width - 40, 0, 40, 40), -90, 90);
            p.AddLine(this.Width, 40, this.Width, this.Height - 40);
            p.AddArc(new Rectangle(this.Width - 40, this.Height - 40, 40, 40), 0, 90);
            p.AddLine(this.Width - 40, this.Height, 40, this.Height);
            p.AddArc(new Rectangle(0, this.Height - 40, 40, 40), 90, 90);
            p.CloseFigure();
            this.Region = new Region(p);

            SolidBrush oBlackBrush = new SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Pen borderPen = new System.Drawing.Pen(oBlackBrush, 4);
            e.Graphics.DrawPath(borderPen, p);
            borderPen.Dispose();

            p.Dispose();
        }

        public void SetLoadingStatus(int progress)
        {
            progressBar.Increment(progress);
            this.Refresh();
        }
    }
}
