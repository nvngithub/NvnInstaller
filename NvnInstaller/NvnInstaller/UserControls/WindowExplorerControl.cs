using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Reflection;

namespace NvnInstaller
{
    public partial class WindowExplorerControl : UserControl
    {
        bool profileLoaded = false;
        private SysImageList sysilsSmall = new SysImageList(SysImageListSize.smallIcons);

        public WindowExplorerControl()
        {
            InitializeComponent();

            SysImageListHelper.SetTreeViewImageList(tvDirectories, sysilsSmall, false);
            SysImageListHelper.SetListViewImageList(lvFiles, sysilsSmall, false);
            Globals.ApplicationClosing += new EventHandler(Globals_ApplicationClosing);

            LoadWindowsControl();
        }

        void Globals_ApplicationClosing(object sender, EventArgs e)
        {
            if (profileLoaded)
            {
                Profile.Set(splitContainerWindowsControl.Name, splitContainerWindowsControl.SplitterDistance.ToString());
            }
        }

        private void WindowExplorerControl_Load(object sender, EventArgs e)
        {
            splitContainerWindowsControl.SizeChanged += new EventHandler(Splitter_SizeChanged);
        }

        private void LoadWindowsControl()
        {
            tvDirectories.Nodes.Clear();
            // create desktop node
            string desktopLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            TreeNode desktopNode = new TreeNode("Desktop", sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgDesktop, true), sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgDesktop, true, ShellIconStateConstants.ShellIconStateOpen));
            desktopNode.Tag = desktopLocation;
            tvDirectories.Nodes.Add(desktopNode);
            // create MyComputer Node under Desktop node
            TreeNode mycomputerNode = new TreeNode("MyComputer", sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgMyComputer, true), sysilsSmall.IconIndex(Globals.imagesFolder + Globals.imgMyComputer, true, ShellIconStateConstants.ShellIconStateOpen));
            desktopNode.Nodes.Add(mycomputerNode);
            // create drive nodes under MyComputer node
            QueryDiskDrives(mycomputerNode);
            // add folder nodes under Desktop node      
            DirectoryInfo[] dirs = (new DirectoryInfo(desktopLocation)).GetDirectories();
            foreach (DirectoryInfo dirInfo in dirs)
            {
                TreeNode[] tempNodes = new TreeNode[] { new TreeNode("temp") };// Temp node used to show +/- sign for every node
                TreeNode dirNode = new TreeNode(dirInfo.Name, sysilsSmall.IconIndex(dirInfo.FullName, true), sysilsSmall.IconIndex(dirInfo.FullName, true, ShellIconStateConstants.ShellIconStateOpen), tempNodes);
                dirNode.Tag = dirInfo.FullName;
                desktopNode.Nodes.Add(dirNode);
            }
            // update List view items
            UpdateListItems(desktopLocation);
            desktopNode.Expand();
        }

        private void QueryDiskDrives(TreeNode mycomputerNode)
        {
            foreach (SystemDrive drive in Enum.GetValues(typeof(SystemDrive)))
            {
                SelectQuery query = new SelectQuery("select * from win32_logicaldisk where drivetype=" + (int)drive);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    if ((mo["volumename"] != null || mo["name"] != null))
                    {
                        TreeNode[] tempNodes = new TreeNode[] { new TreeNode("temp") };
                        TreeNode node = new TreeNode((string)mo["name"] + (string)mo["volumename"], sysilsSmall.IconIndex((string)mo["name"] + "\\", true), sysilsSmall.IconIndex((string)mo["name"] + "\\", true, ShellIconStateConstants.ShellIconStateOpen), tempNodes);
                        node.Tag = (string)mo["name"] + "\\";
                        mycomputerNode.Nodes.Add(node);
                    }
                }
            }
        }

        private void tvDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.IsExpanded == false)
            {
                e.Node.Expand();
            }

            if (e.Node.Level > 0)
            {
                lvFiles.Items.Clear();
                string selectedDirPath = (string)e.Node.Tag;
                if (String.IsNullOrEmpty(selectedDirPath) == false)
                {// it should be NULL for MyComputer node
                    e.Node.Nodes.Clear();
                    try
                    {
                        DirectoryInfo[] directories = (new DirectoryInfo(selectedDirPath)).GetDirectories();
                        foreach (DirectoryInfo directory in directories)
                        {
                            TreeNode[] tempNodes = new TreeNode[] { new TreeNode("temp") };// Temp node used to show +/- sign for every node
                            TreeNode node = new TreeNode(directory.Name, sysilsSmall.IconIndex(directory.FullName, true), sysilsSmall.IconIndex(directory.FullName, true, ShellIconStateConstants.ShellIconStateOpen), tempNodes);
                            node.Tag = directory.FullName;
                            e.Node.Nodes.Add(node);
                        }
                        // add directories and files to Listview 
                        UpdateListItems((string)e.Node.Tag);
                    }
                    catch (UnauthorizedAccessException exc)
                    {
                        MessageBox.Show(exc.Message, "UnauthorizedAccess", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException exc)
                    {
                        MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tvDirectories_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            tvDirectories.SelectedNode = e.Node;
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            // get the corresponding treeNode and select it 
            if (lvFiles.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvFiles.SelectedItems[0];
                string text = selectedItem.SubItems[0].Text;
                foreach (TreeNode node in tvDirectories.SelectedNode.Nodes)
                {
                    if (node.Text == text)
                    {
                        tvDirectories.SelectedNode = node;
                        break;
                    }
                }
            }
        }

        private void UpdateListItems(string path)
        {
            if (Directory.Exists(path))
            {
                lvFiles.Items.Clear();
                try
                {
                    // fill directories
                    DirectoryInfo[] directories = (new DirectoryInfo(path)).GetDirectories();
                    foreach (DirectoryInfo directory in directories)
                    {
                        ListViewItem dirItem = new ListViewItem(directory.Name, sysilsSmall.IconIndex(directory.FullName, true));
                        lvFiles.Items.Add(dirItem);
                        dirItem.Tag = directory.FullName;
                    }
                    // fill files
                    FileInfo[] files = (new DirectoryInfo(path)).GetFiles();
                    foreach (FileInfo file in files)
                    {
                        ListViewItem fileItem = new ListViewItem(file.Name, sysilsSmall.IconIndex(file.FullName, true));
                        lvFiles.Items.Add(fileItem);
                        fileItem.Tag = file.FullName;
                        // set file details
                        fileItem.SubItems.Add(file.Length.ToString());
                        fileItem.SubItems.Add(file.CreationTime.ToString("dddd, dd MMMM yyyy"));
                        fileItem.SubItems.Add(file.LastWriteTime.ToString("dddd, dd MMMM yyyy"));
                    }
                }
                catch (UnauthorizedAccessException) { }
            }
            //Resize name column to fit names
            foreach (ColumnHeader header in lvFiles.Columns)
            {
                header.Width = -2;
            }
        }

        private void tvDirectories_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void tvDirectories_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lvFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(lvFiles.SelectedItems, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Splitter_SizeChanged(object sender, EventArgs e)
        {
            SplitContainer container = (SplitContainer)sender;
            string distance = Profile.Get(container.Name);
            if (String.IsNullOrEmpty(distance) == false)
            {
                container.SplitterDistance = Int32.Parse(distance);
                profileLoaded = true;
            }
            container.SizeChanged -= new EventHandler(Splitter_SizeChanged);
        }
    }
}