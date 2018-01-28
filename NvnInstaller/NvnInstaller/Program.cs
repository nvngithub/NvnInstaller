using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace NvnInstaller {
    static class Program {
        [STAThread]
        static void Main(string[] args) {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                if (args.Length == 1) {
                    Globals.isByCommand = true;
                    Application.Run(new MainForm(args[0], false, false));
                } else if (args.Length > 0) {
                    Globals.isByCommand = true;
                    string projectFile = string.Empty, build = string.Empty, autoClose = string.Empty;

                    if (args.Length > 0) projectFile = args[0];
                    if (args.Length > 1) Globals.outFile = args[1];
                    if (args.Length > 2) build = args[2];
                    if (args.Length > 3) autoClose = args[3];

                    Application.Run(new MainForm(projectFile, build == "TRUE", autoClose == "TRUE"));
                } else {
                    Application.Run(new MainForm());
                }
            } catch (Exception exc) {
                LogException(exc);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            LogException((Exception)e.ExceptionObject);            
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            LogException(e.Exception);
        }

        private static void LogException(Exception exc) {
            if (exc != null) {
                Logger.ApplicationLog(new LogMessage(exc.Message, exc));
                ExceptionForm exceptionForm = new ExceptionForm(exc);
                exceptionForm.ShowDialog();
            }
        }
    }
}
