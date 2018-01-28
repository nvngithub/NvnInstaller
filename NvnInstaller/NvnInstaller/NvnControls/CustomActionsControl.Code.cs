using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.Data;

namespace NvnInstaller {
    partial class CustomActionsControl : INvnControl {
        void INvnControl.Open(Dictionary<string, object> objects) {
            Dictionary<string, CustomActionBase> customActions = (Dictionary<string, CustomActionBase>)objects["CustomActions"];
            // create items in datagrid
            foreach (string id in customActions.Keys) {
                CustomActionBase customAction = customActions[id];
                int index = dgActions.Rows.Add();
                dgActions[0, index].Value = customAction.Name;
                dgActions.Rows[index].Tag = customAction;
            }
            if (dgActions.Rows.Count > 0) {
                dgActions.Rows[0].Selected = true;
            }
        }

        void INvnControl.InitializeLoad() {
            dgActions.Rows.Clear();
            dgProperties.Rows.Clear();
            codeEditorControl.Document.Text = string.Empty;
        }

        void INvnControl.Saving() {
            dgProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        void INvnControl.Close() { }

        void INvnControl.Load() { }

        public ControlType Type {
            get {
                return ControlType.CustomActions;
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            Dictionary<string, CustomActionBase> customActions = new Dictionary<string, CustomActionBase>();
            foreach (DataGridViewRow actionRow in dgActions.Rows) {
                CustomActionBase customAction = (CustomActionBase)actionRow.Tag;
                customActions.Add(customAction.Id, customAction);
            }
            objects.Add("CustomActions", customActions);
        }

        void INvnControl.Validate() {
            foreach (DataGridViewRow row in dgActions.Rows) {
                CustomActionBase customAction = (CustomActionBase)row.Tag;
                customAction.Validate();
            }
        }

        List<Summary> INvnControl.GetSummary() {
            List<Summary> summaries = new List<Summary>();
            foreach (DataGridViewRow row in dgActions.Rows) {
                CustomActionBase customAction = (CustomActionBase)row.Tag;
                Summary summary = new Summary();
                summary.Title = customAction.Name;
                DataTable summaryData = new DataTable();
                summaryData.Columns.Add("PropertyName");
                summaryData.Columns.Add("Value");
                // get al property values into data table
                summaryData.Rows.Add("Type", customAction.Type.ToString());
                summaryData.Rows.Add(customAction.InstalledFileQueryLabel, customAction.IsInstalledFile);
                summaryData.Rows.Add(customAction.SourcePathLabel, customAction.SourcePath);
                summaryData.Rows.Add(customAction.FunctionLabel, customAction.Function);
                summaryData.Rows.Add(customAction.ExecuteTypeLabel, customAction.ExecuteType.ToString());

                summary.Data = summaryData;
                summaries.Add(summary);
            }

            return summaries;
        }

        void INvnControl.InitializeBuild() {
            dgProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        void INvnControl.Build() {
            foreach (DataGridViewRow row in dgActions.Rows) {
                CustomActionBase customAction = (CustomActionBase)row.Tag;
                object[] items = customAction.Build();
                MsiBuilder.CustomActionItems = Common.AddItemToArray(MsiBuilder.CustomActionItems, items);
            }
        }
    }

    #region Custom Action Classes

    /*Useful links
     * http://strangelights.com/blog/archive/2004/07/07/160.aspx
     * http://msdn.microsoft.com/en-us/library/aa368012(VS.85).aspx
     * http://msdn.microsoft.com/en-us/library/aa368561(VS.85).aspx
     * http://msdn.microsoft.com/en-us/library/aa370858(VS.85).aspx = Product state
     * http://msdn.microsoft.com/en-us/library/aa369297(VS.85).aspx
     */
    [Serializable]
    public abstract class CustomActionBase {
        string name;
        string id;
        CustomActionType type;
        CustomActionExecuteType executeType = CustomActionExecuteType.Installation;
        string executeTypeLabel = "When ?";

        string isInstalledFile = "True";
        string installedFileQueryLabel = "Is part of Installation";

        bool browsable = true;
        string sourcePath = "";
        string sourcePathLabel = "File Path";
        string sourcePathHelp = "";

        string function = "";
        string functionLabel = "";
        string functionCallHelp = "";// TODO : use this for tooltip in datagridview

        string script = "";
        string originalScript = "";
        bool scriptable = false;
        List<string> samples;// Just folder names
        object tag;

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Id { get { return this.id; } set { this.id = value; } }
        public CustomActionType Type { get { return this.type; } set { this.type = value; } }
        public string ExecuteTypeLabel { get { return this.executeTypeLabel; } set { this.executeTypeLabel = value; } }
        public CustomActionExecuteType ExecuteType { get { return this.executeType; } set { this.executeType = value; } }
        public string IsInstalledFile { get { return this.isInstalledFile; } set { this.isInstalledFile = value; } }
        public string InstalledFileQueryLabel { get { return this.installedFileQueryLabel; } set { this.installedFileQueryLabel = value; } }
        public string SourcePath { get { return this.sourcePath; } set { this.sourcePath = value; } }
        public string SourcePathLabel { get { return this.sourcePathLabel; } set { this.sourcePathLabel = value; } }
        public string SourcePathHelp { get { return this.sourcePathHelp; } set { this.sourcePathHelp = value; } }
        public string Function { get { return this.function; } set { this.function = value; } }
        public string FunctionLabel { get { return this.functionLabel; } set { this.functionLabel = value; } }
        public string FunctionCallHelp { get { return this.functionCallHelp; } set { this.functionCallHelp = value; } }
        public string Script { get { return this.script; } set { this.script = value; } }
        public string OriginalScript { get { return this.originalScript; } set { this.originalScript = value; } }
        public bool Scriptable { get { return this.scriptable; } set { this.scriptable = value; } }
        public bool Browsable { get { return this.browsable; } set { this.browsable = value; } }
        public List<string> Samples { get { return this.samples; } set { this.samples = value; } }
        public object Tag { get { return this.tag; } set { this.tag = value; } }

        public abstract object[] Build();

        public void Validate() {
            BuildLogMessage buildMessage = new BuildLogMessage();
            if (type == CustomActionType.ExeCommand) {
                if (String.IsNullOrEmpty(sourcePath)) {
                    buildMessage = new BuildLogMessage();
                    buildMessage.Message = String.Format("No executable(exe) in target system is specified for the custom action: {0}.", name);
                    buildMessage.Type = LogType.ERROR;
                    buildMessage.Module = Modules.CustomActions;
                    BuildLogger.Add(buildMessage);
                }
                if (String.IsNullOrEmpty(function)) {
                    buildMessage = new BuildLogMessage();
                    buildMessage.Message = String.Format("No argument specified for the custom action: {0}.", name);
                    buildMessage.Type = LogType.Warning;
                    buildMessage.Module = Modules.CustomActions;
                    BuildLogger.Add(buildMessage);
                }
            } else {
                if (this.browsable) {
                    if (scriptable) {
                        if (String.IsNullOrEmpty(sourcePath) && String.IsNullOrEmpty(script)) {
                            buildMessage = new BuildLogMessage();
                            buildMessage.Message = String.Format("Neither {0} file specified nor any script found in the editor (Custom Action: {1}).", type.ToString(), name);
                            buildMessage.Type = LogType.ERROR;
                            buildMessage.Module = Modules.CustomActions;
                            BuildLogger.Add(buildMessage);
                        }
                    } else if (String.IsNullOrEmpty(sourcePath)) {
                        buildMessage = new BuildLogMessage();
                        buildMessage.Message = String.Format("File path of the custom action :{0} is empty.", name);
                        buildMessage.Type = LogType.ERROR;
                        buildMessage.Module = Modules.CustomActions;
                        BuildLogger.Add(buildMessage);
                    }
                }
                if (browsable && String.IsNullOrEmpty(function)) {
                    buildMessage = new BuildLogMessage();
                    buildMessage.Message = String.Format("{0} of custom action: {1} is empty.", functionLabel, name);
                    buildMessage.Type = LogType.ERROR;
                    buildMessage.Module = Modules.CustomActions;
                    BuildLogger.Add(buildMessage);
                }
            }
        }

        public void SetExecuteType(Wix.Custom custom) {
            switch (ExecuteType) {
                case CustomActionExecuteType.Installation: custom.Value = "2>ProductState"; break;
                case CustomActionExecuteType.Uninstallation: custom.Value = "ProductState>=2"; break;
            }
        }

        public void SetExecutionSequence(Wix.Custom custom) {
            if (this.ExecuteType == CustomActionExecuteType.Installation) {
                custom.After = "InstallFinalize";
            } else {
                custom.After = "InstallInitialize";
            }
        }
    }

    [Serializable]
    class CustomAction_Dll : CustomActionBase {
        public CustomAction_Dll() {
            Name = "Custom Action - DLL";
            Type = CustomActionType.Dll;
            Scriptable = false;
            FunctionLabel = "DLL Entry";
            FunctionCallHelp = "Name of a function in a custom action to execute";
            Samples = new List<string>() { "CustomActions-Dll" };
        }

        public override object[] Build() {
            List<object> items = new List<object>();
            // create custom acton
            Wix.CustomAction action = new Wix.CustomAction();
            action.Id = Common.GetId();
            if (IsInstalledFile == "True") {
                if (Tag != null) {
                    action.FileKey = ((ComponentNode)Tag).Property.Id;
                }
            } else {
                Wix.Binary binary = new Wix.Binary();
                binary.Id = Common.GetId();
                binary.SourceFile = SourcePath;
                action.BinaryKey = binary.Id;
                items.Add(binary);
            }
            action.DllEntry = Function;
            items.Add(action);
            // create install execute sequence
            Wix.InstallExecuteSequence executeSequence = new Wix.InstallExecuteSequence();
            executeSequence.ItemsElementName = new Wix.ItemsChoiceType2[] { Wix.ItemsChoiceType2.Custom };
            Wix.Custom custom = new Wix.Custom();
            custom.Action = action.Id;
            base.SetExecutionSequence(custom);
            base.SetExecuteType(custom);
            executeSequence.Items = new object[] { custom };
            items.Add(executeSequence);

            return items.ToArray();
        }
    }

    [Serializable]
    class CustomAction_Exe : CustomActionBase {
        public CustomAction_Exe() {
            Name = "Custom Action - EXE";
            Type = CustomActionType.Exe;
            Scriptable = false;
            FunctionLabel = "Command Line Aruments";
            FunctionCallHelp = "Command line parameters to supply to an externally run executable.";
            Samples = new List<string>() { "CustomAction-Exe" };
        }

        public override object[] Build() {
            List<object> items = new List<object>();
            // create custom acton
            Wix.CustomAction action = new Wix.CustomAction();
            action.Id = Common.GetId();
            if (IsInstalledFile == "True") {
                if (Tag != null) {
                    action.FileKey = ((ComponentNode)Tag).Property.Id;
                }
            } else {
                Wix.Binary binary = new Wix.Binary();
                binary.Id = Common.GetId();
                binary.SourceFile = SourcePath;
                action.BinaryKey = binary.Id;
                items.Add(binary);
            }
            action.ExeCommand = Function;
            items.Add(action);
            // create install execute sequence
            Wix.InstallExecuteSequence executeSequence = new Wix.InstallExecuteSequence();
            executeSequence.ItemsElementName = new Wix.ItemsChoiceType2[] { Wix.ItemsChoiceType2.Custom };
            Wix.Custom custom = new Wix.Custom();
            custom.Action = action.Id;
            base.SetExecutionSequence(custom);
            base.SetExecuteType(custom);
            executeSequence.Items = new object[] { custom };
            items.Add(executeSequence);

            return items.ToArray();
        }
    }

    [Serializable]
    class CustomAction_VBScript : CustomActionBase {
        public CustomAction_VBScript() {
            Name = "Custom Action - VBScript";
            Type = CustomActionType.VBScript;
            Scriptable = true;
            SourcePathLabel = "File Path(optional)";
            FunctionLabel = "VBScript Call";
            FunctionCallHelp = "Name of the VBScript Subroutine to execute in a script.";
            Samples = new List<string>() { "CustomAction-VBScript" };
        }

        public override object[] Build() {
            List<object> items = new List<object>();
            // create custom acton
            Wix.CustomAction action = new Wix.CustomAction();
            action.Id = Common.GetId();
            if (String.IsNullOrEmpty(SourcePath)) {
                Wix.Property property = new Wix.Property();
                property.Id = Common.GetId();
                property.Text = new string[] { "<![CDATA[" + Script + "]]>" };
                items.Add(property);
                action.Property = property.Id;
            } else {
                if (IsInstalledFile == "True") {
                    if (Tag != null) {
                        action.FileKey = ((ComponentNode)Tag).Property.Id;
                    }
                } else {
                    Wix.Binary binary = new Wix.Binary();
                    binary.Id = Common.GetId();
                    binary.SourceFile = SourcePath;
                    action.BinaryKey = binary.Id;
                    items.Add(binary);
                }
            }
            action.VBScriptCall = Function;
            items.Add(action);
            // create install execute sequence
            Wix.InstallExecuteSequence executeSequence = new Wix.InstallExecuteSequence();
            executeSequence.ItemsElementName = new Wix.ItemsChoiceType2[] { Wix.ItemsChoiceType2.Custom };
            Wix.Custom custom = new Wix.Custom();
            custom.Action = action.Id;
            base.SetExecutionSequence(custom);
            base.SetExecuteType(custom);
            executeSequence.Items = new object[] { custom };
            items.Add(executeSequence);

            return items.ToArray();
        }
    }

    [Serializable]
    class CustomAction_JScript : CustomActionBase {
        public CustomAction_JScript() {
            Name = "Custom Action - JScript";
            Type = CustomActionType.JScript;
            Scriptable = true;
            SourcePathLabel = "File Path(optional)";
            FunctionLabel = "JScriptCall";
            FunctionCallHelp = "Name of the JScript function to execute in a script.";
            Samples = new List<string>() { "CustomAction-JScript" };
        }

        public override object[] Build() {
            List<object> items = new List<object>();
            // create custom acton
            Wix.CustomAction action = new Wix.CustomAction();
            action.Id = Common.GetId();
            if (String.IsNullOrEmpty(SourcePath)) {
                Wix.Property property = new Wix.Property();
                property.Id = Common.GetId();
                property.Text = new string[] { "<![CDATA[" + Script + "]]>" };
                items.Add(property);
                action.Property = property.Id;
            } else {
                if (IsInstalledFile == "True") {
                    if (Tag != null) {
                        action.FileKey = ((ComponentNode)Tag).Property.Id;
                    }
                } else {
                    Wix.Binary binary = new Wix.Binary();
                    binary.Id = Common.GetId();
                    binary.SourceFile = SourcePath;
                    action.BinaryKey = binary.Id;
                    items.Add(binary);
                }
            }
            action.JScriptCall = Function;
            items.Add(action);
            // create install execute sequence
            Wix.InstallExecuteSequence executeSequence = new Wix.InstallExecuteSequence();
            executeSequence.ItemsElementName = new Wix.ItemsChoiceType2[] { Wix.ItemsChoiceType2.Custom };
            Wix.Custom custom = new Wix.Custom();
            custom.Action = action.Id;
            base.SetExecutionSequence(custom);
            base.SetExecuteType(custom);
            executeSequence.Items = new object[] { custom };
            items.Add(executeSequence);

            return items.ToArray();
        }
    }

    [Serializable]
    class CustomAction_ExeCommand : CustomActionBase {
        public CustomAction_ExeCommand() {
            Name = "Custom Action - System Executable";
            Type = CustomActionType.ExeCommand;
            Browsable = false;
            Scriptable = false;
            SourcePathLabel = "EXE on target system";
            FunctionLabel = "Command Line Aruments";
            FunctionCallHelp = "Command line parameters to supply to an externally run executable.";
            Samples = new List<string>() { "CustomAction-ExeCommand" };
        }

        public override object[] Build() {
            List<object> items = new List<object>();
            // create custom acton
            Wix.CustomAction action = new Wix.CustomAction();
            action.Id = Common.GetId();
            action.Directory = "INSTALLDIR";
            if (SourcePath.Contains(":")) {
                action.ExeCommand = SourcePath + " " + Function; // EXE IN TARGET SYSTEM
            } else {
                action.ExeCommand = "[SystemFolder]" + SourcePath + " " + Function; // EXE IN TARGET SYSTEM
            }
            items.Add(action);
            // create install execute sequence
            Wix.InstallExecuteSequence executeSequence = new Wix.InstallExecuteSequence();
            executeSequence.ItemsElementName = new Wix.ItemsChoiceType2[] { Wix.ItemsChoiceType2.Custom };
            Wix.Custom custom = new Wix.Custom();
            custom.Action = action.Id;
            base.SetExecutionSequence(custom);
            base.SetExecuteType(custom);
            executeSequence.Items = new object[] { custom };
            items.Add(executeSequence);

            return items.ToArray();
        }
    }
    #endregion
}
