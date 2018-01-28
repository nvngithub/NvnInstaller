using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace NvnInstaller
{
    public partial class ViewUIControl : UserControl
    {
        private DataSet dsText;
        private List<string> dialogs = new List<string>();
        private int currentIndex = -1;
        private int labelOffset = 164;

        public ViewUIControl()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        public List<string> Dialogs
        {
            get
            {
                return dialogs;
            }
            set
            {
                dialogs = value;
            }
        }

        public DataSet UITextDataset
        {
            set
            {
                dsText = value;
            }
        }

        public string BannerImg
        {
            set
            {
                if (value != null)
                    pbBanner.Load(value);
            }
        }

        public string DialogImg
        {
            set
            {
                if(value != null)
                    pbDialog.Load(value);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (dsText != null)
            {
                currentIndex++;
                if (currentIndex == dialogs.Count)
                {
                    currentIndex = 0;
                }
                // TODO:eexlude some dialog based on user interface type
                DataTable uiTable = dsText.Tables[dialogs[currentIndex]];
                if (uiTable != null)
                {
                    // clear all label controls
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Label)
                        {
                            this.Controls.Remove(ctrl);
                        }
                    }
                    // create text label to show over picture box
                    foreach (DataRow row in uiTable.Rows)
                    {
                        // create label on the image 
                        int x = int.Parse((string)row["x"]);
                        int y = int.Parse((string)row["y"]);
                        int width = int.Parse((string)row["width"]);
                        int height = int.Parse((string)row["height"]);
                        Label lbl = new Label();
                        lbl.BackColor = Color.Transparent;
                        lbl.Tag = (string)row["id"];
                        lbl.Text = (string)row["text"];
                        lbl.Size = new Size(width, height);
                        lbl.Location = new Point(labelOffset + x, pbDialog.Location.Y + y);
                        this.Controls.Add(lbl);
                    }

                    pbBanner.SendToBack();
                    pbDialog.SendToBack();
                }
            }
        }
    }
}
