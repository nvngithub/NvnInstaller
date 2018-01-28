using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Xml.Serialization;
using System.Xml;

namespace NvnInstaller {
    public partial class ComponentsForm : Form {
        public event EventHandler ComponentNodeSelected;
        bool modalDlg = false;
        TreeView tvComponents;

        public TreeNode SelectedComponentNode {
            get {
                return tvComponents.SelectedNode;
            }
            set {
                tvComponents.SelectedNode = value;
            }
        }

        public ComponentsForm() {
            InitializeComponent();
            tvComponents = ControlsManager.TreeViews["Components"];
            tvComponents.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvComponents_NodeMouseDoubleClick);
            pnlComponents.Controls.Add(tvComponents);
        }

        public ComponentsForm(bool modalDlg)
            : this() {
            this.modalDlg = modalDlg;
        }

        private void tvComponents_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (tvComponents.SelectedNode != null) {
                // set selectedNode property and close window
                ComponentNode componentNode = (ComponentNode)tvComponents.SelectedNode.Tag;
                if (componentNode.Type != ComponentType.Folder || componentNode.Type != ComponentType.RootFolder) {
                    if (ComponentNodeSelected != null) {
                        ComponentNodeSelected(this, null);
                    }
                }
            }

            tvComponents.NodeMouseDoubleClick -= new TreeNodeMouseClickEventHandler(tvComponents_NodeMouseDoubleClick);
            pnlComponents.Controls.Clear();

            if (this.modalDlg) {
                this.DialogResult = DialogResult.OK;
            } else {
                this.Hide();
            }
        }
    }
}