using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Data.SQLite;

namespace NvnInstaller {
    public partial class LogViewerForm : Form {
        /*insert into log values ('2009-09-22', '15:13:15','test message', '','N')*/
        public static string appDbConnectionString = String.Format(@"Data Source = {0}", Common.applicationLogsDb);
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter();
        DataSet dsLogs = new DataSet();
        string selectedLogType = "N";

        public LogViewerForm() {
            InitializeComponent();
            pictureBox.Image = new Bitmap(Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\NvnInstaller-48.bmp");

            if (File.Exists(Common.applicationLogsDb) == false && File.Exists("Logs.s3db")) {
                File.Copy("Logs.s3db", Common.applicationLogsDb, true);
            }

            RefreshData();

            lstLogTypes.DisplayMember = cmbLogType.DisplayMember = "Name";
            lstLogTypes.ValueMember = cmbLogType.ValueMember = "Value";
            lstLogTypes.DataSource = cmbLogType.DataSource = new List<NameValue>() { new NameValue("NvnInstaller Logs", "N"), new NameValue("NvnInstaller Console Logs", "C"), new NameValue("Build Scheduler Logs", "B") };
        }

        private void RefreshData() {
            dsLogs = new DataSet();

            SQLiteConnection connection = new SQLiteConnection(appDbConnectionString);
            connection.Open();
            dataAdapter.SelectCommand = new SQLiteCommand("select * from log", connection);
            dataAdapter.Fill(dsLogs, "Logs");
            connection.Close();

            lstLogTypes.SelectedValue = selectedLogType;
            LoadLogGrid();
        }

        private void LoadLogGrid() {
            dgrLogs.DataSource = dsLogs.Tables["Logs"];
            switch (selectedLogType) {
                case "N":
                    ((DataTable)dgrLogs.DataSource).DefaultView.RowFilter = "Type = 'N'";
                    break;
                case "C":
                    ((DataTable)dgrLogs.DataSource).DefaultView.RowFilter = "Type = 'C'";
                    break;
                case "B":
                    ((DataTable)dgrLogs.DataSource).DefaultView.RowFilter = "Type = 'B'";
                    break;
            }

            if (dgrLogs.Columns.Contains("Type")) dgrLogs.Columns["Type"].Visible = false;
            if (dgrLogs.Columns.Contains("Exception")) dgrLogs.Columns["Exception"].Visible = false;            
        }

        private void lstLogTypes_SelectedIndexChanged(object sender, EventArgs e) {
            selectedLogType = (string)lstLogTypes.SelectedValue;
            LoadLogGrid();
        }

        private void mnuRefresh_Click(object sender, EventArgs e) { RefreshData(); }

        private void mnuClearNvnInstallerLogs_Click(object sender, EventArgs e) { DeleteLog("N"); }

        private void mnuClearBuildSchedulerLogs_Click(object sender, EventArgs e) { DeleteLog("B"); }

        private void mnuClearNvnInstallerConsoleLogs_Click(object sender, EventArgs e) { DeleteLog("C"); }

        private void mnuClearAll_Click(object sender, EventArgs e) { DeleteLog(""); }

        private void DeleteLog(string type) {
            string sql = "delete from log";
            if (type != string.Empty) {
                sql = String.Format("delete from log where Type = '{0}'", type);
            }

            SQLiteConnection connection = new SQLiteConnection(appDbConnectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

            RefreshData();
        }

        private void mnuExit_Click(object sender, EventArgs e) { this.Close(); }

        private void btnFilter_Click(object sender, EventArgs e) {
            DataTable datasource = (DataTable)dgrLogs.DataSource;
            string filter = string.Empty;

            if (dtpDate.Checked) {
                filter = String.Format("Date ='{0}'", dtpDate.Value.ToString("MM/dd/yyyy"));
            }

            if (txtSearch.Text != string.Empty) {
                filter = (filter == string.Empty ? string.Empty : filter + " AND ") + String.Format("Message LIKE '%{0}%'", txtSearch.Text);
            }
            
            datasource.DefaultView.RowFilter = filter;
        }

        private void lnkClearFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DataTable datasource = (DataTable)dgrLogs.DataSource;
            datasource.DefaultView.RowFilter = string.Empty;
            lstLogTypes.SelectedIndex = 0;
        }

        private void dgrLogs_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ShowDetails();
        }

        private void dgrLogs_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 0) {
                ShowDetails();
            }
        }

        private void ShowDetails() {
            if (dgrLogs.SelectedRows.Count > 0) {
                LogForm logForm = new LogForm();
                DataGridViewRow selectedRow = dgrLogs.SelectedRows[0];
                logForm.LogType = (string)selectedRow.Cells["Type"].Value;
                logForm.DateTime = ((DateTime)selectedRow.Cells[DateColumn.Name].Value).ToString("dd MMMM yyyy") + "  " + ((DateTime)selectedRow.Cells[TimeColumn.Name].Value).ToString("HH:mm:ss");
                logForm.Message = (string)selectedRow.Cells[MessageColumn.Name].Value;
                logForm.Exception = (string)selectedRow.Cells["Exception"].Value;
                logForm.ShowDialog();
            }
        }
    }
}
