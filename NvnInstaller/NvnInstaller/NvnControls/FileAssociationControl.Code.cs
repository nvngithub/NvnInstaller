using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.IO;
using System.Data;

namespace NvnInstaller {
    partial class FileAssociationControl : INvnControl {
        #region INvnControl Members

        void INvnControl.Open(Dictionary<string, object> objects) {
            List<Extension> extensions = (List<Extension>)objects["Extensions"];
            foreach (Extension extension in extensions) {
                int index = dgrExtensions.Rows.Add();
                dgrExtensions[IdColumn.Name, index].Value = extension.Id;
                dgrExtensions[indexColumn.Name, index].Value = index + 1;
                dgrExtensions[extensionColumn.Name, index].Value = extension.extension;
                dgrExtensions[DescriptionColumn.Name, index].Value = extension.description;
                dgrExtensions[applicationColumn.Name, index].Value = extension.application;
                dgrExtensions[applicationColumn.Name, index].ReadOnly = true;
                dgrExtensions[deleteColumn.Name, index].Value = "Delete";
                dgrExtensions[BrowseColumn.Name, index].Value = "...";
                dgrExtensions.Rows[index].Tag = extension.exeInfo;
            }
        }

        void INvnControl.InitializeLoad() {
            dgrExtensions.Rows.Clear();
        }

