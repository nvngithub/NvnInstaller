using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileAssociationSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public string FilePath {
            set { this.label1.Text = value; }
        }
    }
}
