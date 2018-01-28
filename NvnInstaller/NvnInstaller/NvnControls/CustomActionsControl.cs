using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Reflection;
using Fireball.CodeEditor.SyntaxFiles;
using System.IO;

namespace NvnInstaller {
    public partial class CustomActionsControl : UserControl {
        CustomActionBase selectedCustomAction;
        public CustomActionsControl() {
            InitializeComponent();
            cmbCustomActionType.DataSource = Enum.GetNames(typeof(CustomActionType));
            codeEditorControl.Document.Change += new EventHandler(Document_Change);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            CustomActionBase customAction = null;
            switch ((CustomActionType)Enum.Parse(typeof(CustomActionType), cmbCustomActionType.Text)) {
                case CustomActionType.Dll:
                    customAction = new CustomAction_Dll();
                    break;
                case CustomActionType.Exe:
                    customAction = new CustomAction_Exe();
                    break;
                case CustomActionType.ExeCommand:
                    customAction = new CustomAction_ExeCommand();
                    break;
                case CustomActionType.JScript:
                    customAction = new CustomAction_JScript();
                    break;
                case CustomActionType.VBScript:
                    customAction = new CustomAction_VBScript();
                    break;
            }
            customAction.Id = Common.GetId();
            int index = dgActions.Rows.Add();
            dgActions[0, index].Value = cmbCustomActionType.Text + " Custom Action";
            dgActions.Rows[index].Tag = customAction;
            // select the new row
            foreach (DataGridViewRow selectedRow in dgActions.SelectedRows) {
                selectedRow.Selected = false;
            }
            dgActions.Rows[index].Selected = true;
        }

        private void dgActions_SelectionChanged(object sender, EventArgs e) {
            foreach (DataGridViewRow selectedRow in dgActions.SelectedRows) {
                selectedCustomAction = null;
                CustomActionBase customAction = (CustomActionBase)selectedRow.Tag;
                if (customAction != null) {
                    ShowProperties(customAction);
                    if (customAction.Scriptable) {
                        codeEditorControl.Document.Text = customAction.Script;
                        codeEditorControl.Enabled = true;
                    } else {
                        codeEditorControl.Document.Text = string.Empty;
                        codeEditorControl.Enabled = false;
                    }
                }
                selectedCustomAction = customAction;
            }
        }

        void Document_Change(object sender, EventArgs e) {
            if (selectedCustomAction != null) {
                selectedCustomAction.Script = codeEditorControl.Document.Text;
                UpdateCustiomActionNames();
            }
        }

        private void ShowProperties(CustomActionBase customAction) {
            dgProperties.Rows.Clear();
            // name
            dgProperties.Rows.Add("Name", customAction.Name);
            // install file type
            if (customAction.Browsable) {
                DataGridViewComboBoxCell installedFileCell = new DataGridViewComboBoxCell();
                installedFileCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                installedFileCell.DataSource = new List<string> { "True", "False" };
                installedFileCell.Value = customAction.IsInstalledFile;
                int i = dgProperties.Rows.Add(customAction.InstalledFileQueryLabel);
                dgProperties[1, i] = installedFileCell;
            }
            // source path
            int index = dgProperties.Rows.Add(customAction.SourcePathLabel, customAction.SourcePath);
            if (customAction.Browsable) {
                DataGridViewButtonCell browseBtn = new DataGridViewButtonCell();
                browseBtn.Value = "...";
                dgProperties[2, index] = browseBtn;
            }
            // Function to call Or Arguments
            dgProperties.Rows.Add(customAction.FunctionLabel, customAction.Function);
            // Custom action install schedule
            DataGridViewComboBoxCell installSequenceCell = new DataGridViewComboBoxCell();
            installSequenceCell.DataSource = Enum.GetNames(typeof(CustomActionExecuteType));
            installSequenceCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            installSequenceCell.Value = customAction.ExecuteType.ToString();
            index = dgProperties.Rows.Add(customAction.ExecuteTypeLabel);
            dgProperties[1, index] = installSequenceCell;

            // change Code editor syntax
            if (customAction.Scriptable) {
                switch (customAction.Type) {
                    case CustomActionType.JScript:
                        CodeEditorSyntaxLoader.SetSyntax(codeEditorControl, SyntaxLanguage.JavaScript); break;
                    case CustomActionType.VBScript:
                        CodeEditorSyntaxLoader.SetSyntax(codeEditorControl, SyntaxLanguage.VBScript); break;
                }
                codeEditorControl.Refresh();
            }

            // Enable or Disable Save script button
            btnSave.Visible = customAction.Scriptable && String.IsNullOrEmpty(customAction.SourcePath) == false;
        }

        private void dgProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (selectedCustomAction != null) {
                foreach (DataGridViewRow propertyRow in dgProperties.Rows) {
                    string propertyName = (string)propertyRow.Cells[0].Value;
                    string value = (string)dgProperties[1, propertyRow.Index].Value;
                    if (propertyName == "Name") {
                        selectedCustomAction.Name = value;
                        // change custom action name in Actions grid
                        UpdateCustiomActionNames();
                    } else if (propertyName == selectedCustomAction.SourcePathLabel) {
                        selectedCustomAction.SourcePath = value;
                    } else if (propertyName == selectedCustomAction.FunctionLabel) {
                        selectedCustomAction.Function = value;
                    } else if (propertyName == selectedCustomAction.ExecuteTypeLabel) {
                        selectedCustomAction.ExecuteType = (CustomActionExecuteType)Enum.Parse(typeof(CustomActionExecuteType), value);
                    } else if (propertyName == selectedCustomAction.InstalledFileQueryLabel) {
                        selectedCustomAction.IsInstalledFile = value;
                    }
                }
            }
        }

