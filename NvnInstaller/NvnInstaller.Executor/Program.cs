using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace NvnInstaller.Executor {
    class Program {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread()]
        static void Main(string[] args) {
            Console.Title = "NvnInstaller.Executor";
            SetConsoleWindowVisibility(false, Console.Title);

            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
            string[] nameArr = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location).Split(".".ToCharArray());
            Process uiApp = Process.Start(exePath + nameArr[nameArr.Length - 1] + ".exe");
            uiApp.WaitForExit();
        }

        public static void SetConsoleWindowVisibility(bool visible, string title) {
            IntPtr hWnd = FindWindow(null, title);

            if (hWnd != IntPtr.Zero) {
                if (!visible)
                    ShowWindow(hWnd, 0); // 0 = SW_HIDE               
                else
                    ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA          
            }
        }
    }
}
