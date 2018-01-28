using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;

namespace NvnInstaller {
    partial class PropertyControl:INvnControl {
        void INvnControl.Open(Dictionary<string, object> objects) {
            Dictionary<string, WindowsProperty> properties = (Dictionary<string, WindowsProperty>)objects["Properties"];
            // create items in datagrid
            propertyItems.ClearItems();
            foreach (string id in properties.Keys) {
                WindowsProperty property = properties[id];
                propertyItems.AddNewItem(property);
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {            
            Dictionary<string, WindowsProperty> properties = new Dictionary<string, WindowsProperty>();
            foreach (WindowsProperty property in propertyItems.Items) {
                properties.Add(property.Id, property);
            }
            objects.Add("Properties", properties);
        }

        void INvnControl.Saving() { UpdateSelectedProperty(false); }

        void INvnControl.InitializeLoad() {
            propertyItems.ClearItems();
            txtPropertyName.Text = txtDefaultValue.Text = string.Empty;
        }

        void INvnControl.Load() { }

        void INvnControl.Close() { }

        ControlType INvnControl.Type {
            get { return ControlType.Property; }
        }

        List<Summary> INvnControl.GetSummary() {
            return null;
        }

        //1. duplicate values
        //2. using windows property (check this first)
        void INvnControl.Validate() {
            //foreach (WindowsProperty property in propertyItems.Items) {
            //    if (windowsProperties.Contains(property.Name)) {
            //        BuildLogMessage windowsPropertyUsed = new BuildLogMessage();
            //        windowsPropertyUsed.Message = "Windows property is used.";
            //        windowsPropertyUsed.Type = LogType.ERROR;
            //        windowsPropertyUsed.Module = Modules.Property;
            //        BuildLogger.Add(windowsPropertyUsed);
            //    }
            //}
        }

        void INvnControl.InitializeBuild() { UpdateSelectedProperty(false); }

        void INvnControl.Build() {
            foreach (WindowsProperty property in propertyItems.Items) {
                Wix.Property msiProperty = new Wix.Property();
                msiProperty.Id = property.Name;
                msiProperty.Value = property.DefaultValue;

                // PROPERTY SEARCH
                switch (property.SearchType) {
                    case PropertySearchType.DirectorySearch:
                        Wix.DirectorySearch wixDirSearch = new Wix.DirectorySearch();
                        wixDirSearch.Id = Common.GetId();
                        DirectorySearch dirSearch = (DirectorySearch)property.propSearch[PropertySearchType.DirectorySearch];
                        wixDirSearch.Path = dirSearch.DirectoryPath;
                        wixDirSearch.Depth = dirSearch.Depth;
                        msiProperty.DirectorySearch = new Wix.DirectorySearch[] { wixDirSearch };
                        break;
                    case PropertySearchType.FileSearch:
                        Wix.DirectorySearch wixFlDirSearch = new Wix.DirectorySearch();
                        wixFlDirSearch.Id = Common.GetId();
                        FileSearch flDirSearch = (FileSearch)property.propSearch[PropertySearchType.FileSearch];
                        wixFlDirSearch.Path = flDirSearch.DirectoryPath;
                        wixFlDirSearch.Depth = flDirSearch.Depth;
                        Wix.FileSearch wixFileSearch = new Wix.FileSearch();
                        wixFileSearch.Id = Common.GetId();
                        wixFileSearch.Name = flDirSearch.FileName;
                        wixFlDirSearch.Item = wixFileSearch;
                        msiProperty.DirectorySearch = new Wix.DirectorySearch[] { wixFlDirSearch };
                        break;
                    case PropertySearchType.INISearch:
                        Wix.IniFileSearch wixIniSearch = new Wix.IniFileSearch();
                        wixIniSearch.Id = Common.GetId();
                        INISearch iniSearch = (INISearch)property.propSearch[PropertySearchType.INISearch];
                        wixIniSearch.Name = iniSearch.Name;
                        wixIniSearch.Section = iniSearch.Section;
                        wixIniSearch.Key = iniSearch.Key;
                        msiProperty.IniFileSearch = new Wix.IniFileSearch[] { wixIniSearch };
                        break;
                    case PropertySearchType.None: break;
                    case PropertySearchType.RegistrySearch:
                        Wix.RegistrySearch wixRegSearch = new Wix.RegistrySearch();
                        wixRegSearch.Id = Common.GetId();
                        RegistrySearch regSearch = (RegistrySearch)property.propSearch[PropertySearchType.RegistrySearch];
                        wixRegSearch.Root = (Wix.RegistrySearchRoot)Enum.Parse(typeof(Wix.RegistrySearchRoot), regSearch.Root);
                        wixRegSearch.Key = regSearch.Key;
                        wixRegSearch.Name = regSearch.Name;
                        msiProperty.RegistrySearch = new Wix.RegistrySearch[] { wixRegSearch };
                        break;
                }

                if (MsiBuilder.PropertyElements.ContainsKey(msiProperty.Id)) {
                    MsiBuilder.PropertyElements[msiProperty.Id] = msiProperty;
                } else {
                    MsiBuilder.PropertyElements.Add(msiProperty.Id, msiProperty);
                }
            }
        }
    }

    [Serializable]
    public class WindowsProperty {
        public string Id = Common.GetId();
        public string Name = "NEW_PROPERTY";
        public string Description = "";
        public string DefaultValue = "";
        public PropertySearchType SearchType = PropertySearchType.None;
        public Dictionary<PropertySearchType, PropertySearch> propSearch = new Dictionary<PropertySearchType, PropertySearch>() 
        { { PropertySearchType.RegistrySearch, new RegistrySearch() }, { PropertySearchType.INISearch, new INISearch() }
            , { PropertySearchType.DirectorySearch, new DirectorySearch() }, { PropertySearchType.FileSearch, new FileSearch() } };

        public override string ToString() {
            return this.Name;
        }
    }

    [Serializable]
    public class PropertySearch { }

    [Serializable]
    public class RegistrySearch : PropertySearch {
        public string Root;
        public string RootText = "Root";
        public string Key;
        public string KeyText = "Key";
        public string Name;
        public string NameText = "Name";
    }

    [Serializable]
    public class INISearch : PropertySearch {
        public string Name;
        public string NameText = "Name";
        public string Section;
        public string SectionText = "Section";
        public string Key;
        public string KeyText = "Key";
    }

    [Serializable]
    public class DirectorySearch : PropertySearch {
        public string DirectoryPath;
        public string DirectoryPathText = "DirectoryPath";
        public string Depth;
        public string DepthText = "Depth";
    }

    [Serializable]
    public class FileSearch : PropertySearch {
        public string DirectoryPath;
        public string DirectoryPathText = "DirectoryPath";
        public string Depth;
        public string DepthText = "Depth";
        public string FileName;
        public string FileNameText = "FileName";
    }
}
