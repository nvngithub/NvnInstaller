//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;
//using System.Xml;
//using System.Diagnostics;

//namespace NvnInstaller
//{
//    public class UICompiler
//    {
//        /// <summary> update MSI property of validation success and failure </summary>
//        public static void UpdatePIDInfo(string propertyName, string trueValue, string falseValue)
//        {
//            string registrationDlgFile = Common.wixUIFolder + Path.DirectorySeparatorChar + "RegistrationDlg.wxs";
//            XmlDocument doc = new XmlDocument();
//            doc.Load(registrationDlgFile);
//            XmlNodeList controls = doc.GetElementsByTagName("Control");//CHECK: GetElementById does not work
//            XmlNode nextControl = null;
//            foreach (XmlNode control in controls)
//            {
//                if (control.Attributes["Id"].Value == "Next")
//                {
//                    nextControl = control;
//                    break;
//                }
//            }
//            foreach (XmlNode childNode in nextControl.ChildNodes)
//            {
//                if (childNode.Attributes.Count == 2 && childNode.Attributes["Event"].Value == "NewDialog")
//                {
//                    childNode.InnerText = propertyName + "=" + trueValue;
//                }
//                else if (childNode.Attributes.Count == 2 && childNode.Attributes["Event"].Value == "SpawnDialog")
//                {
//                    childNode.InnerText = propertyName + "=" + falseValue;
//                }
//            }

//            doc.Save(registrationDlgFile);
//        }

//        public static void UpdateUserInterfaceText(UserInterface userInterface, string id, string text)
//        {

//        }

//        public static void Compile(bool withRegistrationDlg, string uiType)
//        {
//            string currentDirectory = Environment.CurrentDirectory;
//            try
//            {
//                Environment.CurrentDirectory = Common.localWixFolder;
//                // clear all ".wixobj" files
//                string[] objectFiles = Directory.GetFiles(Common.localWixFolder,"*.wixobj");
//                foreach (string objectFile in objectFiles)
//                {
//                    File.Delete(objectFile);
//                }

//                string result;
//                List<string> dlgs = new List<string> { "BrowseDlg", "CancelDlg", "Common", "CustomizeDlg", "DiskCostDlg", "ErrorDlg", "ErrorProgressText", "ExitDialog", "FatalError", "FilesInUse", "InstallDirDlg", "LicenseAgreementDlg", "MaintenanceTypeDlg", "MaintenanceWelcomeDlg", "MsiRMFilesInUse", "OutOfDiskDlg", "OutOfRbDiskDlg", "PrepareDlg", "ProgressDlg", "ResumeDlg", "SetupTypeDlg", "UserExit", "VerifyReadyDlg", "WaitForCostingDlg", "WelcomeDlg", "WelcomeEulaDlg", "RegistrationDlg" };

//                string argument = @"wixui\" + uiType + Path.DirectorySeparatorChar
//                    + (withRegistrationDlg ? "Nvn" : "") + "WixUI_" + uiType + ".wxs";
//                foreach (string dlg in dlgs)// append all dld names... ex: WixUI_Mondo.wxs Browse.dlg CancelDlg.wxs
//                {
//                    argument += @" wixui\" + dlg + ".wxs";
//                }

//                string process = "candle.exe";
//                // create object file
//                ProcessStartInfo procStartInfo = new ProcessStartInfo(process);
//                procStartInfo.Arguments = argument;
//                procStartInfo.RedirectStandardOutput = true;
//                procStartInfo.UseShellExecute = false;
//                procStartInfo.CreateNoWindow = true;
//                Process proc = new Process();
//                proc.StartInfo = procStartInfo;
//                proc.Start();
//                result = proc.StandardOutput.ReadToEnd();

//                // check result text whether it says if any error occured while creating object files
//                string[] files = Directory.GetFiles(Common.localWixFolder,"*.wixobj");
//                //if (files.Length == dlgs.Count + 1)
//                //{
//                    //TODO: Notify error message if there is any error
//                    // create Library file
//                    argument = string.Empty;
//                    string outFile = "-out " + "wixui.wixlib ";
//                    foreach (string dlg in dlgs)
//                    {
//                        argument += " " + dlg + ".wixobj";
//                    }
//                    argument = outFile + (withRegistrationDlg ? "Nvn" : "") + "WixUI_" + uiType + ".wixobj " + argument;

//                    process = Common.localWixFolder + Path.DirectorySeparatorChar + "lit.exe";
//                    procStartInfo = new ProcessStartInfo(process);
//                    procStartInfo.Arguments = argument;
//                    procStartInfo.RedirectStandardOutput = true;
//                    procStartInfo.UseShellExecute = false;
//                    procStartInfo.CreateNoWindow = true;
//                    proc = new Process();
//                    proc.StartInfo = procStartInfo;
//                    proc.Start();
//                    result = proc.StandardOutput.ReadToEnd();
//                    //TODO:Notify error message if there is any error   
//                //}
//            }
//            finally
//            {
//                Environment.CurrentDirectory = currentDirectory;
//            }
//        }
//    }
//}
