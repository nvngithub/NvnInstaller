using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.Build.Utilities;
using Microsoft.Build.Tasks.Deployment.ManifestUtilities;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.Build.Tasks;
using Microsoft.Build.Framework;
using System.Resources;
using NvnInstaller.Properties;
using System.Xml.Serialization;

namespace NvnInstaller {
    class MsiCompiler {
        public static string BootstrapperName;

        public void Compile(string outputFilePath) {
            string finalOutputFilePath = outputFilePath;

            if (Globals.sfxEnabled) {
                // Generate setup file in Temp location if bootstrapper selected or else in normal location
                outputFilePath = String.IsNullOrEmpty(BootstrapperName) ? outputFilePath : Common.BootstrapTempLocation + Path.GetFileName(outputFilePath);
            }

            //1. Generate object file
            Globals.NotifyBuildProgress(1, "Generating object file");
            bool success = GenerateObjectFile();
            if (success == false) {
                Globals.NotifyBuildProgress(-1, "Generating object file failed !");
                return;
            }

            //2. Generate MSI file
            Globals.NotifyBuildProgress(10, "Generating MSI file");
            success = GenerateMsiFile(outputFilePath);
            if (success == false) {
                Globals.NotifyBuildProgress(-1, "Generating MSI file failed !");
                return;
            }
            Globals.NotifyBuildProgress(20, "MSI file generated");

            //3. Generate bootstrapper/Custom UI package
            if (String.IsNullOrEmpty(BootstrapperName) == false) {
                Globals.NotifyBuildProgress(5, "Generating bootstrapper file");

                if (ControlsManager.CustomUIApplicationControl.IsCustomUiUsed) {
                    success = GenerateCustomUIExe(outputFilePath, finalOutputFilePath);
                } else {
                    success = GenerateBootstrapper(outputFilePath, finalOutputFilePath);
                }

                if (success == false) {
                    Globals.NotifyBuildProgress(-1, "Generating bootstrapper file failed");
                    return;
                }

                Globals.NotifyBuildProgress(20, "Setup file with bootstrapper generated");
            }

            Thread.Sleep(500);
            ClearFiles();
        }

        private bool GenerateObjectFile() {
            // Run candle.exe and generate object file
            return ExecuteCommand(Common.localWixFolder + Path.DirectorySeparatorChar + "candle.exe", "\"" + Globals.wixFile + "\" /o \"" + Globals.objectFile + "\"");
        }

        private bool GenerateMsiFile(string outputFile) {
            // Run light.exe to generate MSI file
            string currentDir = Environment.CurrentDirectory;
            Environment.CurrentDirectory = Common.localWixFolder;
            bool success = ExecuteCommand(Common.localWixFolder + Path.DirectorySeparatorChar + "light.exe", " -out \"" + outputFile + "\" \"" + Globals.objectFile + "\" " + "wixui.wixlib -loc " + MsiBuilder.UILocalizedFile);
            Environment.CurrentDirectory = currentDir;
            return success;
        }

        private bool GenerateBootstrapper(string outputFile, string finalOutputFile) {
            bool generated = GenerateSetupEXE(ControlsManager.ProductInformation.ProductName.Text, outputFile, BootstrapperName);
            if (generated == false) { return false; }
            if (Globals.sfxEnabled) {
                //* Run 7 Zip
                int index = finalOutputFile.LastIndexOf('.');
                string finalExePath = finalOutputFile.Remove(index + 1) + "exe";
                bool status = ExecuteCommand("7za.exe", "a -sfx7zS.sfx \"" + finalExePath + "\" \"" + Common.BootstrapTempLocation + "\\*\"");
                return status;
            } else {
                return generated;
            }
        }

        private bool GenerateCustomUIExe(string outputFile, string finalOutputFile) {
            string executor = Common.BootstrapTempLocation + string.Format("NvnInstaller.Executor.{0}.exe", Path.GetFileNameWithoutExtension(finalOutputFile));
            File.Copy(Globals.applicationFolder + "NvnInstaller.Executor.exe", executor, true);

            foreach (NameValue supportingFile in ControlsManager.CustomUIApplicationControl.SelectedItems) {
                File.Copy(supportingFile.Value, Common.BootstrapTempLocation + Path.GetFileName(supportingFile.Value), true);
            }

            bool generated = GenerateSetupEXE(ControlsManager.ProductInformation.ProductName.Text, executor, BootstrapperName);
            if (generated == false) { return false; }

            // Run 7 Zip and embed all files in temp location
            int index = finalOutputFile.LastIndexOf('.');
            string finalExePath = finalOutputFile.Remove(index + 1) + "exe";
            bool status = ExecuteCommand("7za.exe", "a -r -y -sfx7zS.sfx \"" + finalExePath + "\" \"" + Common.BootstrapTempLocation + "\\*\"");

            return status;
        }

        private bool ExecuteCommand(string process, string argument) {
            string result = string.Empty;

            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(process);
            procStartInfo.Arguments = argument;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            result = proc.StandardOutput.ReadToEnd();

            string[] resultArr = result.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (resultArr.Length >= 4 && resultArr[3].Length > 50) {
                Logger.ApplicationLog(new LogMessage("Build Error", new Exception(String.Join("\r\n", resultArr, 2, resultArr.Length - 2).Replace("'", ""))));
                ExceptionForm exceptionForm = new ExceptionForm(new Exception(result));
                exceptionForm.ShowDialog();
                return false;
            }
            return true;
        }

        private bool GenerateSetupEXE(string productName, string applicationPath, string bootstrapperItem) {
            GenerateBootstrapper gbs = new GenerateBootstrapper();
            TaskItem taskItem;
            try {
                gbs.ApplicationName = productName;
                gbs.ApplicationFile = Path.GetFileName(applicationPath);// application executed after installing prerequisites
                taskItem = new TaskItem(bootstrapperItem);
                gbs.BootstrapperItems = new ITaskItem[] { taskItem };
                gbs.Path = Common.BootstrapperPath;
                gbs.ComponentsLocation = ComponentsLocation.Relative.ToString();
                gbs.CopyComponents = true;
                gbs.OutputPath = Path.GetDirectoryName(applicationPath);
                gbs.Execute();
            } catch (Exception ex) {
                Logger.ApplicationLog(new LogMessage("Failed to generate bootstrapper", ex));
                return false;
            }
            return true;
        }

        private void ClearFiles() {
            if (File.Exists(Globals.wixFile)) File.Delete(Globals.wixFile);
            if (File.Exists(Globals.objectFile)) File.Delete(Globals.objectFile);
            // Delete all directories except Wix
            string[] dirs = Directory.GetDirectories(Globals.localFolder);
            foreach (string dir in dirs) {
                if (dir.EndsWith("Wix", StringComparison.OrdinalIgnoreCase) == false) Directory.Delete(dir, true);
            }
        }
    }
}
