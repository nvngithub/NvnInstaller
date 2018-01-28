using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
  public partial class MainForm : Form {

    List<UserControl> controls = new List<UserControl>();
    int controlIndex = 0;

    public MainForm() {
      InitializeComponent();

      controls.Add(new LicenseControl());
      controls.Add(new InstallTypeControl());
      controls.Add(new FeatureSelectControl());
      controls.Add(new InstallProgressControl());
      controls.Add(new FinishControl());

      foreach (Control ctrl in controls) {
        ((IButtonEvents)ctrl).BackClicked += new EventHandler(MainForm_BackClicked);
        ((IButtonEvents)ctrl).NextClicked += new EventHandler(MainForm_NextClicked);
        ((IButtonEvents)ctrl).CloseClicked += new EventHandler(MainForm_CloseClicked);
      }

      LoadControl(controlIndex);
    }

    void MainForm_BackClicked(object sender, EventArgs e) {
      if (controlIndex > 0) {
        if (controls[controlIndex] is FeatureSelectControl && Globals.Instance.SelectedInstallType == InstallType.Install) {
          controlIndex = controlIndex - 1;
        }

        controlIndex = controlIndex - 1;
        LoadControl(controlIndex);
      }
    }

    void MainForm_NextClicked(object sender, EventArgs e) {
      if (controlIndex < controls.Count - 1) {
        if (controls[controlIndex] is LicenseControl) {
          Globals.Instance.LoadMsi();
          if (Globals.Instance.IsAlreadyInstalled == false) {
            Globals.Instance.SelectedInstallType = InstallType.Install;
            controlIndex = controlIndex + 1;
          }
        } else if (controls[controlIndex] is FeatureSelectControl) {
          ((FeatureSelectControl)controls[controlIndex]).UpdateSelectedFeatures();
        } else if (controls[controlIndex] is InstallTypeControl) {
          if (Globals.Instance.SelectedInstallType == InstallType.InstallAll
            || Globals.Instance.SelectedInstallType == InstallType.RemoveAll
            || Globals.Instance.SelectedInstallType == InstallType.Repair) {
            controlIndex = controlIndex + 1;
          }
        }

        controlIndex = controlIndex + 1;
        
        if (controls[controlIndex] is FeatureSelectControl) {
          FeatureSelectControl featureSelectControl = (FeatureSelectControl)controls[controlIndex];
          if (featureSelectControl.IsFeaturesLoaded == false) {
            featureSelectControl.LoadFeatures();
            featureSelectControl.InstallDir = Globals.Instance.InstallDir;
          }
        } else if (controls[controlIndex] is InstallProgressControl) {
          ((InstallProgressControl)controls[controlIndex]).StartInstall();
        }
        
        LoadControl(controlIndex);
      }
    }

    void MainForm_CloseClicked(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadControl(int index) {
      pnlControls.Controls.Clear();
      Control ctrl = controls[controlIndex];
      ctrl.Dock = DockStyle.Fill;
      pnlControls.Controls.Add(ctrl);

      IButtonEvents commonCtrl = (IButtonEvents)ctrl;
    }
  }
}
