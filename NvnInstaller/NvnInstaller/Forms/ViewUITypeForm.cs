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
    public partial class ViewUITypeForm : Form
    {
        FileInfo[] files;
        int index = 0;
        public ViewUITypeForm(UIType type)
        {
            InitializeComponent();

            string dir = Globals.imagesFolder + @"UserInterfaceSamples\" + type.ToString();
            this.Text = type.ToString();
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            files = dirInfo.GetFiles();
        }

        private void ViewUITypeForm_Load(object sender, EventArgs e)
        {
            // load specific images from folder based on type
            if (files.Length > 0)
            {
                pbSampleImage.ImageLocation = files[0].FullName;
            }
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            index++;
            if (index == files.Length)
            {
                index = 0;
            }
            pbSampleImage.ImageLocation = files[index].FullName;
        }

        private void ViewUITypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index--;
            if (index == -1)
            {
                index = files.Length - 1;
            }
            pbSampleImage.ImageLocation = files[index].FullName;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            if (index == files.Length)
            {
                index = 0;
            }
            pbSampleImage.ImageLocation = files[index].FullName;
        }
    }
}
