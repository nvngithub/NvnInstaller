using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Wix = NvnInstaller.WixClasses;

namespace NvnInstaller {
    public partial class EnvironmentVariablesControl : UserControl {

        EnvironmentVariable selectedEnvVariable = null;

        public EnvironmentVariablesControl() {
            InitializeComponent();
            environmentVaribaleItems.GridHeader.HeaderText = "Environment Variables";

            environmentVaribaleItems.ItemDeleted += new EventHandler<GridItemEventArgs>(environmentVaribaleItems_ItemDeleted);
            environmentVaribaleItems.ItemSelectionChanged += new EventHandler<GridItemEventArgs>(environmentVaribaleItems_ItemSelectionChanged);

            LoadExistingEnvironmentVariables();
        }

        private void LoadExistingEnvironmentVariables() {
            foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables()) {
                dgrExistingEnvironmentVariables.Rows.Add(entry.Key, entry.Value);
            }
        }

        void environmentVaribaleItems_ItemSelectionChanged(object sender, GridItemEventArgs e) {
            dgrProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
            
            selectedEnvVariable = (EnvironmentVariable)e.SelectedItem;
            if (selectedEnvVariable != null) {
                DisplayProperties(selectedEnvVariable);
            }
        }

        void environmentVaribaleItems_ItemDeleted(object sender, GridItemEventArgs e) {
            dgrProperties.Rows.Clear();
        }

        private void AddNewEnvironmentVariabe_Click(object sender, EventArgs e) {
            EnvironmentVariable envVariable = new EnvironmentVariable();
            environmentVaribaleItems.AddNewItem(envVariable);
        }

        private void mnuDeletedSelectedItem_Click(object sender, EventArgs e) {
            environmentVaribaleItems.DeleteSelectedItem();
        }

        private void mnuClearAll_Click(object sender, EventArgs e) {
            environmentVaribaleItems.ClearItems();
        }

        private void SaveSelectedEnvironmentVariable_Click(object sender, EventArgs e) {
            dgrProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DisplayProperties(EnvironmentVariable envVaribale) {
            this.dgrProperties.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrProperties_CellValueChanged);
            dgrProperties.Rows.Clear();
            // Action
            int index = dgrProperties.Rows.Add();
            dgrProperties[0, index].Value = envVaribale.ActionPropertyText;
            dgrProperties[1, index] = new DataGridViewComboBoxCell();
            ((DataGridViewComboBoxCell)dgrProperties[1, index]).DataSource = Enum.GetNames(typeof(Wix.EnvironmentAction));
            dgrProperties[1, index].Value = envVaribale.Action.ToString();
            //Name
            index = dgrProperties.Rows.Add();
            dgrProperties[0, index].Value = envVaribale.NamePropertyText;
            dgrProperties[1, index].Value = envVaribale.Name;
            //Feature
            index = dgrProperties.Rows.Add();
            dgrProperties[1, index].ReadOnly = true;
            dgrProperties[0, index].Value = envVaribale.FeaturePropertyText;
            if (envVaribale.Feature != null) {
                dgrProperties[1, index].Value = envVaribale.Feature.Name;
            }
            //Permanent
            index = dgrProperties.Rows.Add();
            dgrProperties[0, index].Value = envVaribale.PermanentPropertyText;            
            dgrProperties[1, index] = new DataGridViewComboBoxCell();
            ((DataGridViewComboBoxCell)dgrProperties[1, index]).DataSource = new List<string>() { "True", "False" };
            dgrProperties[1, index].Value = envVaribale.Permanent.ToString();
            //System Variable
            index = dgrProperties.Rows.Add();
            dgrProperties[0, index].Value = envVaribale.SysEnvironmentVarPropertyText;                     
            dgrProperties[1, index] = new DataGridViewComboBoxCell();
            ((DataGridViewComboBoxCell)dgrProperties[1, index]).DataSource = new List<string>() { "True", "False" };
            dgrProperties[1, index].Value = envVaribale.SystemEnvironmentVariable.ToString();
            //Value
            index = dgrProperties.Rows.Add();
            dgrProperties[0, index].Value = envVaribale.ValuePropertyText;
            dgrProperties[1, index].Value = envVaribale.Value;
            
            this.dgrProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrProperties_CellValueChanged);
        }

        private void dgrProperties_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 1 && e.RowIndex == 2) {
                FeaturesForm featuresForm = new FeaturesForm();
                Point pointToScreen = PointToScreen(dgrProperties.Location);
                int x = pointToScreen.X + dgrProperties.Columns[0].Width;
                int y = pointToScreen.Y + dgrProperties.ColumnHeadersHeight + dgrProperties.Rows[e.RowIndex].Height * (e.RowIndex + 1);
                featuresForm.Location = new Point(x, y);
                if (featuresForm.ShowDialog() == DialogResult.OK) {
                    FeatureProperty feature = featuresForm.SelectedProperty;
                    if (feature != null && selectedEnvVariable != null) {
                        dgrProperties[e.ColumnIndex, e.RowIndex].Value = feature.Name;
                        selectedEnvVariable.Feature = feature;
                    }
                }
            } else if (e.ColumnIndex == 1 && e.RowIndex >= 0) {
                dgrProperties.BeginEdit(true);
                Type type = dgrProperties[e.ColumnIndex, e.RowIndex].GetType();
                if (type == typeof(DataGridViewComboBoxCell)) {
                    DataGridViewComboBoxEditingControl comboboxEdit = (DataGridViewComboBoxEditingControl)dgrProperties.EditingControl;
                    comboboxEdit.DroppedDown = true;
                }
            }
        }

        private void dgrProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            if (selectedEnvVariable != null) {
                string fieldType = (string)dgrProperties[0, e.RowIndex].Value;
                if (fieldType == selectedEnvVariable.ActionPropertyText) {
                    selectedEnvVariable.Action = (Wix.EnvironmentAction)Enum.Parse(typeof(Wix.EnvironmentAction), (string)dgrProperties[1, e.RowIndex].Value);
                } else if (fieldType == selectedEnvVariable.NamePropertyText) {
                    selectedEnvVariable.Name = (string)dgrProperties[1, e.RowIndex].Value;
                    environmentVaribaleItems.UpdateSelectedItemText(selectedEnvVariable.Name);
                } else if (fieldType == selectedEnvVariable.PermanentPropertyText) {
                    selectedEnvVariable.Permanent = Convert.ToBoolean(dgrProperties[1, e.RowIndex].Value);
                } else if (fieldType == selectedEnvVariable.SysEnvironmentVarPropertyText) {
                    selectedEnvVariable.SystemEnvironmentVariable = Convert.ToBoolean(dgrProperties[1, e.RowIndex].Value);
                } else if (fieldType == selectedEnvVariable.ValuePropertyText) {
                    selectedEnvVariable.Value = (string)dgrProperties[1, e.RowIndex].Value;
                }
            }
        }
    }
}
