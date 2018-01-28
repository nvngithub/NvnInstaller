using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace NvnInstaller
{
    public partial class UserInterfaceControl : UserControl
    {
        private Dictionary<string, string> dialogs = new Dictionary<string, string>();
        private Dictionary<string, UIControl> uiControls = new Dictionary<string, UIControl>();
        private Dictionary<string, string> textsDictionary;
        private DataSet dsText;
        UIType userInterfaceType;

        public UserInterfaceControl()
        {
            InitializeComponent();

            CreateDialogsList();
            // Load localised text and load x,y,width,height, text into tables
            LoadAll();
            viewUIControl.Dialogs.AddRange(dialogs.Keys);
            viewUIControl.UITextDataset = dsText;
            viewUIControl.BannerImg = txtBanner.Text;
            viewUIControl.DialogImg = txtDialog.Text;

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dialogs;
            lstDialogs.DisplayMember = "Value";
            lstDialogs.ValueMember = "Key";
            lstDialogs.DataSource = bindingSource;
        }

        private void LoadAll()
        {
            textsDictionary = LoadLocalizedText(Common.wixUIFolder + Path.DirectorySeparatorChar + "WixUI_en-us.wxl");
            LoadTextIntoDataset();
        }

        private void CreateDialogsList()
        {
            dialogs.Add("BrowseDlg.wxs", "Browse");
            dialogs.Add("CancelDlg.wxs", "Cancel");
            dialogs.Add("DiskCostDlg.wxs", "DiskCost");
            dialogs.Add("ErrorDlg.wxs", "Error");
            dialogs.Add("ExitDialog.wxs", "Exit");
            dialogs.Add("FatalError.wxs", "Fatal Error");
            dialogs.Add("CustomizeDlg.wxs", "Customize");
            dialogs.Add("FilesInUse.wxs", "Files In Use");
            dialogs.Add("LicenseAgreementDlg.wxs", "License Agreement");
            dialogs.Add("MaintenanceTypeDlg.wxs", "Maintenance Type");
            dialogs.Add("MaintenanceWelcomeDlg.wxs", "Maintenance Welcome");
            dialogs.Add("PrepareDlg.wxs", "Prepare");
            dialogs.Add("ResumeDlg.wxs", "Resume");
            dialogs.Add("SetupTypeDlg.wxs", "Setup Type");
            dialogs.Add("UserExit.wxs", "User Exit");
            dialogs.Add("VerifyReadyDlg.wxs", "Prepare");
            dialogs.Add("WelcomeDlg.wxs", "Welcome");
        }

        private void LoadTextIntoDataset()
        {
            dsText = new DataSet();
            // key = source file
            foreach (string src in dialogs.Keys)
            {
                DataTable table = CreateTable(src);
                dsText.Tables.Add(table);

                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(Common.wixUIFolder + Path.DirectorySeparatorChar + src,FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                doc.Load(stream);
                XmlNodeList controls = doc.GetElementsByTagName("Control");
                foreach (XmlNode control in controls)
                {
                    if (control.Attributes["Type"].Value == "Text")
                    {
                        if (control.Attributes["Text"] != null)
                        {
                            string textId = control.Attributes["Text"].Value;
                            textId = textId.Remove(0, 6);
                            textId = textId.Remove(textId.Length - 1);
                            string text = textsDictionary[textId];
                            DataRow row = table.Rows.Add(control.Attributes["Id"].Value, control.Attributes["X"].Value, control.Attributes["Y"].Value
                              , control.Attributes["Width"].Value, control.Attributes["Height"].Value,"", textId, text);// varify the order of values
                            ProcessFont(row);
                        }
                    }
                }
                //create UI control
                XmlNodeList dialogNodes = doc.GetElementsByTagName("Dialog");                
                int width = int.Parse(dialogNodes[0].Attributes["Width"].Value);
                int height = int.Parse(dialogNodes[0].Attributes["Height"].Value);
                UIControl ctrl = new UIControl(dsText.Tables[src]);
                //ctrl.DialogSize = new Size(width, height);
                ctrl.Dock = DockStyle.Fill;
                uiControls.Add(src, ctrl);
            }
        }

        private void ProcessFont(DataRow row)
        {
            Dictionary<string, UIFontSize> wixFonts = new Dictionary<string, UIFontSize> { 
            {@"{\WixUI_Font_Title}",UIFontSize.Title}, {@"{\WixUI_Font_Bigger}",UIFontSize.Bigger}, {@"{\WixUI_Font_Normal}",UIFontSize.Normal} };
            foreach (string wixFont in wixFonts.Keys)
            {
                string text = (string)row["text"];
                if (text.StartsWith(wixFont))
                {
                    row["text"] = text.Replace(wixFont, "");
                    row["fontsize"] = wixFonts[wixFont];
                    break;
                }
            }
            if (String.IsNullOrEmpty(((string)row["fontsize"])))
            {
                row["fontsize"] = UIFontSize.Normal;
            }
        }

        private Dictionary<string, string> LoadLocalizedText(string filename)
        {
            XmlDocument localisedText = new XmlDocument();
            localisedText.Load(filename);
            XmlNodeList textList = localisedText.GetElementsByTagName("String");
            Dictionary<string, string> textsDic = new Dictionary<string, string>();
            foreach (XmlNode text in textList)
            {
                textsDic.Add(text.Attributes["Id"].Value, text.InnerText);
            }
            return textsDic;
        }

        private DataTable CreateTable(string name)
        {
            DataTable table = new DataTable(name);
            table.Columns.Add("id");
            table.Columns.Add("x");
            table.Columns.Add("y");
            table.Columns.Add("width");
            table.Columns.Add("height");
            table.Columns.Add("fontsize");
            table.Columns.Add("textid");
            table.Columns.Add("text");
            foreach (DataColumn column in table.Columns)
            {
                column.ColumnMapping = MappingType.Attribute;
            }
            return table;
        }

        private void lstDialogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDialogs.SelectedIndex > -1)
            {
                foreach (Control control in splitContainer.Panel2.Controls)
                {
                    if (control is UIControl)
                    {
                        ((UIControl)control).IsCurrentControl = false;
                    }
                }
                splitContainer.Panel2.Controls.Clear();
                string selectedValue = (string)lstDialogs.SelectedValue;
                if (uiControls.ContainsKey(selectedValue))
                {
                    UIControl control = uiControls[selectedValue];
                    control.BannerImg = txtBanner.Text;
                    control.DialogImg = txtDialog.Text;
                    control.IsCurrentControl = true;
                    splitContainer.Panel2.Controls.Add(control);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // replace "specific" ui by the file in original wix ui folder
            string src = (string)lstDialogs.SelectedValue;
            File.Copy(Common.originalWixUIFolder + Path.DirectorySeparatorChar + src, Common.wixUIFolder + Path.DirectorySeparatorChar + src, true);
            // load all other values except text and ID
            Dictionary<string, XmlNode> controlNodes = new Dictionary<string, XmlNode>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Common.wixUIFolder + Path.DirectorySeparatorChar + src);
            XmlNodeList controls = doc.GetElementsByTagName("Control");
            foreach (XmlNode controlNode in controls)
            {
                if (controlNode.Attributes["Type"].Value == "Text")
                {
                    if (controlNode.Attributes["Text"] != null)
                    {
                        controlNodes.Add(controlNode.Attributes["Id"].Value, controlNode);
                    }
                }
            }

            // get text control ids and update the dictionary file             
            Dictionary<string, string> originalTexts = LoadLocalizedText(Common.originalWixUIFolder + Path.DirectorySeparatorChar + "WixUI_en-us.wxl");
            DataTable table = dsText.Tables[src];
            foreach (DataRow row in table.Rows)
            {
                row["text"] = originalTexts[(string)row["textid"]];                
                XmlNode controlNode = controlNodes[(string)row["id"]];
                row["x"] = controlNode.Attributes["X"].Value;
                row["y"] = controlNode.Attributes["Y"].Value;
                row["height"] = controlNode.Attributes["Height"].Value;
                row["width"] = controlNode.Attributes["Width"].Value;
                ProcessFont(row);
            }
            originalTexts = null;
        }

        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want restore all dialogs to default value ?", "Restore Default", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                // replace all UI source file with file by files in Wix Original
                foreach (string src in dialogs.Keys)
                {
                    File.Copy(Common.originalWixUIFolder + Path.DirectorySeparatorChar + src, Common.wixUIFolder + Path.DirectorySeparatorChar + src, true);
                }
                File.Copy(Common.originalWixUIFolder + Path.DirectorySeparatorChar + "WixUI_en-us.wxl", Common.wixUIFolder + Path.DirectorySeparatorChar + "WixUI_en-us.wxl", true);
                // Load deafult text from the Wix UI files and Update all UI,datagrids
                LoadAll();
                int selelectedIndex = lstDialogs.SelectedIndex;
                lstDialogs.SelectedIndex = -1;
                lstDialogs.SelectedIndex = selelectedIndex;
            }
        }

        #region User Interface Settings
        private void btnBrowseBanner_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Bitmaps|*.bmp|PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBanner.Text = dlg.FileName;
                viewUIControl.BannerImg = dlg.FileName;
            }
        }

        private void btnBrowseDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Bitmaps|*.bmp|PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDialog.Text = dlg.FileName;
                viewUIControl.DialogImg = dlg.FileName;
            }
        }

        private void lnkDefaultBanner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBanner.Text = @"Bitmaps\Banner.bmp";
        }

        private void lnkDefaultDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDialog.Text = @"Bitmaps\Dialog.bmp";
        }

        private void rbComplete_CheckedChanged(object sender, EventArgs e)
        {
            userInterfaceType = UIType.Mondo;
        }

        private void rbFeatureTree_CheckedChanged(object sender, EventArgs e)
        {
            userInterfaceType = UIType.FeatureTree;
        }

        private void rbInstall_CheckedChanged(object sender, EventArgs e)
        {
            userInterfaceType = UIType.InstallDir;
        }

        private void rbMinimal_CheckedChanged(object sender, EventArgs e)
        {
            userInterfaceType = UIType.Minimal;
        }
        #endregion
    }
}
