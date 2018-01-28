using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Data;
using System.Collections;

namespace NvnInstaller {
    partial class RegistriesControl : INvnControl {

        #region ICommonControl Members

        void INvnControl.Open(Dictionary<string, object> objects) {
            Support.ArraylistToTreeview((ArrayList)objects[tvRegistries.Name], tvRegistries);
        }

        void INvnControl.InitializeLoad() {
            foreach (TreeNode rootNode in tvRegistries.Nodes) {
                rootNode.Nodes.Clear();
            }
        }

        void INvnControl.Saving() {
        }

        void INvnControl.Close() {
            if (profileLoaded) {
                Profile.Set(registriesCompleteSplitter.Name, registriesCompleteSplitter.SplitterDistance.ToString());
                Profile.Set(registriesPropertiesSplitter.Name, registriesPropertiesSplitter.SplitterDistance.ToString());
            }
        }

        void INvnControl.Load() {

        }

        public ControlType Type {
            get {
                return ControlType.Registries;
            }
        }

        List<Summary> INvnControl.GetSummary() {
            List<Summary> summaries = new List<Summary>();
            if (tvRegistries.Nodes.Count > 0) {
                Summary registriesSummary = new Summary();
                registriesSummary.Title = "Registries";
                DataTable registriesTable = new DataTable();
                registriesTable.Columns.Add("Registry Path");
                registriesTable.Columns.Add("Name");
                registriesTable.Columns.Add("Value Type");
                registriesTable.Columns.Add("Value");
                foreach (TreeNode rootNode in tvRegistries.Nodes) {
                    GetRegistriesSummary(rootNode, registriesTable);
                }
                registriesSummary.Data = registriesTable;
                summaries.Add(registriesSummary);
            }
            if (summaries.Count > 0) {
                return summaries;
            }
            return null;
        }

