using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NvnInstaller {
    public partial class TermsForm : Form {
        string licenseFile = Globals.applicationFolder + @"Licenses\Nvn Installer.rtf";
        public TermsForm() {
            InitializeComponent();
            ShowLicense(licenseFile);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ShowLicense(string licenseFile) {
            using (FileStream fileReader = File.Open(licenseFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                using (StreamReader reader = new StreamReader(fileReader)) {
                    txtTerms.Rtf = reader.ReadToEnd();
                }
            }
        }

        private void mnuNotepad_Click(object sender, EventArgs e) {
            Process.Start("notepad.exe", licenseFile);
        }

        private void mnuWordpad_Click(object sender, EventArgs e) {
            Process.Start("wordpad.exe", "\"" + licenseFile + "\"");
        }

        private void mnuMicrosoftWord_Click(object sender, EventArgs e) {
            // TODO: check whether this application exists in machine
            Process.Start("winword.exe", "\"" + licenseFile + "\"");
        }

        private void mnuSaveAs_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.AddExtension = true;
            dlg.DefaultExt = "txt";
            dlg.Title = "Where do you want to save the file?";
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (File.Exists(licenseFile)) {
                    File.Copy(licenseFile, dlg.FileName, true);
                }
            }
        }
    }
}
