using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller
{
    public partial class OutputControl : UserControl {
        private SysImageList sysilsSmall = new SysImageList(SysImageListSize.smallIcons);
        Bitmap errorImage, warningImage, infoImage;
        public OutputControl() {
            InitializeComponent();
            // button images
            btnErrors.Image = errorImage = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgError, true)).ToBitmap();
            btnWarnings.Image = warningImage = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgWarning, true)).ToBitmap();
            btnInformation.Image = infoImage = sysilsSmall.Icon(sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgInformation, true)).ToBitmap();
            // EventHandlers
            BuildLogger.MessageLogged += new EventHandler<BuildLogMessage>(Logger_MessageLogged);
            Globals.ApplicationClosing += new EventHandler(Globals_ApplicationClosing);
            Globals.BuildProgressChanged += new EventHandler<BuildProgressEventArgs>(Globals_BuildProgressChanged);
            dgrOutputMessages.DataError += new DataGridViewDataErrorEventHandler(dgrOutputMessages_DataError);
        }

        void dgrOutputMessages_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.ThrowException = false;
        }

        private void OutputControl_Load(object sender, EventArgs e) {
            string setting = Profile.Get("Output.Error");
            if (String.IsNullOrEmpty(setting) == false) {
                btnErrors.Checked = Convert.ToBoolean(setting);
            }
            setting = Profile.Get("Output.Warning");
            if (String.IsNullOrEmpty(setting) == false) {
                btnWarnings.Checked = Convert.ToBoolean(setting);
            }
            setting = Profile.Get("Output.Information");
            if (String.IsNullOrEmpty(setting) == false) {
                btnInformation.Checked = Convert.ToBoolean(setting);
            }
        }

        void Globals_ApplicationClosing(object sender, EventArgs e) {
            Profile.Set("Output.Error", btnErrors.Checked.ToString());
            Profile.Set("Output.Warning", btnWarnings.Checked.ToString());
            Profile.Set("Output.Information", btnInformation.Checked.ToString());
        }

        public void Clear() {
            dgrOutputMessages.Rows.Clear();
            lblErrorCount.Text = BuildLogger.ErrorCount.ToString();
            lblWarningCount.Text = BuildLogger.WarningCount.ToString();
        }

        void Logger_MessageLogged(object sender, BuildLogMessage e) {
            try {
                int rowIndex = dgrOutputMessages.Rows.Add();
                dgrOutputMessages[indexColumn.Name, rowIndex].Value = rowIndex;
                dgrOutputMessages[messageColumn.Name, rowIndex].Value = e.Message;
                dgrOutputMessages[moduleColumn.Name, rowIndex].Value = e.Module.ToString();
                dgrOutputMessages.Rows[rowIndex].Tag = e;

                switch (e.Type) {
                    case LogType.ERROR:
                        dgrOutputMessages.Rows[rowIndex].Visible = btnErrors.Checked;
                        ((DataGridViewImageCell)dgrOutputMessages[logTypeColumn.Name, rowIndex]).Value = errorImage;
                        break;
                    case LogType.Warning:
                        dgrOutputMessages.Rows[rowIndex].Visible = btnWarnings.Checked;
                        ((DataGridViewImageCell)dgrOutputMessages[logTypeColumn.Name, rowIndex]).Value = warningImage;
                        break;
                    case LogType.Information:
                        dgrOutputMessages.Rows[rowIndex].Visible = btnInformation.Checked;
                        ((DataGridViewImageCell)dgrOutputMessages[logTypeColumn.Name, rowIndex]).Value = infoImage;
                        break;
                }

                // update error count labels
                lblErrorCount.Text = BuildLogger.ErrorCount.ToString();
                lblWarningCount.Text = BuildLogger.WarningCount.ToString();
            } catch (Exception exc) {
                Logger.ApplicationLog(new LogMessage(exc.Message, exc));
            }
        }

        private void btnErrors_Click(object sender, EventArgs e) {
            UpdateGridItems();
        }

        private void btnWarnings_Click(object sender, EventArgs e) {
            UpdateGridItems();
        }

        private void btnInformation_Click(object sender, EventArgs e) {
            UpdateGridItems();
        }

        private void UpdateGridItems() {
            foreach (DataGridViewRow row in dgrOutputMessages.Rows) {
                BuildLogMessage logMessage = (BuildLogMessage)row.Tag;
                switch (logMessage.Type) {
                    case LogType.ERROR: row.Visible = btnErrors.Checked; break;
                    case LogType.Warning: row.Visible = btnWarnings.Checked; break;
                    case LogType.Information: row.Visible = btnInformation.Checked; break;
                }
            }
            UpdateIndexNumbers();
        }

        private void UpdateIndexNumbers() {
            int index = 1;
            foreach (DataGridViewRow row in dgrOutputMessages.Rows) {
                if (row.Visible) {
                    row.Cells[indexColumn.Name].Value = index++;
                }
            }
        }

        void Globals_BuildProgressChanged(object sender, BuildProgressEventArgs e) {
            if (e.Progress == -1) {
                progressBar.Value = 0;
                progressBar.Visible = false;
                lblMessage.Text = e.Message;
                lblMessage.ForeColor = Color.Red;
            } else if (e.Progress == 0) {
                progressBar.Value = 0;
                progressBar.Visible = true;
                lblMessage.Text = e.Message;
                lblMessage.ForeColor = Color.Black;
            } else if (e.Progress == 100) {
                progressBar.Visible = false;
                lblMessage.Text = string.Empty;
            } else {
                progressBar.Increment(e.Progress);
                lblMessage.Text = e.Message;
            }
        }
    }

    public class BuildProgressEventArgs : EventArgs
    {
        public int Progress;
        public string Message;

        public BuildProgressEventArgs(int progress, string message)
        {
            this.Progress = progress;
            this.Message = message;
        }
    }
}
