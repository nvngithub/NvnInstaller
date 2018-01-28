using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller {
    public partial class FeaturesForm : Form {
        public FeaturesForm() {
            InitializeComponent();

            ctrlFeatures.IsEmbeddedInForm = true;
            ctrlFeatures.FeatureSelected += new EventHandler(ctrlFeatures_FeatureSelected);
        }

        public FeatureProperty SelectedProperty {
            get {
                return ctrlFeatures.SelectedProperty;
            }
        }

        private void btnApply_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        void ctrlFeatures_FeatureSelected(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
