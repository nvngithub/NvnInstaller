using System;
using System.Collections.Generic;
using System.Text;
using Wix = NvnInstaller.WixClasses;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Xml;

namespace NvnInstaller
{
    partial class UserInterfaceControl : INvnControl
    {
        #region ICommonControl Members
        private bool loading;

        void INvnControl.Open(Dictionary<string, object> objects)
        {
            dsText = (DataSet)objects["UserInterfaceText"];
            userInterfaceType = (UIType)objects["UserInterfaceType"];
            switch (userInterfaceType)
            {
                case UIType.Mondo:
                    rbComplete.Checked = true;
                    break;
                case UIType.FeatureTree:
                    rbFeatureTree.Checked = true;
                    break;
                case UIType.InstallDir:
                    rbInstall.Checked = true;
                    break;
                case UIType.Minimal:
                    rbMinimal.Checked = true;
                    break;
            }
        }

        void INvnControl.InitializeLoad()
        {            
        }

        void INvnControl.Saving()
        {
        }

        void INvnControl.Close()
        {
        }

        void INvnControl.Reload()
        {

        }

        public ControlType Type
        {
            get
            {
                return ControlType.Components;
            }
        }

        public bool Loading
        {
            get
            {
                return this.loading;
            }
            set
            {
                this.loading = value;
            }
        }

        public List<Control> ProfileControls
        {
            get
            {
                return null;
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects)
        {
            objects.Add("UserInterfaceText", dsText);
            objects.Add("UserInterfaceType", userInterfaceType);
        }

        List<BuildLogMessage> INvnControl.LogMessages
        {
            get
            {
                return new List<BuildLogMessage> ();
            }
        }

        List<Summary> INvnControl.GetSummary()
        {
            return null;
        }

        void INvnControl.Validate()
        {

        }

        void INvnControl.Initialize()
        {
        }

        void INvnControl.Build()
        {
            //Build User Interface
            Wix.UIRef uiRef1 = new Wix.UIRef();
            if (rbComplete.Checked)
                uiRef1.Id = "WixUI_Mondo";
            else if (rbFeatureTree.Checked)
                uiRef1.Id = "WixUI_FeatureTree";
            else if (rbInstall.Checked)
                uiRef1.Id = "WixUI_InstallDir";
            else if (rbMinimal.Checked)
                uiRef1.Id = "WixUI_Minimal";
            Wix.UIRef uiRef2 = new Wix.UIRef();
            uiRef2.Id = "WixUI_ErrorProgressText";
            MsiBuilder.UIRef.Add(uiRef1);
            MsiBuilder.UIRef.Add(uiRef2);

            // replace UI variables with wix variables
            foreach (DataTable table in dsText.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    UIFontSize fontsize = (UIFontSize)Enum.Parse(typeof(UIFontSize), (string)row["fontsize"]);
                    switch (fontsize)
                    {
                        case UIFontSize.Normal:
                            row["text"] = @"{\WixUI_Font_Normal}" + ((string)row["text"]);//TODO: check whether this is needed or not
                            break;
                        case UIFontSize.Bigger:
                            row["text"] = @"{\WixUI_Font_Bigger}" + ((string)row["text"]);
                            break;
                        case UIFontSize.Title:
                            row["text"] = @"{\WixUI_Font_Title}" + ((string)row["text"]);
                            break;
                    }
                }
            }
            // update wix source files
            foreach (DataTable table in dsText.Tables)
            {
                string src = table.TableName;
                // update each text controls
                XmlDocument doc = new XmlDocument();
                doc.Load(Common.wixUIFolder + Path.DirectorySeparatorChar + src);
                XmlNodeList controls = doc.GetElementsByTagName("Control");
                foreach (XmlNode control in controls)
                {
                    if (control.Attributes["Type"].Value == "Text")
                    {
                        string id = control.Attributes["Id"].Value;
                        foreach (DataRow row in table.Rows)
                        {
                            if (((string)row["id"]) == id)
                            {
                                control.Attributes["X"].Value = (string)row["x"];
                                control.Attributes["X"].Value = (string)row["y"];
                                control.Attributes["Width"].Value = (string)row["width"];
                                control.Attributes["Height"].Value = (string)row["height"];
                                textsDictionary[(string)row["textid"]] = (string)row["text"];
                                break;
                            }
                        }
                    }
                }
                doc.Save(Common.wixUIFolder + Path.DirectorySeparatorChar + src);
            }
            // update WixUI-en-us.wxl (which contains text)
            XmlDocument wixdoc = new XmlDocument();
            wixdoc.Load(Common.wixUIFolder + Path.DirectorySeparatorChar + "WixUI_en-us.wxl");
            XmlNodeList textList = wixdoc.GetElementsByTagName("String");
            foreach (XmlNode text in textList)
            {
                text.InnerText = textsDictionary[text.Attributes["Id"].Value];// get value from dictionary
            }
            wixdoc.Save(Common.wixUIFolder + Path.DirectorySeparatorChar + "WixUI_en-us.wxl");
        }

        #endregion
    }
}