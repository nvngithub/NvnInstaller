using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace NvnInstaller {
    static class Globals {
        static Version ver = Assembly.GetExecutingAssembly().GetName().Version;
        public static string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            + Path.DirectorySeparatorChar + Assembly.GetExecutingAssembly().GetName().Name + Path.DirectorySeparatorChar;
        public static string exePath = (new FileInfo(Assembly.GetExecutingAssembly().FullName)).Directory.FullName;
        public static string applicationFolder = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
        public static string applicationName = "Nvn Installer";
        public static string originalWixFolder = applicationFolder + "wix";
        public static string objectFile = localFolder + "ObjectFile.wxs";
        public static string wixFile = localFolder + "wix.wxs";
        public static string profilePath = localFolder + "Profile.xml";
        public static string recentFileName = localFolder + "RecentFiles.xml";
        public static string productInformationFile = localFolder + "GeneralInformation.xml";
        public static string settingsPath = applicationFolder + "Settings.xml";
        public static string patchApplication = "NvnInstaller.PatchMaker.exe";
        public static string wixLibFiles = localFolder + Path.DirectorySeparatorChar + "WixFiles.txt";
        public static string productKeyFile = localFolder + "license.txt";
        //public static string licenseFile = applicationFolder + @"Licenses\Nvn Installer.txt";
        public static string samplesFolder = applicationFolder + "Samples";
        public static string imagesFolder = applicationFolder + "Images" + Path.DirectorySeparatorChar;
        public static bool registered = true;
        public static bool sfxEnabled = false;

        public static List<string> WantedFiles = new List<string>() { "license.txt", "Logs.s3db", "Profile.xml", "RecentFiles.xml", "WixFiles.txt", "Schedules.xml" };

        //command options.. override information in Product Informatio tab
        public static string outFile = string.Empty;
        public static bool isByCommand = false;
        public static bool closeAfterBuild = false;
        public static string version = ver.Major + "." + ver.Minor + (ver.Build == 0 ? "" : "." + ver.Build);
        public static string applicationCategory = "";

        public const string imgDesktop = "Desktop.scf";
        public const string imgError = "Error.scf";
        public const string imgHelp = "Help.scf";
        public const string imgInformation = "Information.scf";
        public const string imgInternet = "Internet.scf";
        public const string imgMyComputer = "MyComputer.scf";
        public const string imgNew = "New.scf";
        public const string imgNvnInstaller_48 = "NvnInstaller-48.bmp";
        public const string imgNvnInstallerIcon = "NvnInstaller.ico";
        public const string imgOpen = "Open.scf";
        public const string imgSave = "Save.scf";
        public const string imgService = "Service.scf";
        public const string imgWarning = "Warning.scf";

        public static Color PatchFileColor = Color.Red;

        public static event EventHandler<KeyEventArgs> KeyDown;
        public static event EventHandler ApplicationClosing;
        public static event EventHandler<BuildProgressEventArgs> BuildProgressChanged;
        public static event EventHandler SelectedPrerequisiteChanged;

        static Globals() {
            if (Directory.Exists(localFolder) == false) {
                Directory.CreateDirectory(localFolder);
            }

            objectFile = localFolder + Common.GetId();
            wixFile = localFolder + Common.GetId();
        }

        public static void NotifyKeyDown(object sender, KeyEventArgs e) {
            if (KeyDown != null) {
                KeyDown(sender, e);
            }
        }

        public static void NotifyApplicationClosing() {
            if (ApplicationClosing != null) {
                ApplicationClosing(null, null);
            }
        }

        public static void NotifyBuildProgress(int progressIncrement, string message) {
            if (BuildProgressChanged != null) {
                BuildProgressChanged(null, new BuildProgressEventArgs(progressIncrement, message));
            }
        }

        public static void NotifySelectedPrerequisiteChanged(int index) {
            if (SelectedPrerequisiteChanged != null) {
                SelectedPrerequisiteChanged(index, null);
            }
        }
    }
}