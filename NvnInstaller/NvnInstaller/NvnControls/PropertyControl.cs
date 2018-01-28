using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using NvnInstaller.Properties;
using System.IO;
using System.Reflection;
using System.Xml;

namespace NvnInstaller {
    public partial class PropertyControl : UserControl {
        List<string> windowsProperties = new List<string>();
        WindowsProperty selectedProperty;
        public event EventHandler UserDefinedPropertyChanged;

        public PropertyControl() {
            InitializeComponent();
            cmbSearchType.DataSource = Enum.GetNames(typeof(PropertySearchType));
            LoadWindowsProperties();

            propertyItems.GridHeader.HeaderText = "Properties";
            propertyItems.ItemDeleted += new EventHandler<GridItemEventArgs>(propertyItems_ItemDeleted);
            propertyItems.ItemSelectionChanged += new EventHandler<GridItemEventArgs>(propertyItems_ItemSelectionChanged);
        }

        public List<WindowsProperty> Properties {
            get {
                List<WindowsProperty> properties = new List<WindowsProperty>();
                foreach (WindowsProperty property in propertyItems.Items) {
                    properties.Add(property);
                }
                return properties;
            }
        }

        private void LoadWindowsProperties() {
            DataTable dtProperties = null;

            if (File.Exists(Globals.settingsPath)) {
                XmlDocument doc = new XmlDocument();
                doc.Load(Globals.settingsPath);
                XmlNodeList nodeList = doc.DocumentElement.GetElementsByTagName("Properties");
                foreach (XmlNode node in nodeList) {
                    dtProperties = new DataTable();
                    dtProperties.Columns.Add("Name");
                    dtProperties.Columns.Add("Description");

                    // new Summary control
                    SummaryControl summaryCtrl = new SummaryControl(true);
                    summaryCtrl.Width = pnlSummaryControls.Width;
                    summaryCtrl.Title = node.Attributes["Type"].Value;
                    summaryCtrl.Data = dtProperties;
                    pnlSummaryControls.Controls.Add(summaryCtrl);

                    XmlNodeList childNodes = node.ChildNodes;
                    foreach (XmlNode childNode in childNodes) {
                        dtProperties.Rows.Add(childNode.Attributes["Name"].Value, childNode.Attributes["Description"].Value);
                        windowsProperties.Add(childNode.Attributes["Name"].Value);// this is used for validation
                    }
                }
            }
        }

        void propertyItems_ItemSelectionChanged(object sender, GridItemEventArgs e) {
            UpdateSelectedProperty(true);

            if (e.SelectedItem != null) {
                WindowsProperty property = (WindowsProperty)e.SelectedItem;
                txtPropertyName.Text = property.Name;
                txtDescription.Text = property.Description;
                txtDefaultValue.Text = property.DefaultValue;
                selectedProperty = property;
                cmbSearchType.SelectedItem = property.SearchType.ToString();
            }
        }

        void propertyItems_ItemDeleted(object sender, GridItemEventArgs e) {
            selectedProperty = null;

            txtDefaultValue.Text = txtPropertyName.Text = string.Empty;
            cmbSearchType.SelectedIndex = -1;
            dgrPropertySearch.Rows.Clear();
        }

        private void AddNewProperty_Click(object sender, EventArgs e) {
            UpdateSelectedProperty(true);

            WindowsProperty property = new WindowsProperty();
            txtPropertyName.Text = property.Name;
            txtDescription.Text = property.Description;
            txtDefaultValue.Text = property.DefaultValue;

            propertyItems.AddNewItem(property);
        }

        private void mnuDeleteSelectedProperty_Click(object sender, EventArgs e) {
            propertyItems.DeleteSelectedItem();
        }

        private void mnuClearAllProperties_Click(object sender, EventArgs e) {
            propertyItems.ClearItems();
        }

        private void SaveSelectedProperty_Click(object sender, EventArgs e) {
            UpdateSelectedProperty(false);
        }

