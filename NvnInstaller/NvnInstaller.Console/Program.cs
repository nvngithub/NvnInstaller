using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Resources;

namespace NvnInstaller.Console {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            string logFile = string.Empty;
            string outFile = string.Empty;
            string projectFile = string.Empty;
            bool autoClose = false, build = false;
            System.Console.WriteLine(String.Format("NvnInstaller.Console [Version {0}]", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            System.Console.WriteLine("Copyright (c) Naveen Hegde. All rights reserved.");
            System.Console.WriteLine("");

            #region Display Help
            // Display Only help
            if ((args.Length == 1 && (args[0].Equals("/h", StringComparison.OrdinalIgnoreCase)
                || args[0].Equals("/?", StringComparison.OrdinalIgnoreCase))) || args.Length == 0) {
                // get text from file and display on command prompt
                string helpText = Properties.Resources.ResourceManager.GetString("NvnInstallerConsoleHelp");
                if (String.IsNullOrEmpty(helpText) == false) {
                    System.Console.WriteLine(helpText);
                } else {
                    System.Console.WriteLine("Error occured while opening the help file.");
                }

                return;
            }
            #endregion

            try {
                // parse command line options and start the application
                for (int i = 0; i < args.Length; i++) {
                    string argument = args[i];
                    // MSI output file
                    if (argument.StartsWith("-o=", StringComparison.OrdinalIgnoreCase)) {
                        outFile = argument.Remove(0, 3).Trim("\"".ToCharArray());
                    } else if (argument.Equals("-bc", StringComparison.OrdinalIgnoreCase)) {
                        autoClose = true;
                        build = true;
                    } else if (argument.Equals("-b", StringComparison.OrdinalIgnoreCase)) {
                        build = true;
                    }
                    if (argument.StartsWith("-f=", StringComparison.OrdinalIgnoreCase)) {
                        projectFile = argument.Remove(0, 3);
                        // check file exists
                        if (File.Exists(projectFile) == false) {
                            System.Console.WriteLine("WARNING: Project file not found");
                        }
                    }
                }
                if (autoClose == false && String.IsNullOrEmpty(projectFile)) {
                    System.Console.WriteLine("ERROR: Command does not contain project file.");
                }
                if (autoClose == false && String.IsNullOrEmpty(outFile)) {
                    System.Console.WriteLine("WARNING: Command does not contain 'out' option. Settings in  product information is used.");
                }

                string arguments = String.Format("\"{0}\" \"{1}\" {2} {3}", projectFile, outFile, build ? "TRUE" : "FALSE", autoClose ? "TRUE" : "FALSE");

                // start NVN Installer
                Process p = Process.Start((new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName) + @"\NvnInstaller.exe", arguments);
                p.WaitForExit();
            } catch (Exception exc) {
                Logger.ConsoleLog(new LogMessage(exc.Message, exc));
            }
        }
    }
}