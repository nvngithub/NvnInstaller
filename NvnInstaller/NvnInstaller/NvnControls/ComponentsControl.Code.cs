using System;
using System.Collections.Generic;
using System.Text;
using Wix = NvnInstaller.WixClasses;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Xml.Serialization;
using System.Xml;

namespace NvnInstaller {
    partial class ComponentsControl : INvnControl {
        Wix.Directory menuDirectory;
        Wix.Directory desktopDirectory;

        #region ICommonControl Members

        void INvnControl.Open(Dictionary<string, object> objects) {
            if (objects.ContainsKey("ComponentsRootFolderType")) componentsRootFolderType = (ComponentsRootFolderType)objects["ComponentsRootFolderType"];
            Support.ArraylistToTreeview((ArrayList)objects[tvComponents.Name], tvComponents);
            Support.ArraylistToTreeview((ArrayList)objects[tvShortcuts.Name], tvShortcuts);
            Support.ArraylistToTreeview((ArrayList)objects[tvSystemFolder.Name], tvSystemFolder);
            // images of all files in the components tree
            if (tvComponents.Nodes.Count > 0) {
                foreach (TreeNode node in tvComponents.Nodes) {
                    SetFileImage(node);
                }
            }
            // images of all file shortcuts in shortcuts tree
            if (tvShortcuts.Nodes.Count > 0) {
                foreach (TreeNode node in tvShortcuts.Nodes) {
                    SetFileImage(node);
                }
            }
            // images of all file shortcuts in system folder tree
            if (tvSystemFolder.Nodes.Count > 0) {
                foreach (TreeNode node in tvSystemFolder.Nodes) {
                    SetFileImage(node);
                }
            }
            // Apply patch color to component nodes
            if (tvComponents.Nodes.Count > 0) {
                foreach (TreeNode node in tvComponents.Nodes) {
                    ApplyPatchNodeColor(node);
                }
            }
            // Apply patch color to system folder nodes
            if (tvSystemFolder.Nodes.Count > 0) {
                foreach (TreeNode node in tvSystemFolder.Nodes) {
                    ApplyPatchNodeColor(node);
                }
            }
        }

        void INvnControl.InitializeLoad() {
            tvComponents.Nodes.Clear();
            foreach (TreeNode systemFolderNode in tvSystemFolder.Nodes) {
                systemFolderNode.Nodes.Clear();
            }
            foreach (TreeNode shortcutNode in tvShortcuts.Nodes) {
                shortcutNode.Nodes.Clear();
            }
        }

        void INvnControl.Saving() {
        }

        private void SetFileImage(TreeNode node) {
            ComponentNode componentNode = (ComponentNode)node.Tag;
            if (componentNode != null) {
                if (componentNode.Type == ComponentType.File) {
                    node.ImageIndex = sysilsSmall.IconIndex(componentNode.Property.SourcePath, true);
                    node.SelectedImageIndex = sysilsSmall.IconIndex(componentNode.Property.SourcePath, true, ShellIconStateConstants.ShellIconStateOpen);
                } else if (componentNode.Type == ComponentType.Folder || componentNode.Type == ComponentType.RootFolder) {
                    node.ImageIndex = node.SelectedImageIndex = folderImageIndex;
                    foreach (TreeNode childNode in node.Nodes) {
                        SetFileImage(childNode);
                    }
                } else if (componentNode.Type == ComponentType.InternetShortcut) {
                    node.ImageIndex = node.SelectedImageIndex = sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgInternet, true);
                }
            }
        }

        private void ApplyPatchNodeColor(TreeNode node) {
            ComponentNode componentNode = (ComponentNode)node.Tag;
            if (componentNode != null) {
                if (componentNode.Type == ComponentType.File || componentNode.Type == ComponentType.Assembly || componentNode.Type == ComponentType.Service) {
                    if (String.IsNullOrEmpty(componentNode.Property.PatchFile) == false) {
                        ChangeNodeColor(node, true, Globals.PatchFileColor);
                    }
                } else if (componentNode.Type == ComponentType.Folder || componentNode.Type == ComponentType.RootFolder) {
                    foreach (TreeNode childNode in node.Nodes) {
                        ApplyPatchNodeColor(childNode);
                    }
                }
            }
        }