        private void GetRegistriesSummary(TreeNode rootNode, DataTable registriesTable) {
            foreach (TreeNode node in rootNode.Nodes) {
                string keyPath = node.FullPath;
                List<RegistryValue> values = (List<RegistryValue>)node.Tag;
                for (int i = 0; i < values.Count; i++) {
                    RegistryValue value = values[i];
                    string name = value.Name;
                    if (value is RegistrySingleValue) {
                        RegistrySingleValue registryStringValue = (RegistrySingleValue)value;
                        registriesTable.Rows.Add(keyPath, name, registryStringValue.Type.ToString(), registryStringValue.Value);
                        keyPath = string.Empty;
                    } else if (value is RegistryMultipleValue) {
                        RegistryMultipleValue registryMultipleStringValue = ((RegistryMultipleValue)value);
                        string typeName = registryMultipleStringValue.Type.ToString();
                        foreach (string val in registryMultipleStringValue.Value) {
                            registriesTable.Rows.Add(keyPath, name, typeName, val);
                            name = string.Empty;
                            keyPath = string.Empty;
                            typeName = string.Empty;
                        }
                    }
                }
                // loop again
                GetRegistriesSummary(node, registriesTable);
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            objects.Add(tvRegistries.Name, Support.TreeviewToArraylist(tvRegistries));
        }

        void INvnControl.InitializeBuild() {
        }

        #region Validation
        void INvnControl.Validate() {
            List<BuildLogMessage> logMessages = Validator.ValidateTree(tvRegistries, false, Modules.Registries);
            BuildLogger.Add(logMessages);
            // validate each registry values
            foreach (TreeNode rootNode in tvRegistries.Nodes) {
                foreach (TreeNode keyNode in rootNode.Nodes) {
                    ValidateRegistryValues(keyNode);
                }
            }
        }

        private void ValidateRegistryValues(TreeNode keyNode) {
            List<RegistryValue> values = (List<RegistryValue>)keyNode.Tag;
            BuildLogMessage buildMessage = new BuildLogMessage();
            if (values == null || values.Count == 0) {
                //warning - key exists but no value
                buildMessage = new BuildLogMessage();
                buildMessage.Message = "Registry key node found with no values under it. " + keyNode.FullPath;
                buildMessage.Type = LogType.Warning;
                buildMessage.Module = Modules.Registries;
                BuildLogger.Add(buildMessage);
            }
            if (values != null) {
                //error: repeating value names
                foreach (RegistryValue value in values) {
                    foreach (RegistryValue val in values) {
                        if (val.Id != value.Id && value.Name == val.Name) {
                            buildMessage = new BuildLogMessage();
                            buildMessage.Message = "Multiple registry values with same name found under " + keyNode.FullPath;
                            buildMessage.Type = LogType.ERROR;
                            buildMessage.Module = Modules.Registries;
                            BuildLogger.Add(buildMessage);
                        }
                    }
                }

                foreach (RegistryValue value in values) {
                    //feature assigned to each value it
                    if (value.Feature == null || String.IsNullOrEmpty(value.Feature.Name)) {
                        buildMessage = new BuildLogMessage();
                        buildMessage.Message = "No feature assigned to the registry value " + value.Name + " under " + keyNode.FullPath;
                        buildMessage.Type = LogType.Warning;
                        buildMessage.Module = Modules.Registries;
                        BuildLogger.Add(buildMessage);
                    }
                    //feature assigned but not available in feature tree (deleted somehow)
                    if (value.Feature != null && Common.FeatureExists(value.Feature.Id) == false) {
                        buildMessage = new BuildLogMessage();
                        buildMessage.Message = "Feature "+ value.Feature.Name+ " assigned  to the registry value: " + value.Name + " under " + keyNode.FullPath + " is not found in the feature tree.";
                        buildMessage.Type = LogType.ERROR;
                        buildMessage.Module = Modules.Registries;
                        BuildLogger.Add(buildMessage);
                    }

                    //warning - Registry value exists but no value assigned to it. default value used
                    if (value is RegistrySingleValue) {
                        string singleValue = ((RegistrySingleValue)value).Value;
                        if (String.IsNullOrEmpty(singleValue)) {
                            buildMessage = new BuildLogMessage();
                            buildMessage.Message = "No value assigned to the registry value: " + value.Name + " under " + keyNode.FullPath + ". Default value is assigned.";
                            buildMessage.Type = LogType.Warning;
                            buildMessage.Module = Modules.Registries;
                            BuildLogger.Add(buildMessage);
                        }
                        if (String.IsNullOrEmpty(singleValue) == false) {
                            List<BuildLogMessage> logMessages = RegistryValueLimit(singleValue, keyNode, value);
                            if (logMessages.Count > 0) BuildLogger.Add(logMessages);
                        }
                    } else if (value is RegistryMultipleValue) {
                        string[] multiValues = ((RegistryMultipleValue)value).Value;
                        if (multiValues.Length == 0) {
                            string singleValue = ((RegistrySingleValue)value).Value;
                            buildMessage = new BuildLogMessage();
                            buildMessage.Message = "No value assigned to the registry value: " + value.Name + " under " + keyNode.FullPath + ". Default value is assigned.";
                            buildMessage.Type = LogType.Warning;
                            buildMessage.Module = Modules.Registries;
                            BuildLogger.Add(buildMessage);
                        }
                        foreach (string singleValue in multiValues) {
                            List<BuildLogMessage> logMessages = RegistryValueLimit(singleValue, keyNode, value);
                            if (logMessages.Count > 0) BuildLogger.Add(logMessages);
                        }
                    }                    
                }
            }

            foreach (TreeNode childNode in keyNode.Nodes) {
                ValidateRegistryValues(childNode);
            }
        }

        //check for value limit - may be like string lentgh, max value of integer
        //check for valid value - like binary should not have a string value
        private List<BuildLogMessage> RegistryValueLimit(string value, TreeNode keyNode, RegistryValue regValue) {
            List<BuildLogMessage> logMessages = new List<BuildLogMessage>();
            if (value.Length > 1024 * 1024) {
                BuildLogMessage buildMessage = new BuildLogMessage();
                buildMessage.Message = "Value of registry :" + regValue.Name + " under " + keyNode.FullPath + " is not in valid limit. Value size should not be more than 1 MB.";
                buildMessage.Type = LogType.ERROR;
                buildMessage.Module = Modules.Registries;
                logMessages.Add(buildMessage);
            }
            if (regValue.Name.Length > 16383) {
                BuildLogMessage buildMessage = new BuildLogMessage();
                buildMessage.Message = "Name of a registry " + " under " + keyNode.FullPath + " is more than the valid limit. Name length should not be more than 16,383 characters.";
                buildMessage.Type = LogType.ERROR;
                buildMessage.Module = Modules.Registries;
                logMessages.Add(buildMessage);
            }
            return logMessages;
        }
        #endregion

        void INvnControl.Build() {
            // build registries
            MsiBuilder.RegistryComponents.Clear();
            foreach (TreeNode rootNode in tvRegistries.Nodes) {
                foreach (TreeNode node in rootNode.Nodes) {
                    SetRegistries(node, rootNode.Text);
                }
            }
        }

        private void SetRegistries(TreeNode keyNode, string root) {
            //CreateKeyNode(keyNode, root);

            // create all registry VALUES
            List<RegistryValue> values = (List<RegistryValue>)keyNode.Tag;
            if (values != null) {
                foreach (RegistryValue value in values) {
                    // create component node for each key
                    Wix.Component component = new Wix.Component();
                    component.Id = Common.GetId();
                    component.Guid = Guid.NewGuid().ToString();
                    component.Win64Specified = true;
                    component.Win64 = (value.Win64 ? Wix.YesNoType.yes : Wix.YesNoType.no);
                    // add this component to install directory
                    MsiBuilder.RegistryComponents.Add(component);

                    Wix.Registry registry = new Wix.Registry();
                    registry.ActionSpecified = true;
                    registry.Action = Wix.RegistryAction.write;
                    registry.Id = value.Id;
                    registry.Key = GetKey(keyNode);
                    registry.Name = value.Name;
                    //TODO: type looks inconsistant
                    registry.TypeSpecified = true;
                    registry.Type = value.Type;
                    if (value is RegistrySingleValue) {
                        registry.Value = ((RegistrySingleValue)value).Value;
                    } else if (value is RegistryMultipleValue) {
                        string[] regValues = ((RegistryMultipleValue)value).Value;
                        registry.Items = Common.AddItemToArray(registry.Items, regValues);
                    }
                    registry.RootSpecified = true;
                    switch (root) {
                        case HKCR:
                            registry.Root = Wix.RegistryRoot.HKCR; break;
                        case HKCU:
                            registry.Root = Wix.RegistryRoot.HKCU; break;
                        case HKLM:
                            registry.Root = Wix.RegistryRoot.HKLM; break;
                        //case HKMU:
                        //    registry.Root = Wix.RegistryRoot.HKMU; break;
                        case HKU:
                            registry.Root = Wix.RegistryRoot.HKU; break;
                    }

                    component.Items = new object[] { registry };
                    // Set component ref in FeatureNode
                    Support.SetComponentRef(component, value.Feature);
                }
            }
            // loop through child nodes
            foreach (TreeNode node in keyNode.Nodes) {
                SetRegistries(node, root);
            }
        }

        private string GetKey(TreeNode keyNode) {
            string key = keyNode.Text;
            TreeNode parent = keyNode.Parent;
            while (parent.Parent != null) {
                key = parent.Text + "\\" + key;
                parent = parent.Parent;
            }
            return key;
        }

        #endregion
    }