        void INvnControl.Saving() {
            dgrExtensions.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        void INvnControl.Close() { }

        void INvnControl.Load() { }

        public ControlType Type {
            get {
                return ControlType.Components;
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            //delete all empty rows
            foreach (DataGridViewRow row in dgrExtensions.Rows) {
                string application = (string)row.Cells[applicationColumn.Name].Value;
                string description = (string)row.Cells[DescriptionColumn.Name].Value;
                string extension = (string)row.Cells[extensionColumn.Name].Value;
                if (String.IsNullOrEmpty(application) && String.IsNullOrEmpty(description) && String.IsNullOrEmpty(extension)) {
                    dgrExtensions.Rows.Remove(row);
                }
            }
            // save only non-empty rows
            List<Extension> extensions = new List<Extension>();
            foreach (DataGridViewRow row in dgrExtensions.Rows) {
                Extension extension = new Extension();
                extension.Id = (string)row.Cells[IdColumn.Name].Value;
                extension.application = (string)row.Cells[applicationColumn.Name].Value;
                extension.description = (string)row.Cells[DescriptionColumn.Name].Value;
                extension.extension = (string)row.Cells[extensionColumn.Name].Value;
                extension.exeInfo = row.Tag;
                extensions.Add(extension);
            }
            objects.Add("Extensions", extensions);
        }

        List<Summary> INvnControl.GetSummary() {
            dgrExtensions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            List<Summary> summaries = new List<Summary>();
            if (dgrExtensions.Rows.Count > 0) {
                Summary fileAssociationSummary = new Summary();
                fileAssociationSummary.Title = "File Association";
                DataTable data = new DataTable();
                data.Columns.Add("Extension");
                data.Columns.Add("Description");
                data.Columns.Add("Application");
                // Set values
                foreach (DataGridViewRow row in dgrExtensions.Rows) {
                    data.Rows.Add(row.Cells[indexColumn.Name].Value, row.Cells[DescriptionColumn.Name].Value, row.Cells[applicationColumn.Name].Value);
                }
                fileAssociationSummary.Data = data;
                summaries.Add(fileAssociationSummary);
            }
            return summaries;
        }

        void INvnControl.Validate() {
            List<string> extensions = new List<string>();
            List<string> selectedApplications = new List<string>();
            foreach (DataGridViewRow row in dgrExtensions.Rows) {
                string application = (string)row.Cells[applicationColumn.Name].Value;
                string description = (string)row.Cells[DescriptionColumn.Name].Value;
                string extension = (string)row.Cells[extensionColumn.Name].Value;
                // check for mandatory fields
                List<BuildLogMessage> logMessages = Validator.IsNullOrEmpty(
                    new string[] { application, extension }, new string[] { "Application Name", "File association extension" }, LogType.ERROR, Modules.FileAssociation);
                if (logMessages != null) BuildLogger.Add(logMessages);
                // application name doesn't end with '.exe'
                if (application != null && application.EndsWith(".exe") == false) {
                    BuildLogMessage buildMessage = new BuildLogMessage();
                    buildMessage.Message = "Application selected for the file association:" + extension + " does not end with .exe. Are you sure it is an executable ?";
                    buildMessage.Type = LogType.Warning;
                    buildMessage.Module = Modules.FileAssociation;
                    BuildLogger.Add(buildMessage);// add to the list
                }
                //error if application selected for file association not in components tree
                if (row.Tag != null && ((TreeNode)row.Tag).TreeView == null) {
                    BuildLogMessage buildMessage = new BuildLogMessage();
                    buildMessage.Message = "Application selected for the file association:" + extension + " not found in components tree. Please check whether the application with name: " + application + " exists.";
                    buildMessage.Type = LogType.ERROR;
                    buildMessage.Module = Modules.FileAssociation;
                    BuildLogger.Add(buildMessage);// add to the list
                }
            }
            //check repeating names
            List<BuildLogMessage> messages = Validator.ValidateRepeatingItems(extensions, "Extension {0} found more than once. Are you sure you want to handle same extension by different applications.", LogType.Warning, Modules.FileAssociation);
            if (messages != null) BuildLogger.Add(messages);
        }

        void INvnControl.InitializeBuild() {
            dgrExtensions.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        void INvnControl.Build() {
            // build file associations
            foreach (DataGridViewRow row in dgrExtensions.Rows) {
                CreateProgIdComponent(row);
            }
        }

        private void CreateProgIdComponent(DataGridViewRow rowData) {
            ComponentNode exeData = (ComponentNode)((TreeNode)rowData.Tag).Tag;
            Wix.Component exeComponent = (Wix.Component)exeData.Property.WixNode;
            Wix.File exeFile = (Wix.File)exeComponent.Items[0];
            string extenstion = (string)rowData.Cells[extensionColumn.Name].Value;
            if (extenstion.StartsWith(".")) extenstion = extenstion.Remove(0, 1);
            string regKey = Path.GetFileNameWithoutExtension(exeFile.Source) + "." + extenstion;

            //keyReg
            Wix.Registry reg1 = new Wix.Registry();
            reg1.Id = regKey;
            reg1.Root = Wix.RegistryRoot.HKCR; reg1.RootSpecified = true;
            reg1.Action = Wix.RegistryAction.write; reg1.ActionSpecified = true;
            reg1.Type = Wix.RegistryType.@string; reg1.TypeSpecified = true;
            reg1.Key = regKey;
            reg1.Value = (string)rowData.Cells[DescriptionColumn.Name].Value;
            //reg1.KeyPath = Wix.YesNoType.yes; reg1.KeyPathSpecified = true;

            // command or application to run
            Wix.Registry reg2 = new Wix.Registry();
            reg2.Id = regKey + ".command";
            reg2.Root = Wix.RegistryRoot.HKCR; reg2.RootSpecified = true;
            reg2.Action = Wix.RegistryAction.write; reg2.ActionSpecified = true;
            reg2.Type = Wix.RegistryType.@string; reg2.TypeSpecified = true;
            reg2.Key = regKey + @"\shell\open\command";
            reg2.Value = "\"[#" + exeFile.Id + "]\" \"%1\"";
            //default icon
            Wix.Registry reg3 = new Wix.Registry();
            reg3.Id = regKey + ".icon";
            reg3.Root = Wix.RegistryRoot.HKCR; reg3.RootSpecified = true;
            reg3.Action = Wix.RegistryAction.write; reg3.ActionSpecified = true;
            reg3.Type = Wix.RegistryType.@string; reg3.TypeSpecified = true;
            reg3.Key = regKey + @"\DefaultIcon";
            reg3.Value = "\"[#" + exeFile.Id + "]\"";
            //.<extension> key
            Wix.Registry reg4 = new Wix.Registry();
            reg4.Id = regKey + ".association";
            reg4.Root = Wix.RegistryRoot.HKCR; reg4.RootSpecified = true;
            reg4.Action = Wix.RegistryAction.write; reg4.ActionSpecified = true;
            reg4.Type = Wix.RegistryType.@string; reg4.TypeSpecified = true;
            reg4.Key = "." + extenstion;
            reg4.Value = regKey;

            object[] items = new object[4] { reg1, reg2, reg3, reg4 };

            exeComponent.Items = Common.AddItemToArray(exeComponent.Items, items);
        }

        #endregion
    }
}
