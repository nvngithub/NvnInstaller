using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NvnInstaller
{
    public partial class SummaryForm : Form
    {
        List<SummaryControl> summaryControls = new List<SummaryControl>();

        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            // Load complete summary
            foreach (Control control in ControlsManager.Controls.Values)
            {
                if (control is INvnControl)
                {
                    List<Summary> summaries = ((INvnControl)control).GetSummary();
                    if (summaries != null)
                    {
                        AddControls(summaries);
                    }
                }
            }

            ArrangeControls();
        }

        private void AddControls(List<Summary> summaries)
        {
            foreach (Summary summary in summaries)
            {
                SummaryControl control = new SummaryControl(summary.Collapse);
                control.ControlSizeChanged += new EventHandler(control_ControlSizeChanged);
                summaryControls.Add(control);
                control.Title = summary.Title;
                control.Data = summary.Data;
                control.Width = this.ClientRectangle.Width - this.Padding.Right;
                control.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                pnlControls.Controls.Add(control);
            }
        }

        void control_ControlSizeChanged(object sender, EventArgs e)
        {
            ArrangeControls();
        }

        private void ArrangeControls()
        {
            for (int i = 0; i < this.summaryControls.Count; i++)
            {
                if (i == 0)
                {
                    this.summaryControls[i].Location = new Point(0, 0);
                }
                else
                {
                    SummaryControl previousControl = summaryControls[i - 1];
                    SummaryControl currentControl = summaryControls[i];
                    currentControl.Location = new Point(currentControl.Location.X, previousControl.Location.Y + previousControl.Height + previousControl.Padding.Bottom);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.AddExtension = true;
            dlg.DefaultExt = "csv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                SaveAsCSV(filename);
            }
        }

        private void SaveAsCSV(string filename)
        {
            // Create the CSV file to which grid data will be exported.
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                foreach (Control ctrl in pnlControls.Controls)
                {
                    if (ctrl is SummaryControl)
                    {
                        // First we will write the headers.
                        DataTable dt = ((SummaryControl)ctrl).Data;
                        int iColCount = dt.Columns.Count;
                        for (int i = 0; i < iColCount; i++)
                        {
                            sw.Write(dt.Columns[i]);
                            if (i < iColCount - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.Write(sw.NewLine);
                        // Now write all the rows.
                        foreach (DataRow dr in dt.Rows)
                        {
                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                {
                                    sw.Write(dr[i].ToString());
                                }
                                if (i < iColCount - 1)
                                {
                                    sw.Write(",");
                                }
                            }
                            sw.Write(sw.NewLine);
                        }
                        sw.Write(sw.NewLine);
                    }
                }
            }
        }
    }
}
