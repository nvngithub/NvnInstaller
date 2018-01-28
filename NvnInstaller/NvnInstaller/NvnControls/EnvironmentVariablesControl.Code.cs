using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;

namespace NvnInstaller {
    partial class EnvironmentVariablesControl : INvnControl {
        void INvnControl.Open(Dictionary<string, object> objects) {
            Dictionary<string, EnvironmentVariable> variables = (Dictionary<string, EnvironmentVariable>)objects["EnvironmentVariables"];
            // create items in datagrid
            environmentVaribaleItems.ClearItems();
            foreach (string id in variables.Keys) {
                EnvironmentVariable variable = variables[id];
                environmentVaribaleItems.AddNewItem(variable);
            }
        }

        void INvnControl.Saving() { dgrProperties.CommitEdit(DataGridViewDataErrorContexts.Commit); }

        void INvnControl.InitializeLoad() {
            environmentVaribaleItems.ClearItems();
            dgrProperties.Rows.Clear();
        }

        void INvnControl.Load() { }

        void INvnControl.Close() { }

        ControlType INvnControl.Type {
            get { return ControlType.EnvironmentVariables; }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            Dictionary<string, EnvironmentVariable> envVariables = new Dictionary<string, EnvironmentVariable>();
            foreach (EnvironmentVariable envVariable in environmentVaribaleItems.Items) {
                envVariables.Add(envVariable.Id, envVariable);
            }
            objects.Add("EnvironmentVariables", envVariables);
        }

        List<Summary> INvnControl.GetSummary() { return null; }

        //1. check for valid names
        //2. using create but looks like it should be update... Like for PATH better is user uses update than create
        //3. feature is set
        void INvnControl.Validate() { }

        void INvnControl.InitializeBuild() {
            dgrProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        void INvnControl.Build() {
            MsiBuilder.EnvironmentComponents.Clear();

            foreach (EnvironmentVariable envVariable in environmentVaribaleItems.Items) {
                // create component node for each key
                Wix.Component component = new Wix.Component();
                component.Id = Common.GetId();
                component.Guid = Guid.NewGuid().ToString();
                // add this component to install directory
                MsiBuilder.EnvironmentComponents.Add(component);

                Wix.Environment environment = new Wix.Environment();
                environment.Id = envVariable.Id;
                environment.ActionSpecified = true;
                environment.Action = envVariable.Action;
                environment.Name = envVariable.Name;
                environment.PermanentSpecified = true;
                environment.Permanent = envVariable.Permanent ? Wix.YesNoType.yes : Wix.YesNoType.no;
                environment.SystemSpecified = true;
                environment.System = envVariable.SystemEnvironmentVariable ? Wix.YesNoType.yes : Wix.YesNoType.no;
                environment.Value = envVariable.Value;
                environment.Separator = ";";
                environment.Part = Wix.EnvironmentPart.last;
                environment.PartSpecified = true;

                component.Items = new object[] { environment };
                // Set component ref in FeatureNode
                Support.SetComponentRef(component, envVariable.Feature);
            }
        }
    }

    [Serializable]
    class EnvironmentVariable {
        public string Id = Common.GetId();
        public Wix.EnvironmentAction Action;
        public string ActionPropertyText = "Action";
        public string Name = "NEW_EVN_VARIABLE";
        public string NamePropertyText = "Name";
        public bool Permanent = false;
        public string PermanentPropertyText = "Permanent";
        public bool SystemEnvironmentVariable = false;
        public string SysEnvironmentVarPropertyText = "Is System Variable ?";
        public string Value;
        public string ValuePropertyText = "Value";
        public FeatureProperty Feature;
        public string FeaturePropertyText = "Feature";

        public override string ToString() {
            return Name;
        }
    }
}
