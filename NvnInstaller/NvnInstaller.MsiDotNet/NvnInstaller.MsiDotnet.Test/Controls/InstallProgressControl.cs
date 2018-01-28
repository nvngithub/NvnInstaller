using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnInstaller.MsiDotNet;
using System.Threading;

namespace WindowsFormsApplication1 {
  public partial class InstallProgressControl : UserControl, IButtonEvents {

    delegate void AddTextDelegate(string text);
    bool reset = false, approximate = false;

    public InstallProgressControl() {
      InitializeComponent();

      CheckForIllegalCrossThreadCalls = false;
    }

    public void StartInstall() {

      MsiInstaller msiInterface = Globals.Instance.MsiInterface;
      msiInterface.InstallerMessageReceived += new EventHandler<InstallerMessageEventArgs>(msiInterface_InstallerMessageReceived);
      msiInterface.MessageLogged += new EventHandler<LogMessage>(msiInterface_MessageLogged);

      switch (Globals.Instance.SelectedInstallType) {
        case InstallType.Install:
          msiInterface.Update(Globals.Instance.InstallFeatures, Globals.Instance.UninstallFeatures);
          break;
        case InstallType.InstallAll: 
          msiInterface.Install(); break;
        case InstallType.Remove: 
          msiInterface.Uninstall(Globals.Instance.UninstallFeatures); break;
        case InstallType.RemoveAll: 
          msiInterface.Uninstall(); break;
        case InstallType.Repair: msiInterface.Repair(); break;
        case InstallType.Change:
          msiInterface.Update(Globals.Instance.InstallFeatures, Globals.Instance.UninstallFeatures);
          break;
      }
    }

    void msiInterface_InstallerMessageReceived(object sender, InstallerMessageEventArgs e) {
      string message = string.Empty;
      if (e.InstallerMessage.Type == InstallerMessageType.ProgressReport) {
        message = ((ProgressReportMessage)e.InstallerMessage).ToString();

        if (reset) {
          ProgressReportMessage progressReportMessage = (ProgressReportMessage)e.InstallerMessage;
          if (approximate && progressBar1.Maximum < (progressBar1.Value + progressReportMessage.TicksMoved)) return;
          progressBar1.Value += (int)progressReportMessage.TicksMoved;
          AddText("MsiInstall: Moved = " + (int)progressReportMessage.TicksMoved + " Progress = " + progressBar1.Value);
        }

      } else if (e.InstallerMessage.Type == InstallerMessageType.ResetMessage) {
        reset = false;
        message = ((ResetMessage)e.InstallerMessage).ToString();
        AddText("MsiInstall: Reset ticks: " + ((ResetMessage)e.InstallerMessage).Ticks);

        // set progress bar properties
        ResetMessage resetMessage = (ResetMessage)e.InstallerMessage;
        progressBar1.Maximum = (int)resetMessage.Ticks;
        progressBar1.Minimum = 0;
        progressBar1.Step = 1;
        progressBar1.Value = 0;

        approximate = resetMessage.IsApproximate;

        AddText("MsiInstall: Reset done: value = " + progressBar1.Value + " max=" + progressBar1.Maximum);
        reset = true;
      } else if (e.InstallerMessage.Type == InstallerMessageType.ActionData) {
        AddText("MsiInstall: Action Data message =" + ((ActionDataMessage)e.InstallerMessage).Message);
        SetLabel(((ActionDataMessage)e.InstallerMessage).Message);

        //Globals.Instance.MsiInterface.SetUserAction(MsiResponse.Cancel);

      } else if (e.InstallerMessage.Type == InstallerMessageType.ActionStart) {
        ActionStartMessage actionStartMessage = (ActionStartMessage)e.InstallerMessage;
        AddText("MsiInstall: Action start message: action=" + actionStartMessage.Action + " desc=" + actionStartMessage.Description + " time=" + actionStartMessage.Time);
        SetLabel(actionStartMessage.Action + ": " + actionStartMessage.Description);
      } else if (e.InstallerMessage.Type == InstallerMessageType.FileInUse) {
        MsiResponse userAction = (MsiResponse)MessageBox.Show("file in use:" + ((FileInUseMessage)e.InstallerMessage).FilePath, "File in use", MessageBoxButtons.AbortRetryIgnore);
        Globals.Instance.MsiInterface.SetUserAction(userAction);
      } else if (e.InstallerMessage.Type == InstallerMessageType.InstallationComplete) {
        SetLabel("Installation Completed");
        btnCancel.Enabled = false;
        btnBack.Enabled = false;
      }

      AddText("MsiInstall: " + message);
    }

    void msiInterface_MessageLogged(object sender, LogMessage e) {
      AddText(e.Message); 
    }

    private void AddText(string text) {
      if (InvokeRequired) {
        Invoke(new AddTextDelegate(AddText), text);
      } else {
        txtMessage.AppendText(text + Environment.NewLine);
      }
    }

    private void SetLabel(string label) {
      if (InvokeRequired) {
        Invoke(new AddTextDelegate(SetLabel), label);
      } else {
        lblInstallMessage.Text = label + Environment.NewLine;
      }
    }

    #region Event Handlers

    public event EventHandler BackClicked;
    public event EventHandler NextClicked;
    public event EventHandler CloseClicked;

    private void btnBack_Click(object sender, EventArgs e) {
      if (BackClicked != null) { BackClicked(this, null); }
    }

    private void btnNext_Click(object sender, EventArgs e) {
      if (NextClicked != null) { NextClicked(this, null); }
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      if (CloseClicked != null) { CloseClicked(this, null); }
    }

    #endregion
  }
}
