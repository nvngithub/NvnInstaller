using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace NvnInstaller {
    public partial class ProductInformationControl : UserControl {
        ProductInformation productInformation;
        TreeNode currentFeatureNode;
        int newFeatureCount = 0;
        bool profileLoaded = false;

        public ProductInformationControl() {
            InitializeComponent();

            productInformation = new ProductInformation();
            List<NameValue> languages = new List<NameValue>() { new NameValue("English", "1033|1252|WixUI_en-us.wxl"),new NameValue("Arabic", "1025|1256|WixUI_ar-ar.wxl"),
                new NameValue("Chinese, Simplified", "2052|936|WixUI_zh-cn.wxl"),new NameValue("Chinese, Traditional", "1028|950|WixUI_zh-tw.wxl"),
                new NameValue("Czech", "1029|1250|WixUI_cs-cz.wxl"),new NameValue("Danish", "1030|1252|WixUI_da-dk.wxl"),
                new NameValue("Dutch", "1043|1252|WixUI_nl-nl.wxl"),new NameValue("Finnish", "1035|1252|WixUI_fi-fi.wxl"),
                new NameValue("French", "1036|1252|WixUI_fr-fr.wxl"),new NameValue("German", "1031|1252|WixUI_de-de.wxl"),
                new NameValue("Greek", "1032|1253|WixUI_el-gr.wxl"),new NameValue("Hebrew", "1037|1255|WixUI_iw-il.wxl"),
                new NameValue("Hungarian", "1038|1250|WixUI_hu-hu.wxl"),new NameValue("Italian", "1040|1252|WixUI_it-it.wxl"),
                new NameValue("Japanese", "1041|932|WixUI_ja-jp.wxl"),new NameValue("Korean", "1041|932|WixUI_ko-kr.wxl"),
                new NameValue("Norwegian", "1044|1252|WixUI_no-no.wxl"),new NameValue("Polish", "1045|1250|WixUI_pl-pl.wxl"),
                new NameValue("Portuguese, Brazil", "1046|1252|WixUI_pt-br.wxl"),new NameValue("Portuguese, Portugal", "2070|1252|WixUI_pt-pt.wxl"),
                new NameValue("Russian", "1049|1251|WixUI_ru-ru.wxl"),new NameValue("Spanish", "3082|1252|WixUI_es-es.wxl"),
                new NameValue("Swedish", "1053|1252|WixUI_sv-se.wxl"),new NameValue("Turkish", "1055|1254|WixUI_tr-tr.wxl"),
                new NameValue("Ukrainian", "1058|1251|WixUI_uk-ua.wxl")};

            cmbLanguage.DataSource = languages;
            cmbLanguage.DisplayMember = cmbPrerequisite.DisplayMember = "Name";
            cmbLanguage.ValueMember = cmbPrerequisite.ValueMember = "Value";

            cmbPrerequisite.DataSource = Common.GetInstalledBootstrappersList();
            Globals.SelectedPrerequisiteChanged += new EventHandler(Globals_SelectedPrerequisiteChanged);
        }

        void Globals_SelectedPrerequisiteChanged(object index, EventArgs e) {
            cmbPrerequisite.SelectedIndex = (int)index;
        }

        #region Product Information
        private void btnGenerateGuid_Click(object sender, EventArgs e) {
            ProductCode.Text = Guid.NewGuid().ToString();
        }

        private void btnGenerateUpgradeCode_Click(object sender, EventArgs e) {
            UpgradeCode.Text = Guid.NewGuid().ToString();
        }

        private void btnPackageId_Click(object sender, EventArgs e) {
            PackageId.Text = Guid.NewGuid().ToString();
        }

        private void btnOpenManUrl_Click(object sender, EventArgs e) {
            if (ManufacturerUrl.Text != "" && ManufacturerUrl.Text.StartsWith("http", StringComparison.OrdinalIgnoreCase)) {
                Process.Start(ManufacturerUrl.Text);
            }
        }

        private void btnOpenSupportUrl_Click(object sender, EventArgs e) {
            if (SupportUrl.Text != "" && SupportUrl.Text.StartsWith("http", StringComparison.OrdinalIgnoreCase)) {
                Process.Start(SupportUrl.Text);
            }
        }

        private void btnBrowseLicense_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "RTF Files|*.rtf";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                LicenseFile.Text = dlg.FileName;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(LicenseFile.Text) == false) {
                Process.Start("wordpad.exe", "\"" + LicenseFile.Text + "\"");
            }
        }

        private void btnIconFile_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Icon files|*.ico";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                IconFile.Text = dlg.FileName;
                Icon ico = new Icon(dlg.FileName);
                pbIcon.Image = ico.ToBitmap();
            }
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "MSI files|*.msi";
            dlg.DefaultExt = "msi";
            dlg.OverwritePrompt = false;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Output.Text = dlg.FileName;
            }
        }

        #endregion

        #region Features
        private void tvFeatures_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvFeatures.SelectedNode = tvFeatures.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvFeatures_AfterSelect(object sender, TreeViewEventArgs e) {
            // Update last node
            if (currentFeatureNode != null) {
                currentFeatureNode.Tag = pgFeatureProperty.SelectedObject;
            }
            // show property of current node
            currentFeatureNode = e.Node;
            pgFeatureProperty.SelectedObject = currentFeatureNode.Tag;
        }

        private void tvFeatures_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            if (String.IsNullOrEmpty(e.Label) == false) {
                FeatureProperty property = (FeatureProperty)e.Node.Tag;
                property.Name = e.Label;
                pgFeatureProperty.SelectedObject = e.Node.Tag;
            }
        }

        private void pgFeatureProperty_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            FeatureProperty property = (FeatureProperty)pgFeatureProperty.SelectedObject;
            if (property.IsDefault) {
                if (Common.DefaultFeature.Id != property.Id) {
                    Common.DefaultFeature.IsDefault = false;
                    if (tvFeatures.Nodes.Count > 0) {
                        ChangeTreeForeColor(tvFeatures.Nodes[0], Color.Black);
                    }
                    Common.DefaultFeature = property;
                    currentFeatureNode.ForeColor = Color.Blue;
                }
            }
            currentFeatureNode.Text = property.Name;
        }

        private void ChangeTreeForeColor(TreeNode node, Color color) {
            node.ForeColor = color;
            foreach (TreeNode childNode in node.Nodes) {
                ChangeTreeForeColor(childNode, color);
            }
        }

        private void addNew_Feature_Click(object sender, EventArgs e) {
            TreeNode node = null;
            if (tvFeatures.Nodes.Count == 0) {
                if(ProductName.Text == string.Empty) node = tvFeatures.Nodes.Add("Default Feature");
                else node = tvFeatures.Nodes.Add(ProductName.Text);
            } else if (tvFeatures.SelectedNode != null) {
                node = tvFeatures.SelectedNode.Nodes.Add("New Feature" + newFeatureCount++);
            }
            if (node != null) {
                FeatureProperty property = new FeatureProperty();
                property.Id = Common.GetId();
                property.Name = node.Text;
                property.Description = "[Description not available]";
                if (tvFeatures.Nodes.Count == 1 && tvFeatures.Nodes[0].Nodes.Count == 0)/*make node default if it is first node*/ {
                    property.IsDefault = true;
                    node.ForeColor = Color.Blue;
                    Common.DefaultFeature = property;
                }
                node.Tag = property;

                UpdateFeaturesList();
            }
        }

        private void edit_Features_Click(object sender, EventArgs e) {
            if (tvFeatures.SelectedNode != null)
                tvFeatures.SelectedNode.BeginEdit();
        }

        private void mnuDefaultFeature_Click(object sender, EventArgs e) {
            if (tvFeatures.SelectedNode != null) {
                FeatureProperty property = (FeatureProperty)tvFeatures.SelectedNode.Tag;
                property.IsDefault = true;
                if (Common.DefaultFeature.Id != property.Id) {
                    Common.DefaultFeature.IsDefault = false;
                    if (tvFeatures.Nodes.Count > 0) {
                        ChangeTreeForeColor(tvFeatures.Nodes[0], Color.Black);
                    }
                    Common.DefaultFeature = property;
                    currentFeatureNode.ForeColor = Color.Blue;
                }
                pgFeatureProperty.SelectedObject = property;
            }
        }

        private void tvFeatures_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                Delete_FeatureNode();
            } else if (e.KeyCode == Keys.F2) {
                if (tvFeatures.SelectedNode != null) {
                    tvFeatures.SelectedNode.BeginEdit();
                }
            }
        }

        private void delete_Feature_Click(object sender, EventArgs e) {
            Delete_FeatureNode();
        }

        private void Delete_FeatureNode() {
            pgFeatureProperty.SelectedObject = null;
            if (tvFeatures.SelectedNode != null) {
                FeatureProperty selectedProp = (FeatureProperty)tvFeatures.SelectedNode.Tag;
                if (selectedProp.IsDefault) {
                    // check for siblings.. if not make parent as default node
                    TreeNode parentNode = tvFeatures.SelectedNode.Parent;
                    if (parentNode != null) {
                        TreeNode newDefaultNode = null;
                        if (parentNode.Nodes.Count > 1) {
                            newDefaultNode = tvFeatures.SelectedNode.NextNode;
                            if (newDefaultNode == null) {
                                newDefaultNode = tvFeatures.SelectedNode.PrevNode;
                            }

                        } else {
                            newDefaultNode = parentNode;
                        }
                        // change properties of new default node
                        if (newDefaultNode != null) {
                            FeatureProperty property = (FeatureProperty)newDefaultNode.Tag;
                            property.IsDefault = true;
                            Common.DefaultFeature = property;
                            newDefaultNode.ForeColor = Color.Blue;
                        }
                    }
                }
                tvFeatures.SelectedNode.Remove();
            }

            UpdateFeaturesList();
        }

        void UpdateFeaturesList() {
            Common.Features.Nodes.Clear();
            foreach (TreeNode node in tvFeatures.Nodes) {
                TreeNode featureNode = Common.Features.Nodes.Add(node.Text);
                featureNode.Tag = node.Tag;
                CheckDefaultFeature(featureNode);
                if (node.Nodes.Count > 0) {
                    AddFeatureNode(node, featureNode);
                }
            }
        }

        private void AddFeatureNode(TreeNode originalNode, TreeNode copyNode) {
            foreach (TreeNode node in originalNode.Nodes) {
                TreeNode featureNode = copyNode.Nodes.Add(node.Text);
                featureNode.Tag = node.Tag;
                CheckDefaultFeature(featureNode);
                if (node.Nodes.Count > 0) {
                    AddFeatureNode(node, featureNode);
                }
            }
        }

        private void CheckDefaultFeature(TreeNode featureNode) {
            FeatureProperty featureProperty = (FeatureProperty)featureNode.Tag;
            if (featureProperty.IsDefault) {
                Common.DefaultFeature = featureProperty;
            }
        }

        #endregion

        #region User interface
        private void btnViewUIType_Click(object sender, EventArgs e) {
            ViewUITypeForm form = new ViewUITypeForm(productInformation.UserInterfaceType);
            form.ShowDialog();
        }

        private void rbComplete_CheckedChanged(object sender, EventArgs e) {
            productInformation.UserInterfaceType = UIType.Mondo;
        }

        private void rbFeatureTree_CheckedChanged(object sender, EventArgs e) {
            productInformation.UserInterfaceType = UIType.FeatureTree;
        }

        private void rbInstall_CheckedChanged(object sender, EventArgs e) {
            productInformation.UserInterfaceType = UIType.InstallDir;
        }

        private void rbMinimal_CheckedChanged(object sender, EventArgs e) {
            productInformation.UserInterfaceType = UIType.Minimal;
        }

        private void btnBrowseBanner_Click(object sender, EventArgs e) {
            if (Globals.registered == false) {
                (new RegisterForm()).ShowDialog();
                if (Globals.registered == false) {
                    return;
                }
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Bitmaps|*.bmp|PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dlg.ShowDialog() == DialogResult.OK) {
                txtBanner.Text = dlg.FileName;
            }
        }

        private void lnkDefaultBanner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtBanner.Text = "[Default]";
        }

        private void btnBrowseDialog_Click(object sender, EventArgs e) {
            if (Globals.registered == false) {
                (new RegisterForm()).ShowDialog();
                if (Globals.registered == false) {
                    return;
                }
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Bitmaps|*.bmp|PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dlg.ShowDialog() == DialogResult.OK) {
                txtDialog.Text = dlg.FileName;
            }
        }

        private void lnkDefaultDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtDialog.Text = "[Default]";
        }

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

        #region Prerequisites
        private void btnRefresh_Click(object sender, EventArgs e) {
            cmbPrerequisite.DataSource = Common.GetInstalledBootstrappersList();
        }

        private void cmbPrerequisite_SelectedIndexChanged(object sender, EventArgs e) {
            Globals.NotifySelectedPrerequisiteChanged(cmbPrerequisite.SelectedIndex);
        }

        private void lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://www.nvninstaller.com/downloads");
        }


        #endregion


    }
}