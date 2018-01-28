using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace NvnInstaller {
    public partial class CustomUIApplication:INvnControl {
        #region INvnControl Members

        void INvnControl.Open(Dictionary<string, object> objects) {
            if (objects.ContainsKey(txtUiAppPath.Name)) txtUiAppPath.Text = (string)objects[txtUiAppPath.Name];
            if (objects.ContainsKey(lstFiles.Name)) {
                items.Clear();
                items.AddRange((List<NameValue>)objects[lstFiles.Name]);
                cmItems.Refresh();
            }
            if (objects.ContainsKey(lstSelectedFiles.Name)) {
                selectedItems.Clear();
                selectedItems.AddRange((List<NameValue>)objects[lstSelectedFiles.Name]);
                cmSelectedItems.Refresh();
            }
        }

        void INvnControl.Saving() {
        }

        void INvnControl.Close() {
        }

        void INvnControl.InitializeLoad() {
            txtUiAppPath.Text = string.Empty;
            items.Clear();
            selectedItems.Clear();

            cmItems.Refresh();
            cmSelectedItems.Refresh();
        }

        void INvnControl.Load() {
        }

        ControlType INvnControl.Type {
            get { return ControlType.CustomUIApplication; }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            objects.Add(txtUiAppPath.Name, txtUiAppPath.Text);
            objects.Add(lstFiles.Name, items);
            objects.Add(lstSelectedFiles.Name, selectedItems);
        }

        List<Summary> INvnControl.GetSummary() {
            return null;
        }

        void INvnControl.Validate() {
            if (String.IsNullOrEmpty(txtUiAppPath.Text) == false && lstSelectedFiles.Items.Count != 0) {
                // Check whether files selected
                if (lstSelectedFiles.Items.Count == 0) {
                    BuildLogMessage message = new BuildLogMessage();
                    message.Message = "Custom UI application and its supporting files are not selected.";
                    message.Type = LogType.ERROR;
                    message.Module = Modules.CustomUIApplication;
                    BuildLogger.Add(message);// add to the list
                }
                // Check whether application with <MsiFileName>.exe exists
                bool appExists = false, msiDllExits = false;
                string outputFilename = Path.GetFileNameWithoutExtension(ControlsManager.ProductInformation.Output.Text) + ".exe";
                foreach (NameValue nameValue in selectedItems) {
                    if (nameValue.Name == outputFilename) {
                        appExists = true;
                    } else if (nameValue.Name == "NvnInstaller.MsiDotNet.dll") {
                        msiDllExits = true;
                    }
                }
                if (appExists == false) {
                    BuildLogMessage message = new BuildLogMessage();
                    message.Message = "No application with name " + outputFilename + " found. Custom UI appliction with name " + outputFilename + " is expected.";
                    message.Type = LogType.ERROR;
                    message.Module = Modules.CustomUIApplication;
                    BuildLogger.Add(message);// add to the list
                }

                if (msiDllExits == false) {
                    BuildLogMessage message = new BuildLogMessage();
                    message.Message = "NvnInstaller.MsiDotNet.dll is not found. It is needed for all custom UI application developed using NvnInstaller.";
                    message.Type = LogType.ERROR;
                    message.Module = Modules.CustomUIApplication;
                    BuildLogger.Add(message);// add to the list
                }
                // check bootstrapper is downloaded
                if (cmbPrerequisites.Items.Count < 2) {
                    BuildLogMessage message = new BuildLogMessage();
                    message.Message = "Nvn Installer needs at least .Net Framework 2.0 bootstrapper installed to build custom UI application. Please visit Nvn Installer website.";
                    message.Type = LogType.ERROR;
                    message.Module = Modules.CustomUIApplication;
                    BuildLogger.Add(message);// add to the list
                }

                // check bootstrapper is selected
                if (cmbPrerequisites.SelectedIndex < 1) {
                    BuildLogMessage message = new BuildLogMessage();
                    message.Message = "No prerequisite selected. Select relevent .Net Framework used for custom UI application.";
                    message.Type = LogType.ERROR;
                    message.Module = Modules.CustomUIApplication;
                    BuildLogger.Add(message);// add to the list
                }
            }
        }

        void INvnControl.InitializeBuild() {
        }

        void INvnControl.Build() {
        }

        #endregion
    }
}
