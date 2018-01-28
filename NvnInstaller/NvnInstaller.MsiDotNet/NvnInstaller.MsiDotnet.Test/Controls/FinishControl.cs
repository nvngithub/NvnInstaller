using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1 {
  public partial class FinishControl : UserControl, IButtonEvents {
    public FinishControl() {
      InitializeComponent();
    }

    #region Interface Members

    public event EventHandler BackClicked;
    public event EventHandler NextClicked;
    public event EventHandler CloseClicked;

    #endregion

    private void btnCancel_Click(object sender, EventArgs e) {
      if (chkVisitWebsite.Checked) {
        Process.Start("www.nvninstaller.com");
      }

      if (chkStartApplication.Checked) {
        Process.Start("iexplore");
      }

      if (CloseClicked != null) { CloseClicked(this, null); }
    }
  }
}
