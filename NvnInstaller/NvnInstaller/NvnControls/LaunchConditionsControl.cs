using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using Microsoft.Win32;

namespace NvnInstaller {
    public partial class LaunchConditionsControl : UserControl {
        LaunchCondition selectedCondition;

        public LaunchConditionsControl() {
            InitializeComponent();
            conoditionItems.GridHeader.HeaderText = "Launch Conditions";
            conoditionItems.ItemDeleted += new EventHandler<GridItemEventArgs>(conoditionItems_ItemDeleted);
            conoditionItems.ItemSelectionChanged += new EventHandler<GridItemEventArgs>(conoditionItems_ItemSelectionChanged);
            ControlsManager.PropertyControl.UserDefinedPropertyChanged += new EventHandler(PropertyControl_UserDefinedPropertyChanged);

            LoadWindowsProperties();
            LoadUsefulProperties();
        }

        void PropertyControl_UserDefinedPropertyChanged(object sender, EventArgs e) {
            LoadUserDefinedProperties();
        }

        private void LoadUserDefinedProperties() {
            dgrUserDefinedProperties.Rows.Clear();
            foreach (WindowsProperty property in ControlsManager.PropertyControl.Properties) {
                dgrUserDefinedProperties.Rows.Add(property.Name, property.Description);
            }
        }

        private void LoadWindowsProperties() {
            if (File.Exists(Globals.settingsPath)) {
                XmlDocument doc = new XmlDocument();
                doc.Load(Globals.settingsPath);
                XmlNodeList nodeList = doc.DocumentElement.GetElementsByTagName("WindowsProperty");
                foreach (XmlNode node in nodeList) {
                    dgrWindowsProperties.Rows.Add(node.Attributes["Name"].Value, node.Attributes["Description"].Value);
                }
            }
        }

        private void LoadUsefulProperties() {
            if (File.Exists(Globals.settingsPath)) {
                XmlDocument doc = new XmlDocument();
                doc.Load(Globals.settingsPath);
                XmlNodeList nodeList = doc.DocumentElement.GetElementsByTagName("UsefulConditions");
                if (nodeList.Count > 0) {
                    XmlNodeList nodes = nodeList[0].ChildNodes;
                    foreach (XmlNode node in nodes) {
                        dgrUsefulConditions.Rows.Add(node.Attributes["Condition"].Value, node.Attributes["Description"].Value);
                    }
                }
            }
        }

        void conoditionItems_ItemSelectionChanged(object sender, GridItemEventArgs e) {
            UpdateSelectedCondition(true);

            if (e.SelectedItem != null) {
                selectedCondition = (LaunchCondition)e.SelectedItem;
                txtConditionName.Text = selectedCondition.Name;
                txtCondition.Text = selectedCondition.Condition;
                txtFailMessage.Text = selectedCondition.FailMessage;
            }
        }

        void conoditionItems_ItemDeleted(object sender, GridItemEventArgs e) {
            txtConditionName.Text = txtCondition.Text = txtFailMessage.Text = string.Empty;
        }

        private void mnuAddNewCondition_Click(object sender, EventArgs e) {
            UpdateSelectedCondition(true);

            LaunchCondition condition = new LaunchCondition();
            conoditionItems.AddNewItem(condition);
        }

        private void mnuDeleteSelectedCondition_Click(object sender, EventArgs e) {
            selectedCondition = null;
            conoditionItems.DeleteSelectedItem();
        }

        private void mnuClearAllConditions_Click(object sender, EventArgs e) {
            conoditionItems.ClearItems();
        }

        private void SaveSelectedCondition_Click(object sender, EventArgs e) {
            UpdateSelectedCondition(false);
        }

        private void UpdateSelectedCondition(bool setSelectedItemNull) {
            if (selectedCondition != null) {
                selectedCondition.Name = txtConditionName.Text;
                selectedCondition.Condition = txtCondition.Text;
                selectedCondition.FailMessage = txtFailMessage.Text;

                conoditionItems.UpdateSelectedItemText(selectedCondition.Name);
            }

            if (setSelectedItemNull) selectedCondition = null;
        }

        private void lnkConditionalSyntax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://msdn.microsoft.com/en-us/library/aa368012(VS.85).aspx");
        }

        private void lnkPropertyReference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://msdn.microsoft.com/en-us/library/aa370905(VS.85).aspx");
        }

        private void dgrUsefulConditions_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            txtCondition.Text = (string)dgrUsefulConditions[0, e.RowIndex].Value;
        }

        private void dgrUserDefinedProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            txtCondition.Text += (string)dgrUserDefinedProperties[0, e.RowIndex].Value;
        }

        private void dgrWindowsProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            txtCondition.Text += (string)dgrWindowsProperties[0, e.RowIndex].Value;
        }

        private void txtConditionName_TextChanged(object sender, EventArgs e) {
            conoditionItems.UpdateSelectedItemText(txtConditionName.Text);
        }
    }
}
