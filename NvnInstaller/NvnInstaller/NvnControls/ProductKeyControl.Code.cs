#if Standard
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.Data;

namespace NvnInstaller {
    partial class ProductKeyControl : INvnControl {
        #region INvnControl Members

        void INvnControl.Open(Dictionary<string, object> objects) {
            List<string> productKey = (List<string>)objects["ProductKey"];
            if (productKey.Count == 5) {
                txtValidationDll.Text = productKey[0];
                txtDllEntry.Text = productKey[1];
                txtProperty.Text = productKey[2];
                txtTrueValue.Text = productKey[3];
                txtFalseValue.Text = productKey[4];
            }
        }

        void INvnControl.InitializeLoad() {
            txtValidationDll.Text = txtDllEntry.Text = txtProperty.Text = txtTrueValue.Text = txtFalseValue.Text = string.Empty;
        }

        void INvnControl.Saving() {
        }

        void INvnControl.Close() {
        }

        void INvnControl.Load() {

        }

        public ControlType Type {
            get {
                return ControlType.Components;
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            objects.Add("ProductKey", new List<string>() { txtValidationDll.Text, txtDllEntry.Text, txtProperty.Text, txtTrueValue.Text, txtFalseValue.Text });
        }

        List<Summary> INvnControl.GetSummary() {
            List<Summary> summaries = new List<Summary>();
            if (!String.IsNullOrEmpty(txtDllEntry.Text) && !String.IsNullOrEmpty(txtFalseValue.Text) && !String.IsNullOrEmpty(txtProperty.Text)
                && !String.IsNullOrEmpty(txtTrueValue.Text) && !String.IsNullOrEmpty(txtValidationDll.Text)) {
                Summary pidValidationSummary = new Summary();
                pidValidationSummary.Title = "Product Key Validation";
                DataTable data = new DataTable();
                data.Columns.Add("Property");
                data.Columns.Add("Value");
                // Set values
                data.Rows.Add("Validation DLL", txtValidationDll.Text);
                data.Rows.Add("DLL Entry", txtDllEntry.Text);
                data.Rows.Add("MSI Property", txtProperty.Text);
                data.Rows.Add("True Value", txtTrueValue.Text);
                data.Rows.Add("False Value", txtFalseValue.Text);

                pidValidationSummary.Data = data;
                summaries.Add(pidValidationSummary);
            }
            return summaries;
        }

        void INvnControl.Validate() {
            #region Validate Product Key

            if (txtDllEntry.Text.Trim() == "" && txtFalseValue.Text.Trim() == "" && txtProperty.Text.Trim() == ""
                && txtTrueValue.Text.Trim() == "" && txtValidationDll.Text.Trim() == "") {
                return;
            } else if (txtDllEntry.Text.Trim() != "" && txtFalseValue.Text.Trim() != "" && txtProperty.Text.Trim() != ""
                && txtTrueValue.Text.Trim() != "" && txtValidationDll.Text.Trim() != "") {
                return;
            } else {
                List<BuildLogMessage> logMessages = new List<BuildLogMessage>();
                BuildLogMessage logMessage = null;
                if (String.IsNullOrEmpty(txtValidationDll.Text)) {
                    logMessage = new BuildLogMessage();
                    logMessage.Message = "Sufficient information is not available for product key validation. Validation DLL path is empty.";
                    logMessage.Type = LogType.ERROR;
                    logMessage.Module = Modules.ProductKeyValidation;
                    logMessages.Add(logMessage);// add to the list
                }
                if (String.IsNullOrEmpty(txtProperty.Text)) {
                    logMessage = new BuildLogMessage();
                    logMessage.Message = "Sufficient information is not available for product key validation. Property name is missing.";
                    logMessage.Type = LogType.ERROR;
                    logMessage.Module = Modules.ProductKeyValidation;
                    logMessages.Add(logMessage);// add to the list
                }
                if (String.IsNullOrEmpty(txtDllEntry.Text)) {
                    logMessage = new BuildLogMessage();
                    logMessage.Message = "Sufficient information is not available for product key validation. DLL entry is missing.";
                    logMessage.Type = LogType.ERROR;
                    logMessage.Module = Modules.ProductKeyValidation;
                    logMessages.Add(logMessage);// add to the list
                }
                if (String.IsNullOrEmpty(txtTrueValue.Text) || String.IsNullOrEmpty(txtFalseValue.Text)) {
                    logMessage = new BuildLogMessage();
                    logMessage.Message = "Sufficient information is not available for product key validation. Either TRUE value or FALSE value is missing.";
                    logMessage.Type = LogType.ERROR;
                    logMessage.Module = Modules.ProductKeyValidation;
                    logMessages.Add(logMessage);// add to the list
                }
            }
            #endregion
        }

        void INvnControl.InitializeBuild() {
        }

        void INvnControl.Build() {
            if (String.IsNullOrEmpty(txtDllEntry.Text) || String.IsNullOrEmpty(txtFalseValue.Text) || String.IsNullOrEmpty(txtProperty.Text)
                || String.IsNullOrEmpty(txtTrueValue.Text) || String.IsNullOrEmpty(txtValidationDll.Text)) {
                return;
            } else {
                // create custom actions
                Wix.Binary pidBinaryFile = new Wix.Binary();
                pidBinaryFile.Id = "ProductKeyCode";
                pidBinaryFile.SourceFile = txtValidationDll.Text;
                MsiBuilder.CustomActionItems = Common.AddItemToArray(MsiBuilder.CustomActionItems, pidBinaryFile);
                Wix.CustomAction pidCustomAction = new Wix.CustomAction();
                pidCustomAction.Id = "MSIKey";// this must be same as in RegistrationDlg
                pidCustomAction.BinaryKey = "ProductKeyCode";
                pidCustomAction.DllEntry = txtDllEntry.Text;
                MsiBuilder.CustomActionItems = Common.AddItemToArray(MsiBuilder.CustomActionItems, pidCustomAction);
                // update user interface
                UICompiler.UpdatePIDInfo(txtProperty.Text, txtTrueValue.Text, txtFalseValue.Text);

                // compile user interface files
                UICompiler.Compile(true, MsiBuilder.UIRef[0].Id.Split("_".ToCharArray())[1]);
            }
        }

        #endregion
    }
}
#endif