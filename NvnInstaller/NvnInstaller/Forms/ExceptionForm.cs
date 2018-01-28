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
    public partial class ExceptionForm : Form
    {
        string subject = "Unexpected Error", email = "support@nvninstaller.com";

        public ExceptionForm()
        {
            InitializeComponent();
            pbIcon.Image = new Bitmap(Globals.imagesFolder + "NvnInstaller-48.bmp");
        }

        public ExceptionForm(Exception exc) : this()
        {
            txtError.Text = exc.Message + Environment.NewLine + exc.StackTrace;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("explorer");
            procStartInfo.Arguments = String.Format("mailto:{0}?subject={1}&body={2}", email, subject, txtError.Text);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();

            this.Close();
        }

        private void btnViewLogs_Click(object sender, EventArgs e) {
            LogViewerForm logViewerForm = new LogViewerForm();
            logViewerForm.ShowDialog();
        }
    }
}
