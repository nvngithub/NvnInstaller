using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller {
    public partial class LogForm : Form {
        public LogForm() {
            InitializeComponent();
        }

        public string LogType {
            set {
                switch (value) {
                    case "N": txtLogType.Text = "Nvn Installer Log"; break;
                    case "B": txtLogType.Text = "Build Scheduler Log"; break;
                    case "C": txtLogType.Text = "Nvn Installer Console Log"; break;
                }
            }
        }

        public string DateTime {
            set { txtDateTime.Text = value; }
        }

        public string Message {
            set { txtMessage.Text = value; }
        }

        public string Exception {
            set { txtException.Text = value; }
        }
    }
}
