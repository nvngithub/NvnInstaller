using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NvnInstaller {
    public partial class ButtonsControl : UserControl {
        NvnButton selectedControl;
        Dictionary<ControlType, NvnButton> buttons = new Dictionary<ControlType, NvnButton>();

        public ButtonsControl() {
            InitializeComponent();
            ControlsManager.ButtonsControl = this;
            Globals.KeyDown += new EventHandler<KeyEventArgs>(Globals_KeyDown);

            buttons.Add(ControlType.Components, (NvnButton)btnComponents);
            buttons.Add(ControlType.FileAssociation, (NvnButton)btnFileAssociation);
            buttons.Add(ControlType.Output, (NvnButton)btnOutput);
            buttons.Add(ControlType.ProductInformation, (NvnButton)btnProductInformation);
            buttons.Add(ControlType.Registries, (NvnButton)btnRegistries);
            buttons.Add(ControlType.CustomActions, (NvnButton)btnCustomActions);
            buttons.Add(ControlType.WixCodeEditor, (NvnButton)btnWixCode);
            buttons.Add(ControlType.EnvironmentVariables, (NvnButton)btnEnvironmentVariables);
            buttons.Add(ControlType.Prerequisites, (NvnButton)btnLaunchConditions);
            buttons.Add(ControlType.Property, (NvnButton)btnProperty);
            buttons.Add(ControlType.BuildScheduler, (NvnButton)btnBuildScheduler);
            buttons.Add(ControlType.CustomUIApplication, (NvnButton)btnCustomUIApplication);
        }

        void Globals_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F1) {
                string url = "www.nvninstaller.com/help/";
                if (selectedControl == btnProductInformation) {
                    url += "productinformation";
                } else if (selectedControl == btnComponents) {
                    url += "components";
                } else if (selectedControl == btnRegistries) {
                    url += "registries";
                } else if (selectedControl == btnCustomActions) {
                    url += "customactions";
                } else if (selectedControl == btnCustomUIApplication) {
                    url += "CustomUIApplication";
                }
                Process.Start(url);
            }
        }

        private void ButtonsControl_Load(object sender, EventArgs e) {
            selectedControl = (NvnButton)btnProductInformation;
            selectedControl.IsSelected = true;
            selectedControl.Invalidate();
            ControlsManager.NotifyControlSelectionChanged(ControlType.ProductInformation);
        }

        private void Button_Click(object sender, EventArgs e) {
            SelectControl((NvnButton)sender);
        }

        public void SelectControl(ControlType type) {
            SelectControl(buttons[type]);
        }

        private void SelectControl(NvnButton button) {
            if (selectedControl != null) {
                selectedControl.IsSelected = false;
            }

            selectedControl = button;
            foreach (ControlType type in buttons.Keys) {
                if (buttons[type] == selectedControl) {
                    ControlsManager.NotifyControlSelectionChanged(type);
                    break;
                }
            }
            // Invalidate (paint) all button controls
            selectedControl.IsSelected = true;
            foreach (Control control in this.Controls) {
                if (control is NvnButton) {
                    control.Invalidate();
                }
            }
        }
    }
}