    [Serializable]
    public class RegistryValue {
        string name = "New Value";
        string id = Common.GetId();
        FeatureProperty feature;
        Wix.RegistryType type;
        static int counter = 1;
        bool win64 = false;

        [Description("Specifies the name of the selected registry key or value.")]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        [Browsable(false)]
        public string Id {
            get { return id; }
            set { id = value; }
        }

        [EditorAttribute(typeof(FeatureEditor), typeof(UITypeEditor))]
        [Description("Features are separated parts of the application that we offer the user to decide whether to install or not.")]
        public FeatureProperty Feature {
            get { return this.feature; }
            set { this.feature = value; }
        }

        public Wix.RegistryType Type {
            get { return type; }
            set { type = value; }
        }

        public bool Win64 {
            get { return win64; }
            set { win64 = value; }
        }

        public RegistryValue(Wix.RegistryType type) {
            this.type = type;
            name = "New "+ type.ToString() +" value " + counter++;
        }
    }

    [Serializable]
    public class RegistrySingleValue : RegistryValue {
        string value;

        public RegistrySingleValue(Wix.RegistryType type)
            : base(type) {
        }

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [Description("Specifies the data stored in the selected registry value.")]
        public string Value {
            get { return value; }
            set { this.value = value; }
        }
    }

    [Serializable]
    public class RegistryMultipleValue : RegistryValue {
        string[] value;

        [Description("Specifies the data stored in the selected registry value.")]
        public string[] Value {
            get { return value; }
            set { this.value = value; }
        }

        public RegistryMultipleValue(Wix.RegistryType type)
            : base(type) {
        }
    }
}
