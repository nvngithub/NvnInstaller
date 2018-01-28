using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnInstaller.MsiDotNet;

namespace WindowsFormsApplication1 {
  public partial class FeatureSelectControl : UserControl, IButtonEvents {

    private bool featureLoaded = false;

    public FeatureSelectControl() {
      InitializeComponent();
    }

    public bool IsFeaturesLoaded {
      get { return featureLoaded; }
    }

    public string InstallDir {
      set {
        lblLocation.Text = value;
      }
    }

    public void LoadFeatures() {
      try {
        List<MsiFeature> features = Globals.Instance.Features;
        foreach (MsiFeature feature in features) {
          LoadFeatureTree(feature, null);
        }

        featureLoaded = true;
      } catch (Exception exc) {
        MessageBox.Show(exc.Message);
      }
    }

    private void LoadFeatureTree(MsiFeature feature, TreeNode node) {
      TreeNode newNode = null;
      if (node == null) {
        newNode = tvFeatures.Nodes.Add(feature.Title);
        newNode.Tag = feature;
      } else {
        newNode = node.Nodes.Add(feature.Title);
        newNode.Tag = feature;
      }

      newNode.Checked = feature.IsAlreadyInstalled;

      if (feature.ChildFeatures != null) {
        foreach (MsiFeature childFeature in feature.ChildFeatures) {
          LoadFeatureTree(childFeature, newNode);
        }
      }
    }

    public void UpdateSelectedFeatures() {
      Globals.Instance.InstallFeatures.Clear();
      Globals.Instance.UninstallFeatures.Clear();

      foreach (TreeNode node in tvFeatures.Nodes) {
        UpdateSelectedFeatures(node);
      }
    }

    private void UpdateSelectedFeatures(TreeNode node) {
      if (node.Tag != null) {
        MsiFeature feature = (MsiFeature)node.Tag;
        if (node.Checked) {
          Globals.Instance.InstallFeatures.Add(feature);
        } else if (node.Checked == false && feature.IsAlreadyInstalled) {
          Globals.Instance.UninstallFeatures.Add(feature);
        }
      }

      if (node.Nodes != null) {
        foreach (TreeNode childNode in node.Nodes) {
          UpdateSelectedFeatures(childNode);
        }
      }
    }

    private void btnBrowse_Click(object sender, EventArgs e) {
      FolderBrowserDialog dlg = new FolderBrowserDialog();
      dlg.RootFolder = Environment.SpecialFolder.Desktop;
      if (dlg.ShowDialog() == DialogResult.OK) {
        lblLocation.Text = dlg.SelectedPath;
        Globals.Instance.MsiInterface.InstallDirectory = dlg.SelectedPath;
      }
    }

    private void tvFeatures_AfterSelect(object sender, TreeViewEventArgs e) {
      if (e.Node.Tag != null) {
        MsiFeature feature = (MsiFeature)e.Node.Tag;
        lblDescription.Text = feature.Description;
        lblFileCost.Text = "Feature Cost " + (feature.FeatureCost / 1024) + " K bytes";
        lblTotalFeatureCost.Text = "Total feature cost inclusing child features " + (feature.TotalCost / 1024) + " K bytes";
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
