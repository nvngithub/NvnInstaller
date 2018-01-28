using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NvnInstaller
{
    public partial class FreelanceForm : Form
    {
        public FreelanceForm()
        {
            InitializeComponent();
            pbIcon.Image = new Bitmap(Globals.imagesFolder + "NvnInstaller-48.bmp");

            dgrFreelance.Rows.Add("Technology expertise", "Software application development using C#, SQL etc");
            dgrFreelance.Rows.Add("Hourly rate", "15 USD - 20 USD");
            dgrFreelance.Rows.Add("Payment Method", "Using ShareIt!. Contact me for more information.");
            dgrFreelance.Rows.Add("Affiliates", "I am ready to share 25% revenue if you can get me software development projects. Contact me for more information.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
