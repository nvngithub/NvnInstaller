using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WindowsFormsApplication1 {
  public partial class LicenseControl : UserControl, IButtonEvents {
    public LicenseControl() {
      InitializeComponent();

      txtLicense.Rtf = LoadText();
    }

    private string LoadText() {
      Assembly assem = this.GetType().Assembly;
      using (Stream stream = assem.GetManifestResourceStream(this.GetType().Namespace +  ".test.rtf")) {
        using (StreamReader reader = new StreamReader(stream)) {
          return reader.ReadToEnd();
        }
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
      if (rbYes.Checked) {
        if (NextClicked != null) { NextClicked(this, null); }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      if (CloseClicked != null) { CloseClicked(this, null); }
    }

    #endregion
  }
}
