using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.Drawing.Design;
using System.Collections;

namespace NvnInstaller {
    public partial class RegistriesControl : UserControl {
        private const string HKCR = "HKEY_CLASSES_ROOT";
        private const string HKCU = "HKEY_CURRENT_USER";
        private const string HKLM = "HKEY_LOCAL_MACHINE";
        private const string HKU = "HKEY_USERS";

        bool profileLoaded = false;
        int nodeCounter = 1;

        public RegistriesControl() {
            InitializeComponent();
        }

        #region Registry

        private void addKey_Click(object sender, EventArgs e) {
            if (tvRegistries.SelectedNode != null) {
                //1. get node name
                string nodeName = "New Key" + nodeCounter++;
                while (true) {
                    bool nameExists = false;
                    foreach (TreeNode n in tvRegistries.SelectedNode.Nodes) {
                        if (n.Text == nodeName) {
                            nameExists = true;
                            break;
                        }
                    }
                    if (nameExists) {
                        nodeName = "New Key" + nodeCounter++;
                    } else {
                        break;
                    }
                }
                //2. add new node to the selected node
                TreeNode node = tvRegistries.SelectedNode.Nodes.Add(nodeName);
                node.ImageIndex = 0;
                node.BeginEdit();
            }
        }

        private void edit_Registry_Click(object sender, EventArgs e) {
            if (tvRegistries.SelectedNode != null && tvRegistries.SelectedNode.Level > 0) {
                tvRegistries.SelectedNode.BeginEdit();
            }
        }

        private void delete_Registry_Click(object sender, EventArgs e) {
            if (tvRegistries.SelectedNode != null && tvRegistries.SelectedNode.Level > 0) {
                tvRegistries.SelectedNode.Remove();
            }
        }

        private void stringValue_Click(object sender, EventArgs e) {
            AddRegistryValue(Wix.RegistryType.@string);
        }

        private void multipleStringValue_Click(object sender, EventArgs e) {
            AddRegistryValue(Wix.RegistryType.multiString);
        }

        private void binaryValue_Click(object sender, EventArgs e) {
            AddRegistryValue(Wix.RegistryType.binary);
        }

        private void ExpandableString_Click(object sender, EventArgs e) {
            AddRegistryValue(Wix.RegistryType.expandable);
        }

        private void IntegerValue_Click(object sender, EventArgs e) {
            AddRegistryValue(Wix.RegistryType.integer);
        }

        private void AddRegistryValue(Wix.RegistryType type) {
            if (tvRegistries.SelectedNode != null && tvRegistries.SelectedNode.Level > 0) {
                TreeNode node = tvRegistries.SelectedNode;
                if (node.Tag != null)// use values in tag
                {
                    if (type == Wix.RegistryType.multiString) {
                        List<RegistryValue> values = (List<RegistryValue>)node.Tag;
                        values.Add(new RegistryMultipleValue(type));
                    } else {
                        List<RegistryValue> values = (List<RegistryValue>)node.Tag;
                        values.Add(new RegistrySingleValue(type));
                    }
                } else// else create new list and set the tag
                {
                    if (type == Wix.RegistryType.multiString) {
                        List<RegistryValue> values = new List<RegistryValue>();
                        values.Add(new RegistryMultipleValue(type));
                        node.Tag = values;
                    } else {
                        List<RegistryValue> values = new List<RegistryValue>();
                        values.Add(new RegistrySingleValue(type));
                        node.Tag = values;
                    }
                }
                // Reselect to show all added custom items
                tvRegistries.SelectedNode = null;
                tvRegistries.SelectedNode = node;
            }
        }

        private void tvRegistries_AfterSelect(object sender, TreeViewEventArgs e) {
            lstRegistries.Items.Clear();
            TreeNode node = e.Node;
            if (node != null && node.Tag != null && node.Level > 0) {
                List<RegistryValue> values = (List<RegistryValue>)node.Tag;
                foreach (RegistryValue value in values) {
                    lstRegistries.Items.Add(value);
                }
            } else {
                pgRegistry.SelectedObject = null;
            }
        }

        private void tvRegistries_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvRegistries.SelectedNode = tvRegistries.GetNodeAt(e.X, e.Y);
            }
        }

        private void lstRegistries_SelectedIndexChanged(object sender, EventArgs e) {
            pgRegistry.SelectedObject = lstRegistries.SelectedItem;
        }

        private void pgRegistry_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            // Reselect Tree Node to REFRESH list items
            int index = lstRegistries.SelectedIndex;
            TreeNode node = tvRegistries.SelectedNode;
            tvRegistries.SelectedNode = null;
            tvRegistries.SelectedNode = node;
            lstRegistries.SelectedIndex = index;
        }

        private void lstRegistries_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && tvRegistries.SelectedNode != null) {
                List<RegistryValue> values = (List<RegistryValue>)tvRegistries.SelectedNode.Tag;
                while (lstRegistries.SelectedItems.Count > 0) {
                    values.Remove((RegistryValue)lstRegistries.SelectedItems[0]);
                    lstRegistries.Items.Remove(lstRegistries.SelectedItems[0]);
                }
            }
        }

        private void tvRegistries_KeyDown(object sender, KeyEventArgs e) {
            if (tvRegistries.SelectedNode != null && e.KeyCode == Keys.Delete) {
                tvRegistries.SelectedNode.Remove();
            }
        }
        #endregion

        #region Splitter event handlers
        private void Splitter_SizeChanged(object sender, EventArgs e) {
            SplitContainer container = (SplitContainer)sender;
            string distance = Profile.Get(container.Name);
            if (String.IsNullOrEmpty(distance) == false) {
                container.SplitterDistance = Int32.Parse(distance);
                profileLoaded = true;
            }
            container.SizeChanged -= new EventHandler(Splitter_SizeChanged);
        }
        #endregion

    }
}