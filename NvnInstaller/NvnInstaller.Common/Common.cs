using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace NvnInstaller {
    public static class Common {
        public static int MaxPropertyLength = 255;
        public static int MaxDescriptionLength = 255;
        public static string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            + Path.DirectorySeparatorChar + "NvnInstaller" + Path.DirectorySeparatorChar;
        public static string schedulePath = localFolder + "Schedules.xml";
        public static string localWixFolder = localFolder + "Wix";
        public static string licenseFile = localWixFolder + Path.DirectorySeparatorChar + "License.rtf";
        public static string applicationLogsDb = localFolder + "Logs.s3db";
        public static bool ReleaseMode = false;

        public static string BootstrapperPath = @"C:\Bootstrappers";
        public static string BootstrapTempLocation = localFolder + "Temp" + Path.DirectorySeparatorChar;

        //public static event EventHandler UpdateFeature;
        public static FeatureProperty DefaultFeature = new FeatureProperty();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)]string path, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder shortPath, int shortPathLength);

        public static TreeView Features = new TreeView();

        public static string GetId() {
            return "_" + Guid.NewGuid().ToString().Replace('-', '_');
        }

        public static bool IsInteger(string str) {
            int result = 0;
            if (String.IsNullOrEmpty(str)) {
                return false;
            }
            return Int32.TryParse(str, out result);
        }

        public static bool FeatureExists(string featureId) {
            foreach (TreeNode featureNode in Features.Nodes) {
                FeatureProperty feature = (FeatureProperty)featureNode.Tag;
                if (FeatureExists(featureId, featureNode)) {
                    return true;
                }
            }
            return false;
        }

        private static bool FeatureExists(string featureId, TreeNode featureNode) {
            FeatureProperty feature = (FeatureProperty)featureNode.Tag;
            if (feature.Id == featureId) {
                return true;
            }
            foreach (TreeNode childFeatureNode in featureNode.Nodes) {
                if (FeatureExists(featureId, childFeatureNode)) {
                    return true;
                }
            }
            return false;
        }

        public static List<NameValue> GetInstalledBootstrappersList() {
            //get bootstrapper path
            Common.BootstrapperPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Nvn Installer\\Bootstrappers";
            string packagesPath = Common.BootstrapperPath + Path.DirectorySeparatorChar + "Packages";

            List<NameValue> items = new List<NameValue>() { new NameValue("None", "None") };
            if (Directory.Exists(packagesPath)) {
                string[] bootstrapDirs = Directory.GetDirectories(packagesPath);
                foreach (string bootstrapDir in bootstrapDirs) {
                    string settingsFile = bootstrapDir + Path.DirectorySeparatorChar + "Settings.xml";
                    if (File.Exists(settingsFile)) {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(settingsFile);
                        XmlNodeList nodeList = doc.DocumentElement.GetElementsByTagName("DisplayName");
                        if (nodeList.Count > 0) {
                            items.Add(new NameValue(nodeList[0].InnerText, (new DirectoryInfo(bootstrapDir)).Name));
                        }
                    }
                }
            }
            return items;
        }

        public static object[] AddItemToArray(object[] array, object item) {
            if (array == null) {
                array = new object[1];
                array[0] = item;
            } else {
                object[] items = new object[array.Length];
                array.CopyTo(items, 0);
                array = new object[items.Length + 1];
                items.CopyTo(array, 0);
                array[items.Length] = item;
            }

            return array;
        }

        public static object[] AddItemToArray(object[] array, object[] itemArr) {
            if (array == null) {
                return itemArr;
            } else {
                object[] items = new object[array.Length];
                array.CopyTo(items, 0);
                array = new object[items.Length + itemArr.Length];
                items.CopyTo(array, 0);
                itemArr.CopyTo(array, array.Length - itemArr.Length);
            }
            return array;
        }

        public static object[] AddItemToArray(object[] array, List<object> itemList) {
            if (itemList.Count > 0) {
                object[] items = new object[array.Length];
                array.CopyTo(items, 0);
                array = new object[items.Length + itemList.Count];
                items.CopyTo(array, 0);

                for (int i = 0; i < itemList.Count; i++) {
                    object item = itemList[i];
                    array[items.Length + i] = item;
                }
            }
            return array;
        }

        public static string GetShortname(string longName) {
            string name = longName;
            if (name.Length > 8) {
                name = longName.Substring(0, 4).Replace(" ", "_") + "_" + (longName.Length - 4);
            } else if (name.Length == 8) {
                name = "_" + longName.Remove(0, 1);
            } else {
                name = "_" + longName;
            }
            return name;
        }
    }
}
