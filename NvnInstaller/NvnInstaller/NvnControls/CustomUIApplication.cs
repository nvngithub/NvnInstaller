using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace NvnInstaller {
    public partial class CustomUIApplication : UserControl {

        List<NameValue> items = new List<NameValue>();
        List<NameValue> selectedItems = new List<NameValue>();
        CurrencyManager cmItems, cmSelectedItems;

        public List<NameValue> SelectedItems {
            get { return selectedItems; }
        }

        public bool IsCustomUiUsed {
            get {
                return lstSelectedFiles.Items.Count > 0;
            }
        }

        public CustomUIApplication() {
            InitializeComponent();

            lstFiles.DisplayMember = "Name";
            lstFiles.ValueMember = "Value";
            lstFiles.DataSource = items;
            cmItems = (CurrencyManager)this.BindingContext[items];

            lstSelectedFiles.DisplayMember = "Name";
            lstSelectedFiles.ValueMember = "Value";
            lstSelectedFiles.DataSource = selectedItems;
            cmSelectedItems = (CurrencyManager)this.BindingContext[selectedItems];

            cmbPrerequisites.DisplayMember = "Name";
            cmbPrerequisites.ValueMember = "Value";
            cmbPrerequisites.DataSource = Common.GetInstalledBootstrappersList();

            Globals.SelectedPrerequisiteChanged += new EventHandler(Globals_SelectedPrerequisiteChanged);
        }

        void Globals_SelectedPrerequisiteChanged(object index, EventArgs e) {
            cmbPrerequisites.SelectedIndex = (int)index;
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            dlg.ShowNewFolderButton = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                txtUiAppPath.Text = dlg.SelectedPath;
            }
        }

        private void txtUiAppPath_TextChanged(object sender, EventArgs e) {
            if (Directory.Exists(txtUiAppPath.Text)) {
                items.Clear();
                selectedItems.Clear();
                foreach (string file in Directory.GetFiles(txtUiAppPath.Text)) {
                    items.Add(new NameValue(Path.GetFileName(file), file));
                }

                cmItems.Refresh();
                cmSelectedItems.Refresh();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            if (lstFiles.SelectedItem == null) return;
            NameValue selectedValue = (NameValue)lstFiles.SelectedItem;
            foreach (NameValue val in selectedItems) {
                if (val.Value == selectedValue.Value) {
                    return;
                }
            }

            selectedItems.Add(selectedValue);
            items.Remove(selectedValue);

            cmItems.Refresh();
            cmSelectedItems.Refresh();
        }

        private void btnSelectAll_Click(object sender, EventArgs e) {
            foreach (NameValue val in items) {
                selectedItems.Add(val);
            }

            items.Clear();

            cmItems.Refresh();
            cmSelectedItems.Refresh();
        }

        private void btnUnselect_Click(object sender, EventArgs e) {
            if (lstSelectedFiles.SelectedItem == null) return;
            NameValue selectedValue = (NameValue)lstSelectedFiles.SelectedItem;
            foreach (NameValue val in items) {
                if (val.Value == selectedValue.Value) {
                    return;
                }
            }

            items.Add(selectedValue);
            selectedItems.Remove(selectedValue);

            cmItems.Refresh();
            cmSelectedItems.Refresh();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e) {
            foreach (NameValue val in selectedItems) {
                items.Add(val);
            }

            selectedItems.Clear();

            cmItems.Refresh();
            cmSelectedItems.Refresh();
        }

        private void cmbPrerequisites_SelectedIndexChanged(object sender, EventArgs e) {
            Globals.NotifySelectedPrerequisiteChanged(cmbPrerequisites.SelectedIndex);
        }
    }
}
