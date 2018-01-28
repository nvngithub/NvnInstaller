using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Reflection;

namespace NvnInstaller.Scheduler {
    public partial class MainForm : Form {
        Timer timer = new Timer();
        Schedules schedules;
        static int fileNumber = 0;

        public MainForm() {
            InitializeComponent();

            timer.Interval = 59000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;

            mnuStartBuildScheduler.Enabled = startBuildSchedulerToolStripMenuItem.Enabled = !timer.Enabled;
            mnuStopBuildScheduler.Enabled = stopBuildSchedulerToolStripMenuItem.Enabled = timer.Enabled;
        }

        private void mnuOpen_Click(object sender, EventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void mnuClose_Click(object sender, EventArgs e) {
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void mnuStartBuildScheduler_Click(object sender, EventArgs e) {
            timer.Enabled = true;

            mnuStartBuildScheduler.Enabled = startBuildSchedulerToolStripMenuItem.Enabled = !timer.Enabled;
            mnuStopBuildScheduler.Enabled = stopBuildSchedulerToolStripMenuItem.Enabled = timer.Enabled;
        }

        private void mnuStopBuildScheduler_Click(object sender, EventArgs e) {
            timer.Enabled = false;

            mnuStartBuildScheduler.Enabled = startBuildSchedulerToolStripMenuItem.Enabled = !timer.Enabled;
            mnuStopBuildScheduler.Enabled = stopBuildSchedulerToolStripMenuItem.Enabled = timer.Enabled;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

        #region Scheduler Methods

        void Timer_Tick(object sender, EventArgs e) {
            try {
                DateTime currentTime = DateTime.Now;

                LoadSchedules();
                if (schedules == null) return;

                foreach (Schedule schedule in schedules.ScheduleList) {
                    bool execute = true;
                    // exclude dates
                    for (int i = 0; execute && i < schedule.ExcludeDates.Count; i++) {
                        DateTime excludeDate = schedule.ExcludeDates[i];
                        if (currentTime.Date.Equals(excludeDate.Date)) {
                            execute = false;
                        }
                    }
                    if (execute && ((schedule.Days.Count > 0 && schedule.Days[0] != "All") &&
                      schedule.Days.Contains(currentTime.ToString("dddd")) == false)) {
                        execute = false;
                    }
                    if (execute && ((schedule.Months.Count > 0 && schedule.Months[0] != "All") &&
                      schedule.Months.Contains(currentTime.ToString("MMMM")) == false)) {
                        execute = false;
                    }

                    if (execute) {
                        for (int i = 0; i < schedule.ExecutionTimes.Count; i++) {
                            DateTime executeTime = schedule.ExecutionTimes[i];
                            if (executeTime.Hour == currentTime.Hour && executeTime.Minute == currentTime.Minute) {
                                Logger.BuildSchedulerLog(new LogMessage("Current time match build time and settings.", null));
                                // run respective task              
                                string outputDir = GetOutputDir(schedule);
                                string outputPath = outputDir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(schedule.ProjectFile) + ".msi";
                                string arguments = "-o=\"" + outputPath + "\" -bc -f=\"" + schedule.ProjectFile + "\"";
                                Process.Start((new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName) + @"\NvnInstaller.Console.exe", arguments);

                                Logger.BuildSchedulerLog(new LogMessage("Building the scheduled project:" + schedule.ProjectFile + ". Output location " + outputDir, null));
                                break;
                            }
                        }
                    }
                }
            } catch (Exception exc) {
                Logger.BuildSchedulerLog(new LogMessage(string.Empty, exc));
            }
        }

        private void LoadSchedules() {
            try {
                if (File.Exists(Common.schedulePath)) {
                    // Load XML file
                    XmlSerializer ser = new XmlSerializer(typeof(Schedules));
                    using (FileStream reader = new FileStream(Common.schedulePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                        schedules = (Schedules)ser.Deserialize(reader);
                    }
                }
            } catch (Exception exc) {
                Logger.BuildSchedulerLog(new LogMessage(string.Empty, exc));
            }
        }

        private string GetOutputDir(Schedule schedule) {
            string projectFileName = Path.GetFileNameWithoutExtension(schedule.ProjectFile);
            string rootPath = schedule.RootFolder;
            string outputFolder = string.Empty;

            switch (schedule.NameFormat) {
                case NameFormat.Name_DateFormat:
                    outputFolder = projectFileName + "_" + DateTime.Now.ToString(schedule.DateFormat);
                    break;
                case NameFormat.Name_Number:
                    outputFolder = projectFileName + "_" + fileNumber;
                    while (Directory.Exists(rootPath + Path.DirectorySeparatorChar + outputFolder)) {
                        fileNumber++;
                        outputFolder = projectFileName + "_" + fileNumber;
                    }
                    fileNumber++;
                    break;
            }

            return rootPath + Path.DirectorySeparatorChar + outputFolder;
        }

        #endregion
    }
}
