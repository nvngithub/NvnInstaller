using System;
using System.Collections.Generic;
using System.Text;

namespace NvnInstaller {
    public enum ControlType {
        ProductInformation,
        Components,
        FileAssociation,
        UserInterface,
        Registries,
        CustomActions,
        Output,
        WixCodeEditor,
        EnvironmentVariables,
        Prerequisites,
        Property,
        BuildScheduler,
        CustomUIApplication
    }

    public enum SystemFolderType {
        AdminToolsFolder,
        AppDataFolder,
        CommonAppDataFolder,
        CommonFilesFolder,
        FontsFolder,
        LocalAppDataFolder,
        MyPicturesFolder,
        NetHoodFolder,
        PersonalFolder,
        PrintHoodFolder,
        StartupFolder,
        SystemFolder,
        TempFolder,
        TemplateFolder,
        WindowsFolder
    }

    public enum ComponentType {
        RootFolder,
        Folder,
        File,
        Service,
        Assembly,
        InternetShortcut
    }

    public enum LogType {
        Warning,
        ERROR,
        Information
    }

    public enum ShortcutType {
        StartMenu,
        Desktop
    }

    public enum RegistryAction {
        write,
        append,
        createKey,
        createKeyAndRemoveKeyOnUninstall,
        prepend,
        remove,
        removeKeyOnInstall,
        removeKeyOnUninstall
    }

    public enum ComponentsRootFolderType {
        Custom,
        Program_Custom,
        Program_Manufacturer_Product,
        Program_product
    }

    public enum CustomActionType {
        Dll,
        Exe,
        JScript,
        VBScript,
        ExeCommand
    }

    public enum CustomActionExecuteType {
        Installation,
        Uninstallation
    }

    public enum Return {
        asyncNoWait,
        asyncWait,
        check,
        ignore
    }

    public enum Execute {
        commit,
        deferred,
        firstSequence,
        immediate,
        oncePerProcess,
        rollback,
        secondSequence
    }

    public enum Script {
        jscript,
        vbscript
    }

    public enum PatchType {
        Unchanged,
        Deleted,
        Modified,
        New
    }

    public enum UIType {
        Mondo,
        FeatureTree,
        InstallDir,
        Minimal
    }

    public enum UserInterface {
        RegistrationDlg
    }

    // Unknown = 0,NoRoot = 1,Removable = 2,Localdisk = 3,Network = 4,CD = 5,RAMDrive = 6
    public enum SystemDrive {
        RemovableDrive = 2,
        DiskDrive = 3,
        NetworkDrive = 4,
        CDDrive = 5,
        FloppyDrive = 1000,// Dont know
    }

    public enum UIFontSize {
        Normal,
        Bigger,
        Title
    }

    public enum Modules {
        ProductInformation,
        Components,
        Registries,
        FileAssociation,
        CustomActions,
        ProductKeyValidation,
        Property,
        CustomUIApplication
    }

    public enum PropertySearchType {
        None,
        RegistrySearch,
        INISearch,
        DirectorySearch,
        FileSearch
    }

    public enum BuildTypes {
        Msi,
        Patch
    }
}
