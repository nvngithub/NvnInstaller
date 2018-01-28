using System;
using System.Collections.Generic;
using System.Text;
using Wix = NvnInstaller.WixClasses;
using System.Windows.Forms;

namespace NvnInstaller {
    partial class LaunchConditionsControl : INvnControl {
        void INvnControl.Open(Dictionary<string, object> objects) {
            if (objects.ContainsKey("Conditions")) {
                try {
                    List<LaunchCondition> conditions = (List<LaunchCondition>)objects["Conditions"];
                    conoditionItems.ClearItems();
                    foreach (LaunchCondition condition in conditions) {
                        conoditionItems.AddNewItem(condition);
                    }
                } catch (Exception exc) {
                    Logger.ApplicationLog(new LogMessage(exc.Message, exc));
                }
            }
        }

        void INvnControl.Saving() { UpdateSelectedCondition(false); }

        void INvnControl.InitializeLoad() { }

        void INvnControl.Load() { }

        void INvnControl.Close() { }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {           
            List<LaunchCondition> conditions = new List<LaunchCondition>();
            foreach (LaunchCondition condition in conoditionItems.Items) {
                conditions.Add(condition);
            }

            objects.Add("Conditions", conditions);
        }

        private string GetControlName(Control control) {
            return this.Name + control.Name;
        }

        ControlType INvnControl.Type {
            get { return ControlType.Components; }
        }

        List<Summary> INvnControl.GetSummary() {
            return null;
        }

        // * service pack selected but no value set for service pack
        // * bootstrap selected but files not available
        void INvnControl.Validate() { }

        void INvnControl.InitializeBuild() { UpdateSelectedCondition(false); }

        void INvnControl.Build() {
            foreach (LaunchCondition prerequisiteCondition in conoditionItems.Items) {
                Wix.Condition condition = new Wix.Condition();
                condition.Message = prerequisiteCondition.FailMessage;
                condition.Value = prerequisiteCondition.Condition;
                MsiBuilder.ConditionElements.Add(condition);
            }
        }
    }

    [Serializable]
    public class LaunchCondition {
        public string Name = "LAUNCH_CONDITION";
        public string Condition = "";
        public string FailMessage = "";

        public override string ToString() { return Name; }
    }
}
