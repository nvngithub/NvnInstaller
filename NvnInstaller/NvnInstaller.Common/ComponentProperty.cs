using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Wix = NvnInstaller.WixClasses;
using System.Windows.Forms;

namespace NvnInstaller {
    [Serializable]
    public class ComponentProperty {
        private string id;
        private bool hidden;
        private bool readOnly;
        private string sourcePath;
        private string patchFile;
        private bool system;        
        private Wix.YesNoType vital;
        //TODO: add new properties 
        // File: Ex: Checksum='no' Compressed='yes'
        // Component: SharedDllRefCount='no' KeyPath='no' NeverOverwrite='no' Permanent='no' Transitive='no' Win64='no' Location='either'
        private object wixNode;
        private FeatureProperty feature;
        private ServiceProperty serviceProperty = new ServiceProperty();
        private InternetShortcutProperty shortcutProperty = new InternetShortcutProperty();

        [Category("Component Property")]
        public string Id {
            get { return id; }
            set { id = value; }
        }

        [Description("Specifies whether to install a file as hidden file.")]
        [Category("Component Property")]
        public bool Hidden {
            get { return this.hidden; }
            set { this.hidden = value; }
        }

        [Description("Specifies whether to install a selected file as a read-only file.")]
        [Category("Component Property")]
        public bool ReadOnly {
            get { return this.readOnly; }
            set { this.readOnly = value; }
        }

        [Description("Displays the path to a selected file on the development computer.")]
        [Category("Component Property")]
        [ReadOnly(true)]
        public string SourcePath {
            get { return this.sourcePath; }
            set { this.sourcePath = value; }
        }

        [Description("Displays the path to the patch file on the development computer.")]
        [Category("Component Property")]
        public string PatchFile {
            get { return this.patchFile; }
            set { this.patchFile = value; }
        }

        [Description("Specifies whether to install a selected file as a system file.")]
        [Category("Component Property")]
        public bool System {
            get { return this.system; }
            set { this.system = value; }
        }

        [Description("Specifies whether a selected file is vital for installation.")]
        [Category("Component Property")]
        public Wix.YesNoType Vital {
            get { return this.vital; }
            set { this.vital = value; }
        }

        [EditorAttribute(typeof(FeatureEditor), typeof(UITypeEditor))]
        [Description("Features are separated parts of the application that we offer the user to decide whether to install or not.")]
        [Category("Component Property")]
        public FeatureProperty Feature {
            get { return this.feature; }
            set { this.feature = value; }
        }

        [Browsable(false)]
        public object WixNode {
            get { return wixNode; }
            set { wixNode = value; }
        }

        [Browsable(false)]
        public ServiceProperty ServiceProperty {
            get { return serviceProperty; }
            set { serviceProperty = value; }
        }

        [Browsable(false)]
        public InternetShortcutProperty ShortcutProperty {
            get { return shortcutProperty; }
            set { shortcutProperty = value; }
        }
    }

    [Serializable]
    public class ServiceProperty {
        // service properties
        string name;
        string displayName;
        string feature;
        //Wix.YesNoType keyPath;        
        Wix.ServiceInstallStart installStart = Wix.ServiceInstallStart.auto;
        Wix.ServiceInstallType installType = Wix.ServiceInstallType.ownProcess;
        Wix.ServiceInstallErrorControl installErrorControl = Wix.ServiceInstallErrorControl.normal;
        private Wix.YesNoType vital;
        //string description;
        //string username;
        //string password;
        // start service control property
        //Wix.ServiceControlStart serviceStart;
        //Wix.YesNoType waitStart;
        //// stop service control property
        //Wix.ServiceControlStop serviceStop;
        //Wix.YesNoType waitStop;

        [Category("Service property")]
        [Description("TODO: set description here")]
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        [Category("Service property")]
        [Description("TODO: set description here")]
        public string DisplayName {
            get {
                return displayName;
            }
            set {
                displayName = value;
            }
        }

        [Category("Service property")]
        [Description("TODO: set description here")]
        public string Feature {
            get {
                return feature;
            }
            set {
                feature = value;
            }
        }

        //[Category("Service property")]
        //[Description("TODO: set description here")]
        //public Wix.YesNoType KeyPath
        //{
        //    get
        //    {
        //        return keyPath;
        //    }
        //    set
        //    {
        //        keyPath = value;
        //    }
        //}

        [Category("Service property")]
        [Description("TODO: set description here")]
        public Wix.ServiceInstallType InstallType {
            get {
                return installType;
            }
            set {
                installType = value;
            }
        }

