using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace NvnInstaller
{
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();
            pictureBox.Image = new Bitmap(Globals.imagesFolder + "NvnInstaller-48.bmp");
            lblVersion.Text = "Version " + Globals.version;
        }
    }
}