        void INvnControl.Close() {
            if (profileLoaded) {
                Profile.Set(splitContainerComponents.Name, splitContainerComponents.SplitterDistance.ToString());
                Profile.Set(splitContainerShortcuts.Name, splitContainerShortcuts.SplitterDistance.ToString());
                Profile.Set(splitContainerSystemFolders.Name, splitContainerSystemFolders.SplitterDistance.ToString());
            }
        }

        void INvnControl.Load() { }

        public ControlType Type {
            get {
                return ControlType.Components;
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            objects.Add(tvComponents.Name, Support.TreeviewToArraylist(tvComponents));
            objects.Add(tvShortcuts.Name, Support.TreeviewToArraylist(tvShortcuts));
            objects.Add(tvSystemFolder.Name, Support.TreeviewToArraylist(tvSystemFolder));
            objects.Add("ComponentsRootFolderType", componentsRootFolderType);
        }

        List<Summary> INvnControl.GetSummary() {
            List<Summary> summaries = new List<Summary>();
            // components
            if (tvComponents.Nodes.Count > 0) {
                //basic summary
                Summary componentsSummary = new Summary();
                componentsSummary.Title = "Components";
                DataTable componentsTable = new DataTable();
                componentsTable.Columns.Add("Property");
                componentsTable.Columns.Add("Value");
                int totalFolders = 0, totalFiles = 0, totalServices = 0, totalAssemblies = 0;
                long totalSize = 0; string size = string.Empty;
                GetComponentTotals(tvComponents.Nodes[0], ref totalSize, ref totalFolders, ref totalFiles, ref totalServices, ref totalAssemblies);
                GetComponentTotals(tvSystemFolder.Nodes[0], ref totalSize, ref totalFolders, ref totalFiles, ref totalServices, ref totalAssemblies);
                componentsTable.Rows.Add("Number of folders", totalFolders);
                componentsTable.Rows.Add("Number of files", totalFiles);
                componentsTable.Rows.Add("Number of services", totalServices);
                componentsTable.Rows.Add("Number of Assemblies", totalAssemblies);
                size = totalSize > 1024 ? (totalSize > (1024 * 1024) ? Convert.ToString(totalSize / (1024 * 1024)) + "MB" : Convert.ToString(totalSize / 1024) + "KB")
                    : Convert.ToString(totalSize);
                componentsTable.Rows.Add("Total size", size);
                componentsSummary.Data = componentsTable;
                summaries.Add(componentsSummary);
                // all files and their source
                Summary filesSummary = new Summary();
                filesSummary.Title = "Files";
                DataTable filesTable = new DataTable();
                filesTable.Columns.Add("Install Path");
                filesTable.Columns.Add("File Source Path");
                filesTable.Columns.Add("File Size");
                GetFilesSummary(tvComponents.Nodes[0], filesTable);
                filesSummary.Data = filesTable;
                summaries.Add(filesSummary);
            }
            foreach (TreeNode shortcutNode in tvShortcuts.Nodes) {
                if (shortcutNode.Nodes.Count > 0) {
                    if (shortcutNode.Text.Equals("Desktop", StringComparison.OrdinalIgnoreCase)) {
                        //desktop shortcuts
                        Summary desktopShortcutsSummary = new Summary();
                        desktopShortcutsSummary.Title = "Desktop Shortcuts";
                        DataTable desktopShortcutsTable = new DataTable();
                        desktopShortcutsTable.Columns.Add("Shortcut Path");
                        desktopShortcutsTable.Columns.Add("Installation Location");
                        desktopShortcutsTable.Columns.Add("File Source");
                        GetShortcutSummary(shortcutNode, desktopShortcutsTable);
                        desktopShortcutsSummary.Data = desktopShortcutsTable;
                        summaries.Add(desktopShortcutsSummary);
                    } else if (shortcutNode.Text.Equals("StartMenu->All Programs", StringComparison.OrdinalIgnoreCase)) {
                        //start menu shortcuts
                        Summary startMenuShortcutsSummary = new Summary();
                        startMenuShortcutsSummary.Title = "Start Menu Shortcuts";
                        DataTable startMenuShortcutsTable = new DataTable();
                        startMenuShortcutsTable.Columns.Add("Shortcut Path");
                        startMenuShortcutsTable.Columns.Add("Installation Location");
                        startMenuShortcutsTable.Columns.Add("File Source");
                        GetShortcutSummary(shortcutNode, startMenuShortcutsTable);
                        startMenuShortcutsSummary.Data = startMenuShortcutsTable;
                        summaries.Add(startMenuShortcutsSummary);
                    }
                }
            }
            // shortcuts
            if (summaries.Count > 0) {
                return summaries;
            }
            return null;
        }

        private void GetShortcutSummary(TreeNode shortcutNode, DataTable shortcutsTable) {
            foreach (TreeNode node in shortcutNode.Nodes) {
                ComponentNode componentNode = (ComponentNode)node.Tag;
                if (componentNode.Type == ComponentType.RootFolder || componentNode.Type == ComponentType.Folder) {
                    GetShortcutSummary(node, shortcutsTable);
                } else if (componentNode.Type == ComponentType.Service || componentNode.Type == ComponentType.File || componentNode.Type == ComponentType.Assembly) {
                    shortcutsTable.Rows.Add(node.FullPath, "", componentNode.Property.SourcePath);//TODO:Installation location of shortcut
                }
            }
        }

        private void GetFilesSummary(TreeNode parentNode, DataTable filesTable) {
            foreach (TreeNode node in parentNode.Nodes) {
                ComponentNode componentNode = (ComponentNode)node.Tag;
                if (componentNode.Type == ComponentType.RootFolder || componentNode.Type == ComponentType.Folder) {
                    GetFilesSummary(node, filesTable);
                } else if (componentNode.Type == ComponentType.Service || componentNode.Type == ComponentType.File || componentNode.Type == ComponentType.Assembly) {
                    FileInfo fileInfo = new FileInfo(componentNode.Property.SourcePath);
                    filesTable.Rows.Add(node.FullPath, componentNode.Property.SourcePath, fileInfo.Length);
                }
            }
        }

        private void GetComponentTotals(TreeNode parentNode, ref long totalSize, ref int totalFolders, ref int totalFiles, ref int totalServices, ref int totalAssemblies) {
            foreach (TreeNode node in parentNode.Nodes) {
                ComponentNode componentNode = (ComponentNode)node.Tag;
                if (componentNode.Type == ComponentType.RootFolder || componentNode.Type == ComponentType.Folder) {
                    totalFolders++;
                    GetComponentTotals(node, ref totalSize, ref totalFolders, ref totalFiles, ref totalServices, ref totalAssemblies);
                } else {
                    if (componentNode.Type == ComponentType.File) {
                        totalFiles++;
                    } else if (componentNode.Type == ComponentType.Service) {
                        totalServices++;
                    } else if (componentNode.Type == ComponentType.Assembly) {
                        totalAssemblies++;
                    }
                    FileInfo fileInfo = new FileInfo(componentNode.Property.SourcePath);
                    totalSize += fileInfo.Length;
                }
            }
        }

        void INvnControl.Validate() {
            List<BuildLogMessage> tempMessages = new List<BuildLogMessage>();
            tempMessages = Validator.ValidateTree(tvComponents, true, Modules.Components);
            BuildLogger.Add(tempMessages);
            tempMessages = Validator.ValidateTree(tvShortcuts, false, Modules.Components);
            BuildLogger.Add(tempMessages);
            tempMessages = Validator.ValidateTree(tvSystemFolder, false, Modules.Components);
            BuildLogger.Add(tempMessages);

            // check component exists for the shortcut node
            foreach (TreeNode rootNode in tvShortcuts.Nodes) {
                CheckComponentNodeExists(rootNode);
            }
        }

        private void CheckComponentNodeExists(TreeNode node) {
            if (node.Tag != null) /*Normally NULL for root nodes*/ {
                ComponentNode componentNode = (ComponentNode)node.Tag;
                if (componentNode.SecondaryTreeNode != null && componentNode.SecondaryTreeNode.TreeView == null) {
                    BuildLogMessage buildMessage = new BuildLogMessage();
                    buildMessage.Message = String.Format("Source file of shortcut file: {0} is not found in components tree. Please check whether the component tree structure is maintained.", node.FullPath);
                    buildMessage.Type = LogType.ERROR;
                    buildMessage.Module = Modules.Components;
                    BuildLogger.Add(buildMessage);
                }
            }
            foreach (TreeNode childNode in node.Nodes) {
                CheckComponentNodeExists(childNode);
            }
        }

        void INvnControl.InitializeBuild() { }

        void INvnControl.Build() {
            if (Common.Features.Nodes.Count > 0) {
                Wix.Directory targetDir = new Wix.Directory();
                MsiBuilder.TargetDirectory = targetDir;
                targetDir.Id = "TARGETDIR";
                targetDir.Name = "SourceDir";
                targetDir.Items = new Wix.Directory[3 + Enum.GetNames(typeof(SystemFolderType)).Length];// Program files, desktop shortcuts, start menu and all special folders

                // COMPONENTS DIRECTORY
                if (tvComponents.Nodes.Count > 0 && tvComponents.Nodes[0].Text != "") {
                    Wix.Directory pFilesDir = new Wix.Directory();
                    pFilesDir.Id = "ProgramFilesFolder";
                    pFilesDir.Name = "PFiles";
                    targetDir.Items[0] = pFilesDir;

                    pFilesDir.Items = new Wix.Directory[1];
                    TreeNode INSTALLDIR_Node = null;
                    Wix.Directory INSTALLDIR = null;
                    string directoryPath = @"$(env.ProgramFiles)\";
                    switch (componentsRootFolderType) {
                        case ComponentsRootFolderType.Program_product:
                            directoryPath += ControlsManager.ProductInformation.ProductName.Text;
                            INSTALLDIR_Node = tvComponents.Nodes[0].Nodes[0];
                            break;
                        case ComponentsRootFolderType.Program_Manufacturer_Product:
                            directoryPath += ControlsManager.ProductInformation.Manufacturer.Text
                                + "\\" + ControlsManager.ProductInformation.ProductName.Text;
                            INSTALLDIR_Node = tvComponents.Nodes[0].Nodes[0].Nodes[0];
                            break;
                        case ComponentsRootFolderType.Program_Custom:
                            directoryPath += tvComponents.Nodes[0].Nodes[0].Text;
                            INSTALLDIR_Node = tvComponents.Nodes[0].Nodes[0];
                            break;
                        case ComponentsRootFolderType.Custom:
                            directoryPath = tvComponents.Nodes[0].Text;
                            INSTALLDIR_Node = tvComponents.Nodes[0];
                            break;
                    }

                    Wix.Property propertyElement = new Wix.Property();
                    propertyElement.Id = "INSTALLDIR";
                    propertyElement.Text = new string[] { string.Format(@"<![CDATA[{0}]]>", directoryPath) };
                    MsiBuilder.PropertyElements.Add(propertyElement.Id, propertyElement);

                    Wix.Directory customDir = new Wix.Directory();
                    customDir.Id = "INSTALLDIR";
                    customDir.Name = ".";
                    pFilesDir.Items[0] = customDir;
                    INSTALLDIR = customDir;

                    MsiBuilder.InstallDirectory = INSTALLDIR;

                    // SYSTEM FOLDERS
                    BuildSystemFolders(targetDir);

                    // SHORTCUT FOLDERS
                    BuildShortcutFolders(targetDir);

                    // COMPONENTS DIRECTORY
                    BuildWixDirectory(INSTALLDIR, INSTALLDIR_Node, false);
                }
            }
        }

        private void BuildSystemFolders(Wix.Directory targetDir) {
            // create Wix directory for each system folder, add components to it
            for (int i = 0; i < tvSystemFolder.Nodes.Count; i++) {
                TreeNode systemFolder = tvSystemFolder.Nodes[i];
                Wix.Directory systemDirectory = new Wix.Directory();
                systemDirectory.Id = systemDirectory.LongName = systemFolder.Text;
                systemDirectory.Name = Common.GetShortname(systemFolder.Text);
                BuildWixDirectory(systemDirectory, systemFolder, false);

                targetDir.Items[3 + i] = systemDirectory;
            }
        }

        private void BuildShortcutFolders(Wix.Directory targetDir) {
            // create Wix directory for each system folder, add components to it
            for (int i = 0; i < tvShortcuts.Nodes.Count; i++) {
                TreeNode shortcutFolder = tvShortcuts.Nodes[i];
                Wix.Directory shortcutDirectory = new Wix.Directory();
                shortcutDirectory.Id = shortcutDirectory.LongName = (shortcutFolder.Text == "StartMenu->All Programs" || shortcutFolder.Text=="StartMenu") ? "ProgramMenuFolder" : "DesktopFolder";
                if (shortcutDirectory.Id == "ProgramMenuFolder") {
                    this.menuDirectory = shortcutDirectory;
                } else if (shortcutDirectory.Id == "DesktopFolder") {
                    this.desktopDirectory = shortcutDirectory;
                }
                shortcutDirectory.Name = Common.GetShortname(shortcutDirectory.LongName);
                BuildWixDirectory(shortcutDirectory, shortcutFolder, true);

                targetDir.Items[3 + i] = shortcutDirectory;
            }
        }

        private void BuildWixDirectory(Wix.Directory rootDir, TreeNode treeNode, bool isShortcutDir) {
            rootDir.Items = new object[treeNode.Nodes.Count];
            for (int i = 0; i < treeNode.Nodes.Count; i++) {
                TreeNode node = treeNode.Nodes[i];
                ComponentNode componentNode = (ComponentNode)node.Tag;

                #region Folder
                if (componentNode.Type == ComponentType.Folder) {
                    // create Wix directory
                    Wix.Directory dir = new Wix.Directory();
                    dir.Id = Common.GetId();
                    dir.Name = Common.GetShortname(node.Text);
                    componentNode.Property.WixNode = dir;
                    if (dir.Name != node.Text) {
                        dir.LongName = node.Text;
                    }
                    // add directory to parent directory
                    rootDir.Items[i] = dir;
                    // loop again
                    BuildWixDirectory(dir, node, isShortcutDir);
                }
                #endregion

                #region File
 else if (isShortcutDir == false && componentNode.Type == ComponentType.File) {
                    // add component
                    Wix.Component component = new Wix.Component();
                    component.Id = Common.GetId();
                    component.Guid = Guid.NewGuid().ToString();
                    componentNode.Property.WixNode = component;
                    // create file node
                    Wix.File file = new Wix.File();
                    file.Id = componentNode.Property.Id;
                    file.Name = Common.GetShortname(node.Text);
                    if (file.Name != node.Text) {
                        file.LongName = node.Text;
                    }
                    file.DiskId = "1"; // Only one disk supported
                    file.Source = componentNode.Property.SourcePath;
                    file.KeyPathSpecified = true;
                    file.KeyPath = Wix.YesNoType.yes;
                    file.VitalSpecified = true;
                    file.Vital = componentNode.Property.Vital;
                    // add file to component
                    component.Items = new Wix.File[1];
                    component.Items[0] = file;

                    file.Items = new object[2];
                    if (node.TreeView == tvComponents) {
                        // look in Start Menu
                        SetShortcuts(file, node, tvShortcuts.Nodes[0], this.menuDirectory, ShortcutType.StartMenu);
                        // look in Desktop
                        SetShortcuts(file, node, tvShortcuts.Nodes[1], this.desktopDirectory, ShortcutType.Desktop);
                    }
                    // Set component ref in FeatureNode
                    Support.SetComponentRef(component, componentNode.Property.Feature);
                    // add component to Directory node
                    rootDir.Items[i] = component;
                }
                #endregion

                #region Assembly
 else if (isShortcutDir == false && componentNode.Type == ComponentType.Assembly) {
                    // add component
                    Wix.Component component = new Wix.Component();
                    component.Id = Common.GetId();
                    component.Guid = Guid.NewGuid().ToString();
                    componentNode.Property.WixNode = component;
                    // create file node
                    Wix.File file = new Wix.File();
                    file.Id = componentNode.Property.Id;
                    FileInfo fileInfo = new FileInfo(componentNode.Property.SourcePath);
                    string assemblyName = node.Text.Remove(0, 10).Replace(']', ' ').Trim();
                    file.Name = Common.GetShortname(assemblyName);
                    if (file.Name != assemblyName) {
                        file.LongName = assemblyName;
                    }
                    //Install assembly to GAC
                    file.AssemblySpecified = true;
                    file.Assembly = Wix.FileAssembly.net;
                    file.DiskId = "1"; // Only one disk supported
                    file.Source = componentNode.Property.SourcePath;
                    file.KeyPathSpecified = true;
                    file.KeyPath = Wix.YesNoType.yes;
                    file.VitalSpecified = true;
                    file.Vital = componentNode.Property.Vital;
                    // add file to component
                    component.Items = new Wix.File[1];
                    component.Items[0] = file;

                    file.Items = new object[2];
                    if (node.TreeView == tvComponents) {
                        // look in Start Menu
                        SetShortcuts(file, node, tvShortcuts.Nodes[0], this.menuDirectory, ShortcutType.StartMenu);
                        // look in Desktop
                        SetShortcuts(file, node, tvShortcuts.Nodes[1], this.desktopDirectory, ShortcutType.Desktop);
                    }
                    // Set component ref in FeatureNode
                    Support.SetComponentRef(component, componentNode.Property.Feature);
                    // add component to Directory node
                    rootDir.Items[i] = component;
                }
                #endregion

                #region Service
 else if (isShortcutDir == false && componentNode.Type == ComponentType.Service) {
                    // create component object
                    Wix.Component component = new Wix.Component();
                    component.Id = Common.GetId();
                    component.Guid = Guid.NewGuid().ToString();
                    componentNode.Property.WixNode = component;

                    component.Items = new object[3];
                    // Create File Node
                    Wix.File file = new Wix.File();
                    file.Id = componentNode.Property.Id;
                    file.Name = Common.GetShortname(node.Text);
                    if (file.Name != node.Text) {
                        file.LongName = node.Text;
                    }
                    file.Source = componentNode.Property.SourcePath;
                    file.DiskId = "1"; // Only one disk supported
                    file.KeyPathSpecified = true;
                    file.KeyPath = Wix.YesNoType.yes;
                    // add file to component
                    component.Items[0] = file;
                    // create ServiceInstall node
                    Wix.ServiceInstall serviceInstall = new Wix.ServiceInstall();
                    serviceInstall.Id = Common.GetId();
                    serviceInstall.Name = componentNode.Property.ServiceProperty.Name == null ? node.Text : componentNode.Property.ServiceProperty.Name;
                    serviceInstall.DisplayName = componentNode.Property.ServiceProperty.DisplayName == null ? node.Text : componentNode.Property.ServiceProperty.DisplayName;
                    serviceInstall.Type = componentNode.Property.ServiceProperty.InstallType;
                    serviceInstall.Start = componentNode.Property.ServiceProperty.InstallStart;
                    serviceInstall.ErrorControl = componentNode.Property.ServiceProperty.InstallErrorControl;
                    // add serviceInstall node to component node
                    component.Items[1] = serviceInstall;

                    // Create Service Control Nodes
                    Wix.ServiceControl serviceControl = new Wix.ServiceControl();
                    serviceControl.Id = Common.GetId();
                    serviceControl.Name = componentNode.Property.ServiceProperty.Name == null ? node.Text : componentNode.Property.ServiceProperty.Name;
                    serviceControl.StartSpecified = true;
                    serviceControl.Start = Wix.ServiceControlStart.install;
                    serviceControl.StopSpecified = true;
                    serviceControl.Stop = Wix.ServiceControlStop.uninstall;
                    serviceControl.RemoveSpecified = true;
                    serviceControl.Remove = Wix.ServiceControlRemove.uninstall;
                    // add to component node
                    component.Items[2] = serviceControl;
                    // Set component ref in FeatureNode
                    Support.SetComponentRef(component, componentNode.Property.Feature);
                    // add component to Directory node
                    rootDir.Items[i] = component;
                }
                #endregion

                #region Internet Shortcut
 else if (componentNode.Type == ComponentType.InternetShortcut) {
                    /* Create file *.url in local folder with content like below
                     * [InternetShortcut]
                     * URL=http://www.google.com */
                    InternetShortcutProperty shortcutProperty = componentNode.Property.ShortcutProperty;
                    string urlFile = Globals.localFolder + node.Text + ".url";
                    using (TextWriter writer = new StreamWriter(urlFile)) {
                        writer.WriteLine("[InternetShortcut]");
                        writer.WriteLine("URL=" + shortcutProperty.URL);
                    }
                    // create component node in the respective shortcut directory
                    // add component
                    Wix.Component component = new Wix.Component();
                    component.Id = Common.GetId();
                    component.Guid = Guid.NewGuid().ToString();

                    // create file node
                    Wix.File file = new Wix.File();
                    file.Id = Common.GetId();
                    file.Name = Common.GetShortname(node.Text);
                    if (file.Name != node.Text) {
                        file.LongName = node.Text + ".url";
                    }
                    file.DiskId = "1"; // Only one disk supported
                    file.Source = urlFile;
                    file.KeyPathSpecified = true;
                    file.KeyPath = Wix.YesNoType.yes;
                    file.VitalSpecified = true;
                    file.Vital = NvnInstaller.WixClasses.YesNoType.yes;
                    // add file to component
                    component.Items = new Wix.File[1];
                    component.Items[0] = file;

                    // Set component ref in FeatureNode
                    Support.SetComponentRef(component, shortcutProperty.Feature);
                    // add component to Directory node
                    rootDir.Items[i] = component;
                }
                #endregion
            }
        }

        private void SetShortcuts(Wix.File file, TreeNode cmpNode, TreeNode treeNode, Wix.Directory directory, ShortcutType type) {
            foreach (TreeNode shortcutNode in treeNode.Nodes) {
                ComponentNode componentNode = (ComponentNode)shortcutNode.Tag;
                if (componentNode.Type == ComponentType.Folder) {
                    SetShortcuts(file, cmpNode, shortcutNode, (Wix.Directory)componentNode.Property.WixNode, type);
                } else if (componentNode.Type == ComponentType.File) {
                    if (componentNode.Property == ((ComponentNode)cmpNode.Tag).Property) {
                        Wix.Shortcut shortcut = new Wix.Shortcut();
                        shortcut.Id = Common.GetId();
                        shortcut.Directory = directory.Id;
                        if (type == ShortcutType.Desktop) {
                            file.Items[1] = shortcut;
                        } else if (type == ShortcutType.StartMenu) {
                            file.Items[0] = shortcut;
                        }
                        shortcut.Name = Common.GetShortname(shortcutNode.Text);
                        if (shortcut.Name != shortcutNode.Text) {
                            shortcut.LongName = shortcutNode.Text;
                        }
                        shortcut.WorkingDirectory = "INSTALLDIR";
                        //shortcut.Icon = new NvnInstaller.WixClasses.Icon(
                        shortcut.IconIndex = "0";
                    }
                }
            }
        }

        public TreeNode SelectTreeNode() {
            // serialize tvComponents
            SerializeComponentsTree();
            ComponentsForm componentsForm = new ComponentsForm();// tvCompnents is loaded here
            if (componentsForm.ShowDialog() == DialogResult.OK) {
                return componentsForm.SelectedComponentNode;
            }
            return null;
        }

        public byte[] SerializeComponentsTree() {
            // Serialize TREE
            ArrayList al = new ArrayList();
            TreeView tree = (TreeView)tvComponents;
            foreach (TreeNode tn in tree.Nodes) {
                al.Add(tn);
            }
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, al);
            return ms.GetBuffer();
        }

        #endregion
    }
}