        [Category("Service property")]
        [Description("TODO: set description here")]
        public Wix.ServiceInstallStart InstallStart {
            get {
                return installStart;
            }
            set {
                installStart = value;
            }
        }

        [Category("Service property")]
        [Description("TODO: set description here")]
        public Wix.ServiceInstallErrorControl InstallErrorControl {
            get {
                return installErrorControl;
            }
            set {
                installErrorControl = value;
            }
        }

        [Category("Service property")]
        [Description("Specifies whether a selected service is vital for installation.")]
        public Wix.YesNoType Vital {
            get { return this.vital; }
            set { this.vital = value; }
        }

        //[Category("Service property")]
        //[Description("TODO: set description here")]
        //public string Description
        //{
        //    get
        //    {
        //        return description;
        //    }
        //    set
        //    {
        //        description = value;
        //    }
        //}

        //[Category("Service property")]
        //[Description("TODO: set description here")]
        //public string UserName
        //{
        //    get
        //    {
        //        return username;
        //    }
        //    set
        //    {
        //        username = value;
        //    }
        //}

        //[Category("Service property")]
        //[PasswordPropertyText]
        //[Description("TODO: set description here")]
        //public string Password
        //{
        //    get
        //    {
        //        return password;
        //    }
        //    set
        //    {
        //        password = value;
        //    }
        //}

        //[Category("Service start property")]
        //[Description("TODO: set description here")]
        //public Wix.ServiceControlStart ServiceStart
        //{
        //    get
        //    {
        //        return serviceStart;
        //    }
        //    set
        //    {
        //        serviceStart = value;
        //    }
        //}

        //[Category("Service start property")]
        //[Description("TODO: set description here")]
        //public Wix.YesNoType WaitStart
        //{
        //    get
        //    {
        //        return waitStart;
        //    }
        //    set
        //    {
        //        waitStart = value;
        //    }
        //}

        //[Category("Service stop property")]
        //[Description("TODO: set description here")]
        //public Wix.ServiceControlStop ServiceStop
        //{
        //    get
        //    {
        //        return serviceStop;
        //    }
        //    set
        //    {
        //        serviceStop = value;
        //    }
        //}

        //[Category("Service stop property")]
        //[Description("TODO: set description here")]
        //public Wix.YesNoType WaitStop
        //{
        //    get
        //    {
        //        return waitStop;
        //    }
        //    set
        //    {
        //        waitStop = value;
        //    }
        //}
    }

    [Serializable]
    public class InternetShortcutProperty {
        string url;
        FeatureProperty feature;

        [Description("Specify the URL to open in the web browser.")]
        [Category("Web address")]
        public string URL {
            get { return this.url; }
            set { this.url = value; }
        }

        [EditorAttribute(typeof(FeatureEditor), typeof(UITypeEditor))]
        [Description("Features are separated parts of the application that we offer the user to decide whether to install or not.")]
        public FeatureProperty Feature {
            get { return this.feature; }
            set { this.feature = value; }
        }
    }

    [Serializable]
    public class ComponentNode {
        ComponentType type;
        object tag;
        ComponentProperty property;
        TreeNode secondaryTreeNode;

        public ComponentNode() {
        }

        public ComponentNode(ComponentType type, ComponentProperty property) {
            this.type = type;
            this.property = property;
        }

        public ComponentType Type {
            get { return type; }
            set { type = value; }
        }

        public Object Tag {
            get { return tag; }
            set { tag = value; }
        }

        public TreeNode SecondaryTreeNode {
            get { return secondaryTreeNode; }
            set { secondaryTreeNode = value; }
        }

        public ComponentProperty Property {
            get { return property; }
            set { property = value; }
        }
    }

    [Serializable]
    public class FeatureProperty {
        string id;
        string description;
        string name;
        bool isDefault;

        [Browsable(false)]
        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string Description {
            get {
                return description;
            }
            set {
                description = value;
            }
        }

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public bool IsDefault {
            get {
                return isDefault;
            }
            set {
                isDefault = value;
            }
        }

        public override string ToString() {
            return this.name;
        }
    }

    public class FeatureChangeEventArgs : EventArgs {
        string oldName;
        string newName;

        public string OldName {
            get {
                return oldName;
            }
            set {
                oldName = value;
            }
        }

        public string NewName {
            get {
                return newName;
            }
            set {
                newName = value;
            }
        }

        public FeatureChangeEventArgs(string oldName, string newName) {
            this.oldName = oldName;
            this.newName = newName;
        }
    }
}
