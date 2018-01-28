using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace NvnInstaller {
    public partial class FeaturesControl : UserControl {
        private bool isEmbeddedInForm = false;
        public event EventHandler FeatureSelected;

        public FeaturesControl() {
            InitializeComponent();

            foreach (TreeNode node in Common.Features.Nodes) {
                TreeNode featureNode = tvFreatures.Nodes.Add(node.Text);
                featureNode.Tag = node.Tag;
                if (node.Nodes.Count > 0) {
                    AddFeatureNode(node, featureNode);
                }
            }
        }

        private void AddFeatureNode(TreeNode originalNode, TreeNode copyNode) {
            foreach (TreeNode node in originalNode.Nodes) {
                TreeNode featureNode = copyNode.Nodes.Add(node.Text);
                featureNode.Tag = node.Tag;
                if (node.Nodes.Count > 0) {
                    AddFeatureNode(node, featureNode);
                }
            }
        }

        public FeatureProperty SelectedProperty {
            get {
                if (tvFreatures.SelectedNode != null) {
                    return (FeatureProperty)tvFreatures.SelectedNode.Tag;
                }
                return null;
            }
        }

        public bool IsEmbeddedInForm {
            get { return this.isEmbeddedInForm; }
            set {
                isEmbeddedInForm = value;
                lnkClose.Visible = !isEmbeddedInForm;
            }
        }

        public IWindowsFormsEditorService EditorService { get; set; }

        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Invalidate(false);
            EditorService.CloseDropDown();
        }

        private void tvFreatures_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            this.Invalidate(false);
            if (isEmbeddedInForm == false) {
                EditorService.CloseDropDown();
            }

            if (isEmbeddedInForm) {
                if (FeatureSelected != null) {
                    FeatureSelected(null, null);
                }
            }
        }
    }

    public class FeatureEditor : UITypeEditor {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            IWindowsFormsEditorService editorService = null;
            if (provider != null) {
                editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }

            if (editorService != null) {
                FeaturesControl featureControl = new FeaturesControl();
                featureControl.EditorService = editorService;
                editorService.DropDownControl(featureControl);
                value = featureControl.SelectedProperty;
            }

            return value;
        }
    }
}
