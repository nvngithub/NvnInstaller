using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
  public partial class InstallTypeControl : UserControl, IButtonEvents {
    public InstallTypeControl() {
      InitializeComponent();
    }

    #region Interface Members

    public event EventHandler BackClicked;
    public event EventHandler NextClicked;
    public event EventHandler CloseClicked;

    #endregion

    private void btnInstallAll_Click(object sender, EventArgs e) {
      Globals.Instance.SelectedInstallType = InstallType.InstallAll;
      if (NextClicked != null) { NextClicked(this, null); }
    }

    private void btnRemove_Click(object sender, EventArgs e) {
      Globals.Instance.SelectedInstallType = InstallType.Remove;
      if (NextClicked != null) { NextClicked(this, null); }
    }

    private void btnRemoveAll_Click(object sender, EventArgs e) {
      Globals.Instance.SelectedInstallType = InstallType.RemoveAll;
      if (NextClicked != null) { NextClicked(this, null); }
    }

    private void btnChange_Click(object sender, EventArgs e) {
      Globals.Instance.SelectedInstallType = InstallType.Change;
      if (NextClicked != null) { NextClicked(this, null); }
    }

    private void btnRepair_Click(object sender, EventArgs e) {
      Globals.Instance.SelectedInstallType = InstallType.Repair;
      if (NextClicked != null) { NextClicked(this, null); }
    }

    private void btnBack_Click(object sender, EventArgs e) {
      if (BackClicked != null) { BackClicked(this, null); }
    }

    private void btnClose_Click(object sender, EventArgs e) {
      if (CloseClicked != null) { CloseClicked(this, null); }
    }
  }
}
