using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using mshtml;

namespace NvnInstaller {
    public partial class WixCodeEditorControl : UserControl {
        static StringBuilder wixCode;
        HTMLDocumentEvents2_Event browserEvents;

        public WixCodeEditorControl() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (Globals.registered) {
                // Allow user to save wix file it application is registered
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "wxs";
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.Title = "Save WIX file";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    // save wix file
                    using (StreamWriter writer = new StreamWriter(new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))) {
                        writer.Write(wixCode.ToString());
                    }
                }
            } else {
                //Show registration form
                new RegisterForm().ShowDialog();
            }
        }

        public void LoadWixFileText(string filename) {
            webBrowser.Navigate(filename);

            // change font size
            IHTMLDocument2 doc = (IHTMLDocument2)webBrowser.Document;
            doc.execCommand("SelectAll", false, null);
            doc.execCommand("FontSize", false, 1);
            doc.execCommand("Unselect", false, null);

            // do not allow user to select text if not registered
            if (Globals.registered == false) {
                browserEvents = (HTMLDocumentEvents2_Event)webBrowser.Document;
                browserEvents.onselectionchange += new HTMLDocumentEvents2_onselectionchangeEventHandler(browserEvents_onselectionchange);
            } else {
                browserEvents = null;
            }

            using (StreamReader reader = new StreamReader(filename)) {
                wixCode = null;
                wixCode = new StringBuilder(reader.ReadToEnd());
            }
            lblTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss fff");
        }

        private void btnClear_Click(object sender, EventArgs e) {
            webBrowser.Navigate(string.Empty);
        }

        void browserEvents_onselectionchange(IHTMLEventObj pEvtObj) {
            if (Globals.registered == false) {
                IHTMLDocument2 doc = (IHTMLDocument2)webBrowser.Document;
                doc.selection.empty();
            }
        }
    }
}
