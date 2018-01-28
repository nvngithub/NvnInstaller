using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace NvnInstaller.MsiDotNet {
    public partial class FinishForm : Form {
        public FinishForm() {
            InitializeComponent();

            lblVersion.Text = "Version 1.0";
        }
    }
}
