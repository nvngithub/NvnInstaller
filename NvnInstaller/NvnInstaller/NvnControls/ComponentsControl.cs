using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace NvnInstaller {
    public delegate void AddNewNodeDelegate(TreeNode node, TreeNode newNode);

    public partial class ComponentsControl : UserControl {
        int newFolderCount = 0;
        int folderImageIndex, selectedFolderImageIndex, internetImageIndex;
        private SysImageList sysilsSmall = new SysImageList(SysImageListSize.smallIcons);
        int filesCount, FoldersCount;
        BackgroundWorker addFilesFoldersThread = new BackgroundWorker();
        bool profileLoaded = false;
        ComponentsRootFolderType componentsRootFolderType;

        public ComponentsControl() {
            InitializeComponent();

            SysImageListHelper.SetTreeViewImageList(tvComponents, sysilsSmall, false);
            SysImageListHelper.SetTreeViewImageList(tvSystemFolder, sysilsSmall, false);
            SysImageListHelper.SetTreeViewImageList(tvShortcuts, sysilsSmall, false);
            folderImageIndex = sysilsSmall.IconIndex(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), true);
            selectedFolderImageIndex = sysilsSmall.IconIndex(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), true, ShellIconStateConstants.ShellIconStateOpen);
            internetImageIndex = sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgInternet, true);

            InitializeSystemFolders();
            InitializeShortcutFolders();

            ControlsManager.TreeViews.Add("Components", tvComponents);
            ControlsManager.ControlSelectionChanged += new EventHandler<ControlSelectedEventArgs>(ControlsManager_ControlSelectionChanged);

            addFilesFoldersThread.WorkerReportsProgress = addFilesFoldersThread.WorkerSupportsCancellation = true;
            addFilesFoldersThread.DoWork += new DoWorkEventHandler(AddFilesFolders_Start);
            addFilesFoldersThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AddFilesFolders_Complete);
            addFilesFoldersThread.ProgressChanged += new ProgressChangedEventHandler(AddFilesFolders_ProgressChanged);
        }

        void ControlsManager_ControlSelectionChanged(object sender, ControlSelectedEventArgs e) {
            if (e.Type == ControlType.Components) {
                // add all eventhadlers
                this.tvComponents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvComponents_MouseClick);
                this.tvComponents.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvComponents_DragDrop);
                this.tvComponents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvComponents_AfterSelect);
                this.tvComponents.DragEnter += new System.Windows.Forms.DragEventHandler(this.Components_DragEnter);
                this.tvComponents.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvComponents_BeforeLabelEdit);
                this.tvComponents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvComponents_KeyDown);
                this.tvComponents.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvComponents_ItemDrag);
                tabControlComponents_SelectedIndexChanged(null, null);
            } else {
                this.tvComponents.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.tvComponents_MouseClick);
                this.tvComponents.DragDrop -= new System.Windows.Forms.DragEventHandler(this.tvComponents_DragDrop);
                this.tvComponents.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.tvComponents_AfterSelect);
                this.tvComponents.DragEnter -= new System.Windows.Forms.DragEventHandler(this.Components_DragEnter);
                this.tvComponents.BeforeLabelEdit -= new System.Windows.Forms.NodeLabelEditEventHandler(this.tvComponents_BeforeLabelEdit);
                this.tvComponents.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.tvComponents_KeyDown);
                this.tvComponents.ItemDrag -= new System.Windows.Forms.ItemDragEventHandler(this.tvComponents_ItemDrag);
            }
        }

        #region Components Event Handlers
        private void customFolder_Components_Click(object sender, EventArgs e) {
            if (tvComponents.Nodes.Count == 0) {
                componentsRootFolderType = ComponentsRootFolderType.Custom;
                TreeNode node = new TreeNode("", folderImageIndex, selectedFolderImageIndex);
                node.Tag = new ComponentNode(ComponentType.RootFolder | ComponentType.Folder, new ComponentProperty());
                tvComponents.Nodes.Add(node);
                lblFolders.Text = (FoldersCount = 1).ToString();
                node.BeginEdit();
            } else {
                MessageBox.Show("Application supports only one root folder.", "Root folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void programFilesCustom_Components_Click(object sender, EventArgs e) {
            if (tvComponents.Nodes.Count == 0) {
                componentsRootFolderType = ComponentsRootFolderType.Program_Custom;
                TreeNode node = new TreeNode("[Program Files]", folderImageIndex, selectedFolderImageIndex);
                node.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
                tvComponents.Nodes.Add(node);
                TreeNode customNode = new TreeNode("Custom Folder", folderImageIndex, selectedFolderImageIndex);
                customNode.Tag = new ComponentNode(ComponentType.Folder, new ComponentProperty());
                node.Nodes.Add(customNode);
                lblFolders.Text = (FoldersCount = 2).ToString();
                customNode.BeginEdit();
            } else {
                MessageBox.Show("Application supports only one root folder.", "Root folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void programFilesProductName_Components_Click(object sender, EventArgs e) {
            if (tvComponents.Nodes.Count == 0) {
                componentsRootFolderType = ComponentsRootFolderType.Program_product;
                TreeNode node = new TreeNode("[Program Files]", folderImageIndex, selectedFolderImageIndex);
                node.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
                tvComponents.Nodes.Add(node);
                TreeNode productNode = new TreeNode("[Product Name]", folderImageIndex, selectedFolderImageIndex);
                productNode.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
                node.Nodes.Add(productNode);
                lblFolders.Text = (FoldersCount = 2).ToString();
            } else {
                MessageBox.Show("Application supports only one root folder.", "Root folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void programFilesManufacturerProductName_Components_Click(object sender, EventArgs e) {
            if (tvComponents.Nodes.Count == 0) {
                componentsRootFolderType = ComponentsRootFolderType.Program_Manufacturer_Product;
                TreeNode node = new TreeNode("[Program Files]", folderImageIndex, selectedFolderImageIndex);
                node.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
                tvComponents.Nodes.Add(node);
                TreeNode manufacturerNode = new TreeNode("[Manufacturer]", folderImageIndex, selectedFolderImageIndex);
                manufacturerNode.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
                node.Nodes.Add(manufacturerNode);
                TreeNode productNode = new TreeNode("[Product Name]", folderImageIndex, selectedFolderImageIndex);
                productNode.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
                manufacturerNode.Nodes.Add(productNode);
                lblFolders.Text = (FoldersCount = 3).ToString();
            } else {
                MessageBox.Show("Application supports only one root folder.", "Root folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addFolder_Components_Click(object sender, EventArgs e) {
            CreateFolder(tvComponents);
        }

        private void browseFolder_Components_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            if (dlg.ShowDialog() == DialogResult.OK) {
                StartAddFilesFoldersThread(tvComponents.SelectedNode, dlg.SelectedPath);
            }
        }

        private void browseFiles_Components_Click(object sender, EventArgs e) {
            AddFilesToSelectedNode(tvComponents, "*.*|*.*");
        }

        private void addService_Click(object sender, EventArgs e) {
            TreeNode selectedNode = tvComponents.SelectedNode;
            if (CanAddFolder_File(selectedNode)) {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = true;
                dlg.Filter = "Services|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    foreach (string filename in dlg.FileNames) {
                        FileInfo fileInfo = new FileInfo(filename);
                        TreeNode node = new TreeNode(fileInfo.Name, sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgService, true), sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgService, true));
                        tvComponents.SelectedNode.Nodes.Add(node);
                        ComponentProperty property = new ComponentProperty();
                        property.Id = Common.GetId();
                        property.SourcePath = fileInfo.FullName;
                        node.Tag = new ComponentNode(ComponentType.Service, property);
                    }
                }
            }
        }

        private void addAssembly_Components_Click(object sender, EventArgs e) {
            TreeNode selectedNode = tvComponents.SelectedNode;
            if (CanAddFolder_File(selectedNode)) {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = true;
                dlg.Filter = "Assembly|*.exe;*.dll";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    foreach (string filename in dlg.FileNames) {
                        FileInfo fileInfo = new FileInfo(filename);
                        TreeNode node = new TreeNode("[Assembly:" + fileInfo.Name + "]", sysilsSmall.IconIndex(fileInfo.FullName, true), sysilsSmall.IconIndex(fileInfo.FullName, true));
                        tvComponents.SelectedNode.Nodes.Add(node);
                        ComponentProperty property = new ComponentProperty();
                        property.Id = Common.GetId();
                        property.SourcePath = fileInfo.FullName;
                        node.Tag = new ComponentNode(ComponentType.Assembly, property);
                    }
                }
            }
        }

        private void tvComponents_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                Delete_Components_Folder();
            } else if (e.KeyCode == Keys.F2) {
                if (tvComponents.SelectedNode != null) {
                    tvComponents.SelectedNode.BeginEdit();
                }
            }
        }

        private void delete_Components_Click(object sender, EventArgs e) {
            Delete_Components_Folder();
        }

        private void Delete_Components_Folder() {
            if (tvComponents.SelectedNode != null) {
                TreeNode selectedNode = tvComponents.SelectedNode;
                ComponentNode componentNode = (ComponentNode)selectedNode.Tag;
                if (componentNode.Type == ComponentType.RootFolder) {
                    tvComponents.Nodes[0].Remove();
                } else {
                    tvComponents.SelectedNode.Remove();
                }

                // change files, folders count
                CalculateFilesFoldersCount_Start();
            }
        }

        private void edit_Components_Click(object sender, EventArgs e) {
            tvComponents.SelectedNode.BeginEdit();
        }

        private void tvComponents_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvComponents.SelectedNode = tvComponents.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvComponents_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
            if (tvComponents.SelectedNode != null) {
                ComponentNode node = (ComponentNode)tvComponents.SelectedNode.Tag;
                if (node.Type == ComponentType.RootFolder)
                    e.CancelEdit = true;
            }
        }

        // this is needed when an item is dragged from WindowsControl
        private void tvComponents_DragDrop(object sender, DragEventArgs e) {
            string path = string.Empty;
            Point pos = tvComponents.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = tvComponents.GetNodeAt(pos);
            List<string> formats = new List<string>(e.Data.GetFormats());
            if (formats.Contains("System.Windows.Forms.TreeNode")) {
                TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                path = (string)sourceNode.Tag;
                // recursively add files and folder to this target node
                StartAddFilesFoldersThread(targetNode, path);
            } else if (formats.Contains("System.Windows.Forms.ListView+SelectedListViewItemCollection")) {
                ListView.SelectedListViewItemCollection items = (ListView.SelectedListViewItemCollection)e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");
                //  recursively add files and folder for each item
                foreach (ListViewItem item in items) {
                    path = (string)item.Tag;
                    StartAddFilesFoldersThread(targetNode, path);
                }
            }
        }

        private void tvComponents_AfterSelect(object sender, TreeViewEventArgs e) {
            ComponentNode node = (ComponentNode)e.Node.Tag;
            if (node.Type == ComponentType.File || node.Type == ComponentType.Assembly) {
                pgComponent.SelectedObject = node.Property;
                pgServices.SelectedObject = null;
                tabControlProperties.SelectedIndex = 0;
                // Disable context menu options
                browseFilesToolStripMenuItem.Enabled = false;
                mnuAddService.Enabled = false;
                addAssemblyToolStripMenuItem.Enabled = false;
                addFolderToolStripMenuItem.Enabled = false;
                windowsFolderToolStripMenuItem.Enabled = false;
            } else if (node.Type == ComponentType.Service) {
                pgComponent.SelectedObject = node.Property;
                pgServices.SelectedObject = node.Property.ServiceProperty;
                tabControlProperties.SelectedIndex = 1;
                // Disable context menu options
                browseFilesToolStripMenuItem.Enabled = false;
                mnuAddService.Enabled = false;
                addAssemblyToolStripMenuItem.Enabled = false;
                addFolderToolStripMenuItem.Enabled = false;
                windowsFolderToolStripMenuItem.Enabled = false;
            } else {
                pgComponent.SelectedObject = null;
                pgServices.SelectedObject = null;
                tabControlProperties.SelectedIndex = 0;
                // enable context menu options
                browseFilesToolStripMenuItem.Enabled = true;
                mnuAddService.Enabled = true;
                addAssemblyToolStripMenuItem.Enabled = true;
                addFolderToolStripMenuItem.Enabled = true;
                windowsFolderToolStripMenuItem.Enabled = true;
            }
        }

        private void tvComponents_ItemDrag(object sender, ItemDragEventArgs e) {
            TreeNode sourceNode = (TreeNode)e.Item;
            tvComponents.SelectedNode = sourceNode;
            ComponentNode component = (ComponentNode)sourceNode.Tag;
            if (component != null && component.Type == ComponentType.File)
                DoDragDrop(sourceNode, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void Components_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void applyFeature_Components_Click(object sender, EventArgs e) {
            if (tvComponents.SelectedNode != null) {
                ShowFeatures(tvComponents.SelectedNode);
            }
        }

        private void applyPatch_Components_Click(object sender, EventArgs e) {
            if (tvComponents.SelectedNode != null) {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    ComponentNode componentNode = (ComponentNode)tvComponents.SelectedNode.Tag;
                    if (componentNode != null) {
                        componentNode.Property.PatchFile = dlg.FileName;
                        ChangeNodeColor(tvComponents.SelectedNode, true, Globals.PatchFileColor);
                    }
                }
            }
        }

        private void pgComponent_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            ComponentProperty selectedComponent = (ComponentProperty)pgComponent.SelectedObject;
            if (String.IsNullOrEmpty(selectedComponent.PatchFile) == false) {
                ChangeNodeColor(tvComponents.SelectedNode, true, Globals.PatchFileColor);
            }
        }
        #endregion

        #region Shortcuts Event Handlers
        private void InitializeShortcutFolders() {
            TreeNode shortcutNode = new TreeNode("StartMenu->All Programs", folderImageIndex, selectedFolderImageIndex);
            tvShortcuts.Nodes.Add(shortcutNode);
            shortcutNode.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());

            TreeNode desktopNode = new TreeNode("Desktop", folderImageIndex, selectedFolderImageIndex);
            tvShortcuts.Nodes.Add(desktopNode);
            desktopNode.Tag = new ComponentNode(ComponentType.RootFolder, new ComponentProperty());
        }

        private void delete_Shortcuts_Click(object sender, EventArgs e) {
            if (tvShortcuts.SelectedNode != null && tvShortcuts.SelectedNode.Level != 0)
                tvShortcuts.SelectedNode.Remove();
        }

        private void tvShortcuts_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (tvShortcuts.SelectedNode != null && tvShortcuts.SelectedNode.Level != 0)
                    tvShortcuts.SelectedNode.Remove();
            }
        }

        private void edit_Shortcuts_Click(object sender, EventArgs e) {
            ComponentNode node = (ComponentNode)tvShortcuts.SelectedNode.Tag;
            if (node != null && node.Type == ComponentType.Folder && tvShortcuts.SelectedNode.Level != 0)
                tvShortcuts.SelectedNode.BeginEdit();
        }

        private void createFolder_Shortcuts_Click(object sender, EventArgs e) {
            if (tvShortcuts.SelectedNode != null && tvShortcuts.SelectedNode.Tag is InternetShortcutProperty) {
                return;
            }

            CreateFolder(tvShortcuts);
        }

        private void addFile_Shortcuts_Click(object sender, EventArgs e) {
            if (tvShortcuts.SelectedNode != null) {
                ComponentsForm componentsForm = new ComponentsForm(true);
                if (componentsForm.ShowDialog() == DialogResult.OK) {
                    TreeNode selectedComponentNode = componentsForm.SelectedComponentNode;
                    ComponentNode tag = (ComponentNode)tvShortcuts.SelectedNode.Tag;
                    if ((tag != null && tag.Type == ComponentType.Folder) || tvShortcuts.SelectedNode.Level == 0) {
                        TreeNode newNode = new TreeNode(selectedComponentNode.Text, selectedComponentNode.ImageIndex, selectedComponentNode.SelectedImageIndex);
                        newNode.Tag = selectedComponentNode.Tag;// assign complete ComponentNode object of component node
                        ((ComponentNode)newNode.Tag).SecondaryTreeNode = selectedComponentNode; // assign Component Tree node itself
                        tvShortcuts.SelectedNode.Nodes.Add(newNode);
                        tvShortcuts.Invalidate();
                    }
                }
                // Show component tree again
                pnlComponents.Controls.Clear();
                pnlComponents.Controls.Add(ControlsManager.TreeViews["Components"]);
            }
        }

        private void tabControlComponents_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControlComponents.SelectedIndex == 0) {
                splitContainerComponents.Panel1.Controls.Clear();
                splitContainerComponents.Panel1.Controls.Add(ControlsManager.TreeViews["Components"]);
            } else if (tabControlComponents.SelectedIndex == 2) {
                pnlComponents.Controls.Clear();
                pnlComponents.Controls.Add(ControlsManager.TreeViews["Components"]);
            }
        }

        private void tvShortcuts_DragDrop(object sender, DragEventArgs e) {
            //TreeNode sourceNode = (TreeNode)e.Item;
            Point pos = tvShortcuts.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = tvShortcuts.GetNodeAt(pos);
            ComponentNode tag = (ComponentNode)targetNode.Tag;

            if (targetNode != null && (tag != null && tag.Type == ComponentType.Folder) || targetNode.Level == 0) {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                TreeNode nodeCopy = new TreeNode(node.Text, tvComponents.SelectedNode.ImageIndex, tvComponents.SelectedNode.SelectedImageIndex);
                nodeCopy.Tag = node.Tag;// assign complete ComponentNode object of component node
                ((ComponentNode)nodeCopy.Tag).SecondaryTreeNode = node; // assign Component Tree node itself
                targetNode.Nodes.Add(nodeCopy);
                tvShortcuts.Invalidate();
            }
        }

        private void tvShortcuts_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvShortcuts.SelectedNode = tvShortcuts.GetNodeAt(e.X, e.Y);
            }
        }

        private void tvShortcuts_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
            if (e.Node.Level == 0)
                e.CancelEdit = true;
        }

        private void internetShortcut_Shortcuts_Click(object sender, EventArgs e) {
            if (tvShortcuts.SelectedNode != null && tvShortcuts.SelectedNode.Tag is ComponentNode) {
                TreeNode selectedNode = tvShortcuts.SelectedNode;
                TreeNode newNode = new TreeNode("New Internet Shortcut", internetImageIndex, internetImageIndex);
                newNode.Tag = new ComponentNode(ComponentType.InternetShortcut, new ComponentProperty());
                selectedNode.Nodes.Add(newNode);
                newNode.BeginEdit();
            }
        }

        private void tvShortcuts_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode selectedNode = tvShortcuts.SelectedNode;
            if (selectedNode != null) {
                ComponentNode componentNode = (ComponentNode)selectedNode.Tag;
                if (componentNode.Type == ComponentType.InternetShortcut) {
                    tabShortcutProperty.SelectedIndex = 1;
                    pgShortcuts.SelectedObject = componentNode.Property.ShortcutProperty;
                } else {
                    tabShortcutProperty.SelectedIndex = 0;
                    pgShortcuts.SelectedObject = null;
                }
            }
        }

        private void tvShortcuts_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvShortcuts.SelectedNode = tvShortcuts.GetNodeAt(e.X, e.Y);
            }
        }
        #endregion

        #region System Folder Event Handlers
        private void InitializeSystemFolders() {
            // add nodes
            foreach (SystemFolderType folder in Enum.GetValues(typeof(SystemFolderType))) {
                TreeNode node = new TreeNode(folder.ToString(), folderImageIndex, selectedFolderImageIndex);
                node.Tag = new ComponentNode(ComponentType.RootFolder | ComponentType.Folder, new ComponentProperty());
                tvSystemFolder.Nodes.Add(node);
            }
        }

        private void tvSystemFolder_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvSystemFolder.SelectedNode = tvSystemFolder.GetNodeAt(e.X, e.Y);
            }
        }

        private void createFolder_SystemFolder_Click(object sender, EventArgs e) {
            CreateFolder(tvSystemFolder);
        }

        private void addFolder_SystemFolder_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            if (dlg.ShowDialog() == DialogResult.OK) {
                StartAddFilesFoldersThread(tvSystemFolder.SelectedNode, dlg.SelectedPath);
            }
        }

        private void addFiles_SystemFolder_Click(object sender, EventArgs e) {
            AddFilesToSelectedNode(tvSystemFolder, "*.*|*.*");
        }

        private void edit_SystemFolder_Click(object sender, EventArgs e) {
            ComponentNode node = (ComponentNode)tvSystemFolder.SelectedNode.Tag;
            if (node != null && node.Type == ComponentType.Folder)
                tvSystemFolder.SelectedNode.BeginEdit();
        }

        private void delete_SystemFolder_Click(object sender, EventArgs e) {
            if (tvSystemFolder.SelectedNode != null && tvSystemFolder.SelectedNode.Level != 0) {
                tvSystemFolder.SelectedNode.Remove();
            }
        }

        private void tvSystemFolder_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (tvSystemFolder.SelectedNode != null && tvSystemFolder.SelectedNode.Level != 0)
                    tvSystemFolder.SelectedNode.Remove();
            }
        }

        private void tvSystemFolder_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void tvSystemFolder_DragDrop(object sender, DragEventArgs e) {
            string path = string.Empty;
            Point pos = tvSystemFolder.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = tvSystemFolder.GetNodeAt(pos);
            List<string> formats = new List<string>(e.Data.GetFormats());
            if (formats.Contains("System.Windows.Forms.TreeNode")) {
                TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                path = (string)sourceNode.Tag;
                // recursively add files and folder to this target node
                StartAddFilesFoldersThread(targetNode, path);
            } else if (formats.Contains("System.Windows.Forms.ListView+SelectedListViewItemCollection")) {
                ListView.SelectedListViewItemCollection items = (ListView.SelectedListViewItemCollection)e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");
                //  recursively add files and folder for each item
                foreach (ListViewItem item in items) {
                    path = (string)item.Tag;
                    StartAddFilesFoldersThread(targetNode, path);
                }
            }
        }

        private void tvSystemFolder_AfterSelect(object sender, TreeViewEventArgs e) {
            ComponentNode componentNode = (ComponentNode)e.Node.Tag;
            pgSystemFolderComponents.SelectedObject = componentNode.Property;
        }

        private void applyFeature_SystemFolder_Click(object sender, EventArgs e) {
            if (tvSystemFolder.SelectedNode != null) {
                ShowFeatures(tvSystemFolder.SelectedNode);
            }
        }

        #endregion

        #region Private Functions
        private void CreateFolder(TreeView treeview) {
            if (treeview.SelectedNode != null) {
                TreeNode selectedNode = treeview.SelectedNode;
                if (CanAddFolder_File(selectedNode)) {
                    TreeNode newNode = new TreeNode("New Folder " + newFolderCount++, folderImageIndex, selectedFolderImageIndex);
                    newNode.Tag = new ComponentNode(ComponentType.Folder, new ComponentProperty());
                    selectedNode.Nodes.Add(newNode);
                    lblFolders.Text = (FoldersCount += 1).ToString();
                    newNode.BeginEdit();
                }
            }
        }

        private void AddFilesToSelectedNode(TreeView treeview, string filter) {
            TreeNode selectedNode = treeview.SelectedNode;
            if (CanAddFolder_File(selectedNode)) {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = true;
                dlg.Filter = filter;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    foreach (string filename in dlg.FileNames) {
                        FileInfo fileInfo = new FileInfo(filename);
                        TreeNode newNode = new TreeNode(fileInfo.Name, sysilsSmall.IconIndex(fileInfo.FullName, true), sysilsSmall.IconIndex(fileInfo.FullName, true));
                        treeview.SelectedNode.Nodes.Add(newNode);
                        ComponentProperty property = new ComponentProperty();
                        property.Id = Common.GetId();
                        property.SourcePath = fileInfo.FullName;
                        newNode.Tag = new ComponentNode(ComponentType.File, property);
                    }

                    // change file, folder count value
                    CalculateFilesFoldersCount_Start();
                }
            }
        }

        private bool CanAddFolder_File(TreeNode selectedNode) {
            if (selectedNode == null)
                return false;
            ComponentNode componentNode = (ComponentNode)selectedNode.Tag;
            if (componentNode.Type == ComponentType.RootFolder) {
                if (selectedNode.Nodes.Count > 0) {
                    TreeNode childNode = selectedNode.Nodes[0];
                    ComponentNode componentNode1 = (ComponentNode)childNode.Tag;
                    if (componentNode1.Type == ComponentType.RootFolder) {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ShowFeatures(TreeNode selectedNode) {
            FeaturesForm featureForm = new FeaturesForm();
            if (featureForm.ShowDialog() == DialogResult.OK) {
                FeatureProperty selectedFeature = featureForm.SelectedProperty;
                ComponentNode componentNode = (ComponentNode)selectedNode.Tag;
                if (componentNode.Type == ComponentType.Folder || componentNode.Type == ComponentType.RootFolder) {
                    // recursively apply selected feature to all nodes under the selected node
                    foreach (TreeNode node in selectedNode.Nodes) {
                        ApplyFeature(node, selectedFeature);
                    }
                } else {
                    componentNode.Property.Feature = selectedFeature;
                }
            }
        }

        private void ApplyFeature(TreeNode node, FeatureProperty selectedFeature) {
            ComponentNode componentNode = (ComponentNode)node.Tag;
            if (componentNode.Type == ComponentType.Folder || componentNode.Type == ComponentType.RootFolder) {
                foreach (TreeNode childNodes in node.Nodes) {
                    ApplyFeature(childNodes, selectedFeature);
                }
            } else {
                componentNode.Property.Feature = selectedFeature;
            }
        }

        private void ChangeNodeColor(TreeNode node, bool toFullPath, Color color) {
            if (node != null) {
                node.ForeColor = color;
                if (toFullPath) {
                    TreeNode parent = node.Parent;
                    while (parent != null) {
                        parent.ForeColor = color;
                        parent = parent.Parent;
                    }
                }
            }
        }

        #region Add Files and Folder in Bulk
        private void AddFoldersFilesInPath(TreeNode node, string path) {
            if (Directory.Exists(path) && CanAddFolder_File(node)) {
                // add this directory to this tree node
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                TreeNode dirNode = new TreeNode(dirInfo.Name, sysilsSmall.IconIndex(dirInfo.FullName, true), sysilsSmall.IconIndex(dirInfo.FullName, true));
                dirNode.Tag = new ComponentNode(ComponentType.Folder, new ComponentProperty());
                AddNodeInUIThread(node, dirNode);// node.Nodes.Add(dirNode);
                addFilesFoldersThread.ReportProgress(1);
                FileInfo[] files = dirInfo.GetFiles();
                foreach (FileInfo file in files) {
                    TreeNode fileNode = new TreeNode(file.Name, sysilsSmall.IconIndex(file.FullName, true), sysilsSmall.IconIndex(file.FullName, true));
                    ComponentProperty property = new ComponentProperty();
                    property.Id = Common.GetId();
                    property.SourcePath = file.FullName;
                    fileNode.Tag = new ComponentNode(ComponentType.File, property);
                    AddNodeInUIThread(dirNode, fileNode);// dirNode.Nodes.Add(fileNode);
                    addFilesFoldersThread.ReportProgress(1);
                }

                string[] directories = Directory.GetDirectories(path);
                foreach (string directoryPath in directories) {
                    AddFoldersFilesInPath(dirNode, directoryPath);
                }
            } else if (File.Exists(path) && CanAddFolder_File(node)) {
                // add this file to node
                FileInfo file = new FileInfo(path);
                TreeNode fileNode = new TreeNode(file.Name, sysilsSmall.IconIndex(file.FullName, true), sysilsSmall.IconIndex(file.FullName, true));
                ComponentProperty property = new ComponentProperty();
                property.Id = Common.GetId();
                property.SourcePath = file.FullName;
                fileNode.Tag = new ComponentNode(ComponentType.File, property);
                AddNodeInUIThread(node, fileNode);// node.Nodes.Add(fileNode);
                addFilesFoldersThread.ReportProgress(1);
            }
        }

        private void AddNodeInUIThread(TreeNode destinationNode, TreeNode newNode) {
            if (InvokeRequired) {
                Invoke(new AddNewNodeDelegate(AddNodeInUIThread), destinationNode, newNode);
            } else {
                destinationNode.Nodes.Add(newNode);
            }
        }

        private void StartAddFilesFoldersThread(TreeNode node, string path) {
            if (addFilesFoldersThread.IsBusy == false) {
                pbAddComponents.Visible = true;
                pbAddComponents.Value = 0;
                addFilesFoldersThread.RunWorkerAsync(new object[] { node, path });
            } else {
                MessageBox.Show("Files cannot be added now as respective thread is busy", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void AddFilesFolders_Start(object sender, DoWorkEventArgs e) {
            TreeNode node = (TreeNode)((object[])e.Argument)[0];
            string path = (string)((object[])e.Argument)[1];
            AddFoldersFilesInPath(node, path);
        }

        void AddFilesFolders_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (pbAddComponents.Value == 1000) {
                pbAddComponents.Value = 0;
            }
            pbAddComponents.Increment(1);
        }

        void AddFilesFolders_Complete(object sender, RunWorkerCompletedEventArgs e) {
            pbAddComponents.Visible = false;
            CalculateFilesFoldersCount_Start();
        }

        private void CalculateFilesFoldersCount_Start() {
            if (InvokeRequired) {
                Invoke(new MethodInvoker(CalculateFilesFoldersCount_Start));
            } else {
                filesCount = FoldersCount = 0;
                foreach (TreeNode node in tvComponents.Nodes) {
                    CalculateFilesFoldersCount(node);
                }
                foreach (TreeNode node in tvSystemFolder.Nodes) {
                    CalculateFilesFoldersCount(node);
                }
                lblFiles.Text = filesCount.ToString();
                lblFolders.Text = FoldersCount.ToString();
            }
        }

        private void CalculateFilesFoldersCount(TreeNode node) {
            ComponentNode componentNode = (ComponentNode)node.Tag;
            if (componentNode.Type == ComponentType.Folder || componentNode.Type == ComponentType.RootFolder) {
                FoldersCount++;
            } else {
                filesCount++;
            }
            foreach (TreeNode childNode in node.Nodes) {
                CalculateFilesFoldersCount(childNode);
            }
        }
        #endregion

        #endregion

        private void Splitter_SizeChanged(object sender, EventArgs e) {
            SplitContainer container = (SplitContainer)sender;
            string distance = Profile.Get(container.Name);
            if (String.IsNullOrEmpty(distance) == false) {
                container.SplitterDistance = Int32.Parse(distance);
                profileLoaded = true;
            }
            container.SizeChanged -= new EventHandler(Splitter_SizeChanged);
        }
    }
}