        private void UpdateSelectedProperty(bool setSelectedItemNull) {
            if (selectedProperty != null) {
                selectedProperty.DefaultValue = txtDefaultValue.Text;
                selectedProperty.Description = txtDescription.Text;
                selectedProperty.Name = txtPropertyName.Text;

                switch (selectedProperty.SearchType) {
                    case PropertySearchType.DirectorySearch:
                        DirectorySearch dirSearch = (DirectorySearch)selectedProperty.propSearch[PropertySearchType.DirectorySearch];
                        dirSearch.DirectoryPath = (string)dgrPropertySearch[1, 0].Value;
                        dirSearch.Depth = (string)dgrPropertySearch[1, 1].Value;
                        break;
                    case PropertySearchType.FileSearch:
                        FileSearch fileSearch = (FileSearch)selectedProperty.propSearch[PropertySearchType.FileSearch];
                        fileSearch.DirectoryPath = (string)dgrPropertySearch[1, 0].Value;
                        fileSearch.Depth = (string)dgrPropertySearch[1, 1].Value;
                        fileSearch.FileName = (string)dgrPropertySearch[1, 2].Value;
                        break;
                    case PropertySearchType.INISearch:
                        INISearch iniSearch = (INISearch)selectedProperty.propSearch[PropertySearchType.INISearch];
                        iniSearch.Name = (string)dgrPropertySearch[1, 0].Value;
                        iniSearch.Section = (string)dgrPropertySearch[1, 1].Value;
                        iniSearch.Key = (string)dgrPropertySearch[1, 2].Value;
                        break;
                    case PropertySearchType.RegistrySearch:
                        RegistrySearch regSearch = (RegistrySearch)selectedProperty.propSearch[PropertySearchType.RegistrySearch];
                        regSearch.Root = (string)dgrPropertySearch[1, 0].Value;
                        regSearch.Key = (string)dgrPropertySearch[1, 1].Value;
                        regSearch.Name = (string)dgrPropertySearch[1, 2].Value;
                        break;
                }

                if (UserDefinedPropertyChanged != null) { UserDefinedPropertyChanged(null, null); }
            }

            if (setSelectedItemNull) selectedProperty = null;
        }

        private void lblCollapse_Click(object sender, EventArgs e) {
            if (lblCollapse.Text == "+") {
                lblCollapse.Text = "-";
                pnlSummaryControls.Visible = true;
            } else if (lblCollapse.Text == "-") {
                lblCollapse.Text = "+";
                pnlSummaryControls.Visible = false;
            }
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedProperty != null) {
                selectedProperty.SearchType = (PropertySearchType)Enum.Parse(typeof(PropertySearchType), (string)cmbSearchType.SelectedItem);
                dgrPropertySearch.Rows.Clear();
                switch (selectedProperty.SearchType) {
                    case PropertySearchType.DirectorySearch:
                        DirectorySearch dirSearch = (DirectorySearch)selectedProperty.propSearch[PropertySearchType.DirectorySearch];
                        dgrPropertySearch.Rows.Add(dirSearch.DirectoryPathText, dirSearch.DirectoryPath);
                        dgrPropertySearch.Rows.Add(dirSearch.DepthText, dirSearch.Depth);
                        dgrPropertySearch.Tag = dirSearch;
                        break;
                    case PropertySearchType.FileSearch:
                        FileSearch fileSearch = (FileSearch)selectedProperty.propSearch[PropertySearchType.FileSearch];
                        dgrPropertySearch.Rows.Add(fileSearch.DirectoryPathText, fileSearch.DirectoryPath);
                        dgrPropertySearch.Rows.Add(fileSearch.DepthText, fileSearch.Depth);
                        dgrPropertySearch.Rows.Add(fileSearch.FileNameText, fileSearch.FileName);
                        dgrPropertySearch.Tag = fileSearch;
                        break;
                    case PropertySearchType.INISearch:
                        INISearch iniSearch = (INISearch)selectedProperty.propSearch[PropertySearchType.INISearch];
                        dgrPropertySearch.Rows.Add(iniSearch.NameText, iniSearch.Name);
                        dgrPropertySearch.Rows.Add(iniSearch.SectionText, iniSearch.Section);
                        dgrPropertySearch.Rows.Add(iniSearch.KeyText, iniSearch.Key);
                        dgrPropertySearch.Tag = iniSearch;
                        break;
                    case PropertySearchType.None: dgrPropertySearch.Tag = null; break;
                    case PropertySearchType.RegistrySearch:
                        RegistrySearch regSearch = (RegistrySearch)selectedProperty.propSearch[PropertySearchType.RegistrySearch];
                        dgrPropertySearch.Rows.Add(regSearch.RootText, regSearch.Root);
                        dgrPropertySearch.Rows.Add(regSearch.KeyText, regSearch.Key);
                        dgrPropertySearch.Rows.Add(regSearch.NameText, regSearch.Name);
                        dgrPropertySearch.Tag = regSearch;
                        break;
                }
            }
        }

        private void dgrPropertySearch_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 1 && e.RowIndex > -1) {
                dgrPropertySearch.BeginEdit(true);
                Type type = dgrPropertySearch[e.ColumnIndex, e.RowIndex].GetType();
                if (type == typeof(DataGridViewComboBoxCell)) {
                    DataGridViewComboBoxEditingControl comboboxEdit = (DataGridViewComboBoxEditingControl)dgrPropertySearch.EditingControl;
                    comboboxEdit.DroppedDown = true;
                }
            }
        }

        private void txtPropertyName_TextChanged(object sender, EventArgs e) {
            propertyItems.UpdateSelectedItemText(txtPropertyName.Text);
        }
    }
}