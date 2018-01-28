using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnInstaller;

namespace NvnInstaller.Scheduler {
    public partial class ScheduleItemForm : Form {
        Schedule schedule;

        public Schedule Schedule {
            get {
                return schedule;
            }
            set {
                schedule = value;
            }
        }

        public ScheduleItemForm() {
            InitializeComponent();
        }

        private void ScheduleItemForm_Load(object sender, EventArgs e) {
            cmbDateFormat.DataSource = DateFormat.Formats;
            cmbDateFormat.DisplayMember = "Format";
            cmbDateFormat.ValueMember = "Format";
            cmbNameFormat.DataSource = Enum.GetValues(typeof(NameFormat));

            // load schedule if it is not NULL
            if (schedule != null) {
                // days
                for (int i = 0; i < chkListDays.Items.Count; i++) {
                    chkListDays.SetItemCheckState(i, CheckState.Unchecked);
                }
                for (int i = 0; i < chkListDays.Items.Count; i++) {
                    string day = (string)chkListDays.Items[i];
                    if (schedule.Days.Contains(day)) {
                        chkListDays.SetItemCheckState(i, CheckState.Checked);
                    }
                }
                // months
                for (int i = 0; i < chkListMonths.Items.Count; i++) {
                    chkListMonths.SetItemCheckState(i, CheckState.Unchecked);
                }
                for (int i = 0; i < chkListMonths.Items.Count; i++) {
                    string day = (string)chkListMonths.Items[i];
                    if (schedule.Days.Contains(day)) {
                        chkListMonths.SetItemCheckState(i, CheckState.Checked);
                    }
                }
                //exclude dates
                dgrExcludeDates.Rows.Clear();
                foreach (DateTime date in schedule.ExcludeDates) {
                    int rowIndex = dgrExcludeDates.Rows.Add();
                    dgrExcludeDates[0, rowIndex].Value = date.ToString("dddd, dd MMMM");
                    dgrExcludeDates.Rows[rowIndex].Tag = date;
                }
                // execute times
                dgrTimes.Rows.Clear();
                foreach (DateTime time in schedule.ExecutionTimes) {
                    int rowIndex = dgrTimes.Rows.Add();
                    dgrTimes[0, rowIndex].Value = time.ToShortTimeString();
                    dgrTimes.Rows[rowIndex].Tag = time;
                }
                // other properties
                txtProjectFile.Text = schedule.ProjectFile;
                txtRootFolder.Text = schedule.RootFolder;
                cmbNameFormat.SelectedItem = schedule.NameFormat;
                cmbDateFormat.SelectedValue = schedule.DateFormat;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidateUserInput()) {
                schedule = new Schedule();
                foreach (string day in chkListDays.CheckedItems) {
                    schedule.Days.Add(day);
                }
                foreach (string month in chkListMonths.CheckedItems) {
                    schedule.Months.Add(month);
                }
                foreach (DataGridViewRow timeRow in dgrTimes.Rows) {
                    schedule.ExecutionTimes.Add((DateTime)timeRow.Tag);
                }
                foreach (DataGridViewRow excludeDateRow in dgrExcludeDates.Rows) {
                    schedule.ExcludeDates.Add((DateTime)excludeDateRow.Tag);
                }
                schedule.ProjectFile = txtProjectFile.Text;
                schedule.RootFolder = txtRootFolder.Text;
                schedule.DateFormat = cmbDateFormat.Text;
                schedule.NameFormat = (NameFormat)cmbNameFormat.SelectedValue;
                //Close Form
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateUserInput() {
            if (String.IsNullOrEmpty(txtProjectFile.Text)) {
                MessageBox.Show("No project file is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(txtRootFolder.Text)) {
                MessageBox.Show("No valid root folder value is set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dgrTimes.Rows.Count == 0) {
                MessageBox.Show("No execution time is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(cmbDateFormat.Text)) {
                MessageBox.Show("No date format is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(cmbNameFormat.Text)) {
                MessageBox.Show("No name format is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (chkListDays.CheckedIndices.Count == 0) {
                MessageBox.Show("No valid days are selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (chkListMonths.CheckedIndices.Count == 0) {
                MessageBox.Show("No valid months are selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }

        private void chkListDays_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (e.Index == 0 && e.NewValue == CheckState.Checked) {
                for (int i = 1; i < chkListDays.Items.Count; i++) {
                    chkListDays.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            if (e.Index != 0 && e.NewValue == CheckState.Checked) {
                chkListDays.SetItemCheckState(0, CheckState.Unchecked);
            }
        }

        private void chkListMonths_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (e.Index == 0 && e.NewValue == CheckState.Checked) {
                for (int i = 1; i < chkListMonths.Items.Count; i++) {
                    chkListMonths.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            if (e.Index != 0 && e.NewValue == CheckState.Checked) {
                chkListMonths.SetItemCheckState(0, CheckState.Unchecked);
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e) {
            DateTime time = dtpTime.Value;
            int rowIndex = dgrTimes.Rows.Add();
            dgrTimes[0, rowIndex].Value = time.ToShortTimeString();
            dgrTimes.Rows[rowIndex].Tag = time;
        }

        private void btnAddExcludeDate_Click(object sender, EventArgs e) {
            DateTime date = dtpTime.Value;
            int rowIndex = dgrExcludeDates.Rows.Add();
            dgrExcludeDates[0, rowIndex].Value = date.ToString("dddd, dd MMMM yyyy");
            dgrExcludeDates.Rows[rowIndex].Tag = date;
        }

        private void btnBrowseProjectFile_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.Filter = "NvnInstaller files|*.nvn";
            if (dlg.ShowDialog() == DialogResult.OK) {
                txtProjectFile.Text = dlg.FileName;
            }
        }

        private void btnBrowseRoot_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            if (dlg.ShowDialog() == DialogResult.OK) {
                txtRootFolder.Text = dlg.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
