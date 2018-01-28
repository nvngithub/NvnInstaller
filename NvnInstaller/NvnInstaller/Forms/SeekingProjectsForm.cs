using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NvnInstaller {
    public partial class SeekingProjectsForm : Form {
        public SeekingProjectsForm() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lnkCoderlabz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://www.coderlabz.com");
        }

        private void lnkNvnInstaller_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://www.nvninstaller.com");
        }

        private void lnkErachana_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://erachana.net/");
        }

        private void lnkUdemyVideos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.udemy.com/codeless-database-application-development-tremplin");
        }

        private void lnkTrip2Success_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://trip2success.com/");
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("mailto:naveen@areteinfosystems.com");
        }
    }
}