        private void UpdateCustiomActionNames() {
            foreach (DataGridViewRow row in dgActions.Rows) {
                CustomActionBase customAction = (CustomActionBase)row.Tag;
                if (customAction.Scriptable && customAction.OriginalScript != string.Empty && customAction.OriginalScript.Equals(customAction.Script) == false) {
                    row.Cells[0].Value = customAction.Name + "*";
                } else {
                    row.Cells[0].Value = customAction.Name;
                }
            }
        }

        private void dgProperties_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (selectedCustomAction != null) {
                // show relevent form to select a file
                if (e.ColumnIndex == 2 && e.RowIndex == 2 && selectedCustomAction.Browsable) {
                    // ask user whether to overrite text in script editor
                    if (selectedCustomAction.Scriptable && selectedCustomAction.Script != string.Empty && MessageBox.Show("Script editor is not empty. This action will overrite content in the script editor. Do you want to continue ?", "Editor not empty", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No) {
                        return;
                    }

                    string filePath = string.Empty;
                    if (selectedCustomAction.IsInstalledFile == "True") {
                        // show dialog to select files and folders in Components tree
                        ComponentsForm componentsForm = new ComponentsForm(true);
                        Point pointToScreen = PointToScreen(dgProperties.Location);
                        int x = pointToScreen.X + dgProperties.Columns[0].Width + dgProperties.Columns[1].Width - componentsForm.Width;
                        int y = pointToScreen.Y + dgProperties.ColumnHeadersHeight + dgProperties.Rows[e.RowIndex].Height * e.RowIndex;
                        componentsForm.Location = new Point(x, y);
                        if (componentsForm.ShowDialog() == DialogResult.OK) {
                            if (componentsForm.SelectedComponentNode != null) {
                                TreeNode componentNode = componentsForm.SelectedComponentNode;
                                filePath = ((ComponentNode)componentNode.Tag).Property.SourcePath;
                                selectedCustomAction.Tag = componentNode.Tag;
                            }
                        }
                    } else {
                        // show OpenFileDialog
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Multiselect = false;
                        dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        if (dlg.ShowDialog() == DialogResult.OK) {
                            filePath = dlg.FileName;
                        }
                    }
                    if (filePath != string.Empty) {
                        // update Custom Action item
                        foreach (DataGridViewRow row in dgProperties.Rows) {
                            if ((string)row.Cells[0].Value == selectedCustomAction.SourcePathLabel) {
                                row.Cells[1].Value = selectedCustomAction.SourcePath = filePath;
                                if (selectedCustomAction.Scriptable) {
                                    ReadScriptFile(filePath);
                                    btnSave.Visible = true;
                                }
                                break;
                            }
                        }
                    }
                }// show drop down if selected cell is of type ComboBox
                else if (e.ColumnIndex == 1 && e.RowIndex >= 0) {
                    dgProperties.BeginEdit(true);
                    Type type = dgProperties[e.ColumnIndex, e.RowIndex].GetType();
                    if (type == typeof(DataGridViewComboBoxCell)) {
                        DataGridViewComboBoxEditingControl comboboxEdit = (DataGridViewComboBoxEditingControl)dgProperties.EditingControl;
                        comboboxEdit.DroppedDown = true;
                    }
                }
            }
        }

        private void ReadScriptFile(string filePath) {
            if (String.IsNullOrEmpty(filePath) == false) {
                using (StreamReader scriptReader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))) {
                    codeEditorControl.Document.Text = selectedCustomAction.Script = selectedCustomAction.OriginalScript = scriptReader.ReadToEnd();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (selectedCustomAction != null) {
                if (selectedCustomAction.Scriptable && String.IsNullOrEmpty(selectedCustomAction.SourcePath) == false) {
                    using (StreamWriter writer = new StreamWriter(new FileStream(selectedCustomAction.SourcePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))) {
                        writer.Write(codeEditorControl.Document.Text);
                        selectedCustomAction.OriginalScript = selectedCustomAction.Script;
                        UpdateCustiomActionNames();
                    }
                }
            }
        }

        private void dgActions_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            if (dgActions.Rows.Count == 0) {
                dgProperties.Rows.Clear();
                codeEditorControl.Document.Text = string.Empty;
                btnSave.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgActions.SelectedRows) {
                dgActions.Rows.Remove(row);
                dgActions_UserDeletedRow(null, null);
            }
        }

        private void btnUp_Click(object sender, EventArgs e) {
            if (dgActions.SelectedRows.Count > 0) {
                DataGridViewRow actionRow = dgActions.SelectedRows[0];
                int index = actionRow.Index;
                if (index > 0) {
                    dgActions.Rows.Remove(actionRow);
                    dgActions.Rows.Insert(index - 1, actionRow);
                    actionRow.Selected = true;
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e) {
            if (dgActions.SelectedRows.Count > 0) {
                DataGridViewRow actionRow = dgActions.SelectedRows[0];
                int index = actionRow.Index;
                if (index < dgActions.Rows.Count - 1) {
                    dgActions.Rows.Remove(actionRow);
                    dgActions.Rows.Insert(index + 1, actionRow);
                    actionRow.Selected = true;
                }
            }
        }
    }
}