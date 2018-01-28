using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.IO;

namespace NvnInstaller {
    class Support {
        public static ArrayList TreeviewToArraylist(TreeView treeview) {
            ArrayList list = new ArrayList();
            foreach (TreeNode node in treeview.Nodes) {
                list.Add(node);
            }
            return list;
        }

        public static void ArraylistToTreeview(ArrayList list, TreeView treeview) {
            treeview.Nodes.Clear();
            foreach (TreeNode node in list) {
                treeview.Nodes.Add(node);
            }
        }

        public static void SetComponentRef(Wix.Component component, FeatureProperty componentFeature) {
            // Define component Ref
            Wix.ComponentRef componentRef = new Wix.ComponentRef();
            componentRef.Id = component.Id;
            // get the proper property... i,e defualt if feature is not assigned or assifned feature
            WixClasses.Feature applicableFeature = null;
            if (componentFeature == null) {
                // use default feature
                applicableFeature = MsiBuilder.FeatureTable[Common.DefaultFeature.Id];
            } else {
                applicableFeature = MsiBuilder.FeatureTable[componentFeature.Id];
            }
            // create ComponentRef node 
            if (applicableFeature != null) {
                // Add new component Ref to feature node
                applicableFeature.Items = Common.AddItemToArray(applicableFeature.Items, componentRef);
            }
        }

        public static void RunSanityCheck() {
            // Delete all unwanted files
            FileInfo[] files = (new DirectoryInfo(Globals.localFolder)).GetFiles();
            foreach (FileInfo file in files) {
                if (Globals.WantedFiles.Contains(file.Name) == false) {
                    file.Delete();
                }
            }

            // Delete all directories except Wix
            string[] dirs = Directory.GetDirectories(Globals.localFolder);
            foreach (string dir in dirs) {
                if (dir.EndsWith("Wix", StringComparison.OrdinalIgnoreCase) == false) Directory.Delete(dir, true);
            }

            bool copyFiles = false;
            if (File.Exists(Globals.wixLibFiles)) {
                if (new FileInfo(Globals.wixLibFiles).Length < 100) {
                    copyFiles = true;
                } else {
                    using (TextReader reader = new StreamReader(Globals.wixLibFiles)) {
                        string filePath = string.Empty;
                        while ((filePath = reader.ReadLine()) != null) {
                            if (File.Exists(filePath) == false) {
                                copyFiles = true;
                                break;
                            }
                        }
                    }
                }
            } else {
                File.Create(Globals.wixLibFiles).Close();
                copyFiles = true;
            }
            if (copyFiles) {
                // copy wix files from Program Files folder(at bin location)
                using (TextWriter writer = new StreamWriter(Globals.wixLibFiles)) {
                    CopyWixFolder(Globals.originalWixFolder, Common.localWixFolder, writer);
                }
            }
        }

        private static void CopyWixFolder(string sourceFolder, string destFolder, TextWriter writer) {
            if (Directory.Exists(sourceFolder)) {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files) {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest, true);
                    writer.WriteLine(dest);
                }
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders) {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyWixFolder(folder, dest, writer);
                }
            }
        }
    }
}
