using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Wix = NvnInstaller.WixClasses;
using System.IO;

namespace NvnInstaller.Scheduler {
    public partial class BuildSchedulerControl : UserControl {
        public BuildSchedulerControl() {
            InitializeComponent();

            LoadSchedules();
        }

        private void LoadSchedules() {
            if (File.Exists(Common.schedulePath)) {
                XmlSerializer ser = new XmlSerializer(typeof(Schedules));
                using (TextReader reader = new StreamReader(Common.schedulePath)) {
                    Schedules schedules = (Schedules)ser.Deserialize(reader);
                    if (schedules != null) {
                        dgrSchedules.Rows.Clear();
                        foreach (Schedule schedule in schedules.ScheduleList) {
                            int index = dgrSchedules.Rows.Add();
                            dgrSchedules[indexColumn.Name, index].Value = index + 1;
                            dgrSchedules[projectFileColumn.Name, index].Value = schedule.ProjectFile;
                            dgrSchedules[editColumn.Name, index].Value = "Edit";
                            dgrSchedules[deleteColumn.Name, index].Value = "Delete";
                            dgrSchedules.Rows[index].Tag = schedule;
                        }
                    }
                }
            }
        }

        private void SaveSchedules() {
            //create schedules
            Schedules schedules = new Schedules();
            foreach (DataGridViewRow row in dgrSchedules.Rows) {
                schedules.ScheduleList.Add((Schedule)row.Tag);
            }

            //serialise
            XmlSerializer s = new XmlSerializer(typeof(Schedules));
            TextWriter w = new StreamWriter(Common.schedulePath);
            s.Serialize(w, schedules);
            w.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            ScheduleItemForm newScheduleForm = new ScheduleItemForm();
            if (newScheduleForm.ShowDialog() == DialogResult.OK) {
                // add this schedule to data grid
                Schedule schedule = newScheduleForm.Schedule;
                int index = dgrSchedules.Rows.Add();
                dgrSchedules[indexColumn.Name, index].Value = index + 1;
                dgrSchedules[projectFileColumn.Name, index].Value = schedule.ProjectFile;
                dgrSchedules[editColumn.Name, index].Value = "Edit";
                dgrSchedules[deleteColumn.Name, index].Value = "Delete";
                dgrSchedules.Rows[index].Tag = schedule;
            }

            SaveSchedules();
        }

        private void dgrSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == deleteColumn.Index) {
                dgrSchedules.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex == editColumn.Index) {
                Schedule schedule = (Schedule)dgrSchedules.Rows[e.RowIndex].Tag;
                ScheduleItemForm scheduleForm = new ScheduleItemForm();
                scheduleForm.Schedule = schedule;
                if (scheduleForm.ShowDialog() == DialogResult.OK) {
                    // update grid item
                    int index = e.RowIndex;
                    dgrSchedules[projectFileColumn.Name, index].Value = scheduleForm.Schedule.ProjectFile;
                    dgrSchedules.Rows[index].Tag = scheduleForm.Schedule;

                    SaveSchedules();
                }
            }
        }
    }
}
