using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace NvnInstaller {
    [Serializable]
    public class ProductInformation {
        public string ProductCode = string.Empty;
        public string UpgradeCode = string.Empty;
        public string PackageId = string.Empty;
        public string ProductName = string.Empty;
        public string Title = string.Empty;
        public string Author = string.Empty;
        public string Version = string.Empty;
        public string Manufacturer = string.Empty;
        public string ManufacturerUrl = string.Empty;
        public string SupportUrl = string.Empty;
        public bool Is64Bit;
        public string Description = string.Empty;
        public string Comments = string.Empty;
        public string LicenseFile = string.Empty;
        public string OutputFile = string.Empty;
        public string AddRemoveIcon = string.Empty;
        public UIType UserInterfaceType = UIType.Mondo;
        public string BannerImage = string.Empty;
        public string DialogImage = string.Empty;
        public string Language = "English";
        public string MajorInstallerVersion = string.Empty;
        public string MinorInstallerVersion = string.Empty;
    }

    [Serializable]
    public class Extension {
        public string Id;
        public string extension;
        public string description;
        public string application;
        public object exeInfo;

        public Extension() {
            this.Id = Common.GetId();
        }
    }

    [Serializable]
    public class Summary {
        string title;
        DataTable data;
        bool collapse = true;

        public string Title {
            get { return title; }
            set { this.title = value; }
        }

        public DataTable Data {
            get { return data; }
            set { this.data = value; }
        }

        public bool Collapse {
            get { return collapse; }
            set { collapse = value; }
        }
    }

    public static class Profile {
        private static Dictionary<string, string> ProfileSettings = new Dictionary<string, string>();
        public static string ProfilePath;

        public static void Set(string key, string value) {
            if (ProfileSettings.ContainsKey(key)) {
                ProfileSettings[key] = value;
            } else {
                ProfileSettings.Add(key, value);
            }
        }

        public static string Get(string key) {
            if (ProfileSettings.ContainsKey(key)) {
                return ProfileSettings[key];
            }
            return string.Empty;
        }

        public static void Save() {
            if (File.Exists(ProfilePath) == false) {
                FileInfo fileInfo = new FileInfo(ProfilePath);
                if (Directory.Exists(fileInfo.Directory.FullName) == false) {
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                }
            }
            // create XML declaration
            XmlDocument doc = new XmlDocument();
            XmlNode declaration = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(declaration);
            XmlElement root = doc.CreateElement("Settings");
            doc.AppendChild(root);
            foreach (string name in ProfileSettings.Keys) {
                XmlElement settingElement = doc.CreateElement("Setting");

                XmlAttribute nameAttr = doc.CreateAttribute("name");
                nameAttr.Value = name;
                settingElement.Attributes.Append(nameAttr);

                XmlAttribute valueAttr = doc.CreateAttribute("value");
                valueAttr.Value = ProfileSettings[name];
                settingElement.Attributes.Append(valueAttr);

                root.AppendChild(settingElement);
            }
            // save xml file
            doc.Save(ProfilePath);
        }

        public static void Load() {
            if (File.Exists(ProfilePath)) {
                // load XML document
                XmlDocument document = new XmlDocument();
                document.Load(ProfilePath);

                // load forms
                XmlNodeList settingList = document.GetElementsByTagName("Setting");
                foreach (XmlNode setting in settingList) {
                    string name = setting.Attributes["name"].Value;
                    string value = setting.Attributes["value"].Value;
                    if (ProfileSettings.ContainsKey(name)) {
                        ProfileSettings[name] = value;
                    } else {
                        ProfileSettings.Add(name, value);
                    }
                }
            }
        }
    }

    public class RecentFiles {
        string recentFileName;
        private static List<string> files = new List<string>();
        private const int limit = 5;

        public RecentFiles(string recentFileName) {
            this.recentFileName = recentFileName;
        }

        public List<string> Files {
            get {
                return files;
            }
        }

        public void Append(string src) {
            if (!files.Contains(src)) {
                files.Add(src);
                if (files.Count == 11) {
                    files.RemoveAt(0);
                }
                this.Save();
            }
        }

        public void Save() {
            XmlDocument doc = new XmlDocument();
            XmlNode declaration = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(declaration);

            XmlElement root = doc.CreateElement("Files");
            doc.AppendChild(root);
            for (int i = 0; i < limit && i < files.Count; i++) {
                XmlElement fileElement = doc.CreateElement("File");
                XmlAttribute attribute = doc.CreateAttribute("src");
                attribute.Value = files[i];
                fileElement.Attributes.Append(attribute);
                root.AppendChild(fileElement);
            }
            if (File.Exists(recentFileName) == false) {
                FileInfo fileInfo = new FileInfo(recentFileName);
                if (Directory.Exists(fileInfo.Directory.FullName) == false) {
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                }
            }
            doc.Save(recentFileName);
        }

        public void Load() {
            files.Clear();
            if (File.Exists(recentFileName)) {
                XmlDocument document = new XmlDocument();
                document.Load(recentFileName);

                XmlNodeList filesList = document.GetElementsByTagName("File");
                foreach (XmlNode file in filesList) {
                    files.Add(file.Attributes["src"].Value);
                }
            }
        }
    }

    [Serializable]
    public class NameValue {
        private string name, value;
        public NameValue(string name, string value) {
            this.name = name;
            this.value = value;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Value {
            get { return value; }
            set { this.value = value; }
        }
    }
}
