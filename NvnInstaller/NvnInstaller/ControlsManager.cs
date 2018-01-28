using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NvnInstaller.Scheduler;

namespace NvnInstaller {
    class ControlsManager {
        static Dictionary<ControlType, Control> controls;
        public static event EventHandler<ControlSelectedEventArgs> ControlSelectionChanged;
        static ControlType selectedControlType;
        static ButtonsControl buttonsControl;
        public static Dictionary<string, TreeView> TreeViews = new Dictionary<string, TreeView>();

        static ControlsManager() {
            controls = new Dictionary<ControlType, Control>();
            // create all controls here and put it inside dictionary
            controls.Add(ControlType.ProductInformation, new ProductInformationControl());
            controls.Add(ControlType.Property, new PropertyControl());
            controls.Add(ControlType.Components, new ComponentsControl());                      
            controls.Add(ControlType.Registries, new RegistriesControl());
            controls.Add(ControlType.FileAssociation, new FileAssociationControl());
            controls.Add(ControlType.EnvironmentVariables, new EnvironmentVariablesControl());  
            controls.Add(ControlType.Prerequisites, new LaunchConditionsControl());  
            controls.Add(ControlType.CustomActions, new CustomActionsControl());
            controls.Add(ControlType.Output, new OutputControl());
            controls.Add(ControlType.WixCodeEditor, new WixCodeEditorControl());
            controls.Add(ControlType.BuildScheduler, new BuildSchedulerControl());
            controls.Add(ControlType.CustomUIApplication, new CustomUIApplication());
        }

        public static Dictionary<ControlType, Control> Controls {
            get { return controls; }
            set { controls = value; }
        }

        public static ProductInformationControl ProductInformation {
            get { return (ProductInformationControl)controls[ControlType.ProductInformation]; }
        }

        public static ComponentsControl Components {
            get { return (ComponentsControl)controls[ControlType.Components]; }
        }

        public static OutputControl OutputControl {
            get { return (OutputControl)controls[ControlType.Output]; }
        }

        public static WixCodeEditorControl WixCodeEditorControl {
            get { return (WixCodeEditorControl)controls[ControlType.WixCodeEditor]; }
        }

        public static PropertyControl PropertyControl {
            get { return (PropertyControl)controls[ControlType.Property]; }
        }

        public static CustomUIApplication CustomUIApplicationControl {
            get { return (CustomUIApplication)controls[ControlType.CustomUIApplication]; }
        }

        public static ControlType SelectedControlType {
            get { return selectedControlType; }
            set { selectedControlType = value; }
        }

        public static ButtonsControl ButtonsControl {
            set { buttonsControl = value; }
        }

        public static void NotifyControlSelectionChanged(ControlType controlType) {
            ControlSelectedEventArgs args = new ControlSelectedEventArgs(controls[controlType], controlType);
            if (ControlSelectionChanged != null) {
                selectedControlType = controlType;
                ControlSelectionChanged(null, args);
            }
        }

        public static void SelectControl(ControlType controlType) {
            buttonsControl.SelectControl(controlType);
        }
    }

    public class ControlSelectedEventArgs : EventArgs {
        Control control;
        ControlType type;

        public ControlSelectedEventArgs(Control control, ControlType type) {
            this.control = control;
            this.type = type;
        }

        public Control Control {
            get { return control; }
            set { control = value; }
        }

        public ControlType Type {
            get { return type; }
            set { type = value; }
        }
    }
}
