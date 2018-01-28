#if Standard
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller
{
    public partial class ProductKeyControl : UserControl
    {
        public ProductKeyControl()
        {
            InitializeComponent();
        }

        private void btnBrowseDll_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "DLL Files|*.dll";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtValidationDll.Text = dlg.FileName;
            }
        }
    }
}
#endif