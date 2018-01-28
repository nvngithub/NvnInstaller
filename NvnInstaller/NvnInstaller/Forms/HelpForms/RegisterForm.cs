using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace NvnInstaller {
    public partial class RegisterForm : Form {
        string registrationKey = string.Empty;

        public RegisterForm() {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            // validate key entered
            LicenceKeyValidator.Validate(txtKey.Text);
            if (Globals.registered) {
                registrationKey = txtKey.Text;
                using (TextWriter writer = new StreamWriter(Globals.productKeyFile, false)) {
                    writer.Write(registrationKey);
                }
                MessageBox.Show("This software is successfully registered.", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {
                MessageBox.Show("Invalid key! Please enter the valid key", "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e) {
            this.Visible = false;
            if (Globals.registered) {
                MessageBox.Show("This product has already been registered.", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {
                this.Visible = true;
            }
        }

        private void lnkGetRegistrationKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://www.nvninstaller.com/register");
        }
    }

    class LicenceKeyValidator {
        [DllImport(@"Register.dll")]
        private static extern int ValidateKey([MarshalAs(UnmanagedType.LPStr)]string key);

        static string registrationKey = string.Empty;
        public static bool Validate() {
            if (File.Exists(Globals.productKeyFile)) {
                using (TextReader reader = new StreamReader(Globals.productKeyFile)) {
                    registrationKey = reader.ReadToEnd();
                    return (Globals.registered = Validate(registrationKey));
                }
            }
            return false;
        }

        public static bool Validate(string key) {
            if (String.IsNullOrEmpty(key))
                return false;
            return (Globals.registered = ValidateKey(key) == 0);
        }
    }
}