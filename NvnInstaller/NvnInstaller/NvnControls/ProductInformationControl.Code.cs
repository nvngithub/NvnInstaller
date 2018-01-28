using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wix = NvnInstaller.WixClasses;
using System.Data;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Resources;
using NvnInstaller.Properties;

namespace NvnInstaller {
    partial class ProductInformationControl : INvnControl {
        #region ICommonControl Members

        void INvnControl.Open(Dictionary<string, object> objects) {
            if (objects.ContainsKey("Bootstrapper")) {
                cmbPrerequisite.SelectedValue = objects["Bootstrapper"];
            }
            if (objects.ContainsKey("ProductInformation")) {
                productInformation = (ProductInformation)objects["ProductInformation"];
                LoadProductInformation();
                Support.ArraylistToTreeview((ArrayList)objects[tvFeatures.Name], tvFeatures);
                UpdateFeaturesList();
            }
        }

        void INvnControl.InitializeLoad() {
            tvFeatures.Nodes.Clear();
            if (Common.ReleaseMode == false) {
                LoadDefaultInfo(productInformation);
                LoadProductInformation();
            }
            ClearProductInformation();
        }

        void INvnControl.Saving() {
            SetProductInformation();
        }

        void INvnControl.Close() {
            if (profileLoaded) {
                Profile.Set(featureSplitter.Name, featureSplitter.SplitterDistance.ToString());
            }
        }

        void INvnControl.Load() {      
        }

        public ControlType Type {
            get {
                return ControlType.ProductInformation;
            }
        }

        void INvnControl.LoadSaveObjects(Dictionary<string, object> objects) {
            objects.Add("ProductInformation", productInformation);
            objects.Add(tvFeatures.Name, Support.TreeviewToArraylist(tvFeatures));

            objects.Add("Bootstrapper", cmbPrerequisite.SelectedValue);
        }

        List<Summary> INvnControl.GetSummary() {
            List<Summary> summaries = new List<Summary>();

            Summary productInfoSummary = new Summary();
            productInfoSummary.Collapse = false;
            productInfoSummary.Title = "Product Information";
            DataTable data = new DataTable();
            data.Columns.Add("Property");
            data.Columns.Add("Value");
            // Set vallues
            SetProductInformation();
            data.Rows.Add("Product Name", productInformation.ProductName);
            data.Rows.Add("Title", productInformation.Title);
            data.Rows.Add("Author", productInformation.Author);
            data.Rows.Add("Manufacturer", productInformation.Manufacturer);
            data.Rows.Add("Manufacturer Url", productInformation.ManufacturerUrl);
            data.Rows.Add("Version", productInformation.Version);
            data.Rows.Add("Description", productInformation.Description);
            data.Rows.Add("Comments", productInformation.Comments);
            data.Rows.Add("Language Used", productInformation.Language);
            data.Rows.Add("Product Code", productInformation.ProductCode);
            data.Rows.Add("Upgrade Code", productInformation.UpgradeCode);
            data.Rows.Add("License File", productInformation.LicenseFile);
            data.Rows.Add("Output File", productInformation.OutputFile);
            data.Rows.Add("AddRemove Icon", productInformation.AddRemoveIcon);
            data.Rows.Add("Support Url", productInformation.SupportUrl);
            data.Rows.Add("UserInterface Type", productInformation.UserInterfaceType.ToString());

            productInfoSummary.Data = data;
            summaries.Add(productInfoSummary);

            //features
            if (tvFeatures.Nodes.Count > 0) {
                Summary featuresSummary = new Summary();
                featuresSummary.Title = "Features";
                DataTable featuresTable = new DataTable();
                featuresTable.Columns.Add("Feature Name");
                featuresTable.Columns.Add("Description");
                GetFeatureSummary(tvFeatures.Nodes[0], featuresTable);
                featuresSummary.Data = featuresTable;
                summaries.Add(featuresSummary);
            }

            return summaries;
        }

        private void GetFeatureSummary(TreeNode rootNode, DataTable summary) {
            summary.Rows.Add(rootNode.Text, ((FeatureProperty)rootNode.Tag).Description);
            foreach (TreeNode node in rootNode.Nodes) {
                GetFeatureSummary(node, summary);
            }
        }

        void INvnControl.Validate() {
            List<BuildLogMessage> tempMessages = new List<BuildLogMessage>();
            BuildLogMessage logMessage = null;
            // version number
            logMessage = Validator.ValidateVersionNumber(Version.Text);
            if (logMessage != null) BuildLogger.Add(logMessage);
            // check license file exists
            if (String.IsNullOrEmpty(LicenseFile.Text) || System.IO.File.Exists(LicenseFile.Text) == false) {
                BuildLogMessage licenseFileMessage = new BuildLogMessage();
                licenseFileMessage.Message = "License file not found";
                licenseFileMessage.Type = LogType.ERROR;
                licenseFileMessage.Module = Modules.ProductInformation;
                BuildLogger.Add(licenseFileMessage);// add to the list
            }
            // check Icon file
            if (String.IsNullOrEmpty(IconFile.Text) || System.IO.File.Exists(IconFile.Text) == false) {
                BuildLogMessage iconFileMessage = new BuildLogMessage();
                iconFileMessage.Message = "Icon file is not selected. Installer will set default icon for this product.";
                iconFileMessage.Type = LogType.Warning;
                iconFileMessage.Module = Modules.ProductInformation;
                BuildLogger.Add(iconFileMessage);// add to the list
            }
            logMessage = Validator.IsNullOrEmpty(Output.Text, "Output file(MSI)", LogType.ERROR, Modules.ProductInformation);
            if (logMessage != null) BuildLogger.Add(logMessage);
            //check minimum installer version for empty, integer
            logMessage = Validator.IsNullOrEmpty(txtMajorVersion.Text, "Value 'Major' of minimum installer version", LogType.ERROR, Modules.ProductInformation);
            if (logMessage != null) BuildLogger.Add(logMessage);
            if (Common.IsInteger(txtMajorVersion.Text) == false || Common.IsInteger(txtMinorVersion.Text) == false) {
                BuildLogMessage iconFileMessage = new BuildLogMessage();
                iconFileMessage.Message = "Value set for minimum installer version is not in valid format.";
                iconFileMessage.Type = LogType.ERROR;
                iconFileMessage.Module = Modules.ProductInformation;
                BuildLogger.Add(iconFileMessage);// add to the list
            }
            // validate URLs
            logMessage = Validator.ValidateUrl("Manufacturer Url", ManufacturerUrl.Text, Modules.ProductInformation);
            if (logMessage != null) BuildLogger.Add(logMessage);
            logMessage = Validator.ValidateUrl("Support Url", SupportUrl.Text, Modules.ProductInformation);
            if (logMessage != null) BuildLogger.Add(logMessage);
            // check for null or empty
            tempMessages = Validator.IsNullOrEmpty(
                new string[] { ProductCode.Text, UpgradeCode.Text, PackageId.Text, ProductName.Text, Title.Text, Version.Text, Author.Text, Manufacturer.Text },
                new string[] { "Product code", "Upgrade code", "Package Id", "Product name", "Title", "Version", "Author", "Manufacturer" },
                LogType.ERROR, Modules.ProductInformation);
            BuildLogger.Add(tempMessages);
            // check for acceptible chars
            tempMessages = Validator.ContainsInvalidChar(
                new string[] { ProductName.Text, Title.Text, Version.Text, Author.Text, Manufacturer.Text },
                new string[] { "Product name", "Title", "Version", "Author", "Manufacturer" },
                LogType.ERROR, Modules.ProductInformation);
            BuildLogger.Add(tempMessages);
            // check for property length
            tempMessages = Validator.ValidatePropertyLength(
                new string[] { ProductName.Text, Title.Text, Author.Text, Manufacturer.Text },
                new string[] { "Product name", "Title", "Author", "Manufacturer" },
                LogType.ERROR, Modules.ProductInformation);
            BuildLogger.Add(tempMessages);
            // check for description length
            tempMessages = Validator.ValidateDescriptionLength(
                new string[] { Description.Text, Comments.Text },
                new string[] { "Description", "Comments" },
                LogType.Warning, Modules.ProductInformation);
            BuildLogger.Add(tempMessages);
            // validate IDs
            logMessage = Validator.ValidateGuid(ProductCode.Text, "Product code");
            if (logMessage != null) BuildLogger.Add(logMessage);
            logMessage = Validator.ValidateGuid(UpgradeCode.Text, "Upgrade code");
            if (logMessage != null) BuildLogger.Add(logMessage);

            #region Features
            tempMessages = Validator.ValidateTree(tvFeatures, false, Modules.ProductInformation);
            BuildLogger.Add(tempMessages);

            if (tvFeatures.Nodes.Count == 0) {
                BuildLogMessage featureNotDefined = new BuildLogMessage();
                featureNotDefined.Message = "No Feature defined";
                featureNotDefined.Type = LogType.ERROR;
                featureNotDefined.Module = Modules.ProductInformation;
                BuildLogger.Add(featureNotDefined);
            }
            #endregion
        }

        void INvnControl.InitializeBuild() {
        }

        void INvnControl.Build() {
            //Copy license text 
            File.Copy(LicenseFile.Text, Common.localWixFolder + Path.DirectorySeparatorChar + "License.rtf", true);
            // Copy images to wix folder
            ResourceManager res = new ResourceManager(typeof(Resources));
            if (Globals.registered) {
                if (txtBanner.Text != "[Default]") {
                    File.Copy(txtBanner.Text, Globals.localFolder + @"Wix\Bitmaps\bannrbmp.bmp", true);
                } else {
                    Bitmap bannerImg = (Bitmap)res.GetObject("bannrbmp");
                    bannerImg.Save(Common.localWixFolder + Path.DirectorySeparatorChar + "Bitmaps" + Path.DirectorySeparatorChar + "bannrbmp.bmp");
                }
                if (txtDialog.Text != "[Default]") {
                    File.Copy(txtDialog.Text, Globals.localFolder + @"Wix\Bitmaps\dlgbmp.bmp", true);
                } else {
                    Bitmap dlgImg = (Bitmap)res.GetObject("dlgbmp");
                    dlgImg.Save(Common.localWixFolder + Path.DirectorySeparatorChar + "Bitmaps" + Path.DirectorySeparatorChar + "dlgbmp.bmp");
                }
            } else {
                Bitmap bannerImg = (Bitmap)res.GetObject("bannrbmp");
                bannerImg.Save(Common.localWixFolder + Path.DirectorySeparatorChar + "Bitmaps" + Path.DirectorySeparatorChar + "bannrbmp.bmp");
                Bitmap dlgImg = (Bitmap)res.GetObject("dlgbmp");
                dlgImg.Save(Common.localWixFolder + Path.DirectorySeparatorChar + "Bitmaps" + Path.DirectorySeparatorChar + "dlgbmp.bmp");
            }

            //<Product>
            string[] selectedLanguage = ((string)cmbLanguage.SelectedValue).Split("|".ToCharArray());
            MsiBuilder.Product = new Wix.Product();
            MsiBuilder.Product.Name = ProductName.Text;
            MsiBuilder.Product.Version = Version.Text;
            MsiBuilder.Product.Id = ProductCode.Text;
            MsiBuilder.Product.UpgradeCode = UpgradeCode.Text;
            MsiBuilder.Product.Language = selectedLanguage[0];
            MsiBuilder.Product.Codepage = selectedLanguage[1];
            MsiBuilder.UILocalizedFile = selectedLanguage[2];
            MsiBuilder.Product.Manufacturer = Manufacturer.Text;
            //<Product>/<Package>
            MsiBuilder.Product.Package = new Wix.Package();
            MsiBuilder.Product.Package.Id = PackageId.Text;
            MsiBuilder.Product.Package.Keywords = "Installer";
            if (Description.Text != string.Empty) {
                MsiBuilder.Product.Package.Description = Description.Text;
            }
            if (Comments.Text != string.Empty) {
                MsiBuilder.Product.Package.Comments = Comments.Text;
            }
            MsiBuilder.Product.Package.Manufacturer = Manufacturer.Text;
            int majorInstallerVersion = Int32.Parse(txtMajorVersion.Text);
            int minorInstallerVersion = String.IsNullOrEmpty(txtMinorVersion.Text) ? 0 : Int32.Parse(txtMinorVersion.Text);
            MsiBuilder.Product.Package.InstallerVersion = (majorInstallerVersion * 100 + minorInstallerVersion).ToString();
            MsiBuilder.Product.Package.Languages = selectedLanguage[0];
            MsiBuilder.Product.Package.CompressedSpecified = true;
            MsiBuilder.Product.Package.Compressed = Wix.YesNoType.yes;
            MsiBuilder.Product.Package.SummaryCodepage = selectedLanguage[1];
            if (chk64Bit.Checked) {
                MsiBuilder.Product.Package.Platforms = "x64";
            }

            //Build User Interface
            Wix.UIRef uiRef1 = new Wix.UIRef();
            if (rbMondo.Checked)
                uiRef1.Id = "WixUI_Mondo";
            else if (rbFeatureTree.Checked)
                uiRef1.Id = "WixUI_FeatureTree";
            else if (rbInstall.Checked) {
                uiRef1.Id = "WixUI_InstallDir";
                Wix.Property installDirProperty = new Wix.Property();
                installDirProperty.Id = "WIXUI_INSTALLDIR";
                installDirProperty.Value = "INSTALLDIR";
                MsiBuilder.PropertyElements.Add(installDirProperty.Id, installDirProperty);
            } else if (rbMinimal.Checked)
                uiRef1.Id = "WixUI_Minimal";
            Wix.UIRef uiRef2 = new Wix.UIRef();
            uiRef2.Id = "WixUI_ErrorProgressText";
            MsiBuilder.UIRef.Add(uiRef1);
            MsiBuilder.UIRef.Add(uiRef2);

            // application is installed for all users ... 
            Wix.Property allUsersProp = new Wix.Property();
            allUsersProp.Id = "ALLUSERS";
            allUsersProp.Value = "1";
            MsiBuilder.PropertyElements.Add(allUsersProp.Id, allUsersProp);

            // Set properties for Icon
            if (String.IsNullOrEmpty(IconFile.Text) == false) {
                Wix.Icon icon = new Wix.Icon();
                icon.Id = "iconfile.exe"; // STRANGE : The Id for the Icon element must end in '.exe' (i.e. LinkedCells.exe)
                icon.SourceFile = IconFile.Text;
                MsiBuilder.ProductMiscElements.Add(icon);

                Wix.Property productIconProp = new Wix.Property();
                productIconProp.Id = "ARPPRODUCTICON";
                productIconProp.Value = icon.Id;
                MsiBuilder.PropertyElements.Add(productIconProp.Id, productIconProp);
            }

            #region Features
            if (tvFeatures.Nodes.Count > 0) {
                TreeNode rootFeatureNode = tvFeatures.Nodes[0];
                FeatureProperty property = (FeatureProperty)rootFeatureNode.Tag;
                if (property != null) {
                    MsiBuilder.Feature.Id = property.Id;
                    MsiBuilder.Feature.Title = property.Name;
                    MsiBuilder.Feature.Description = property.Description;
                    MsiBuilder.Feature.Display = "expand";
                    MsiBuilder.Feature.Level = "1";
                    MsiBuilder.Feature.ConfigurableDirectory = "INSTALLDIR";
                    MsiBuilder.FeatureTable.Add(MsiBuilder.Feature.Id, MsiBuilder.Feature);

                    foreach (TreeNode featureNode in rootFeatureNode.Nodes) {
                        CreateFeature(featureNode, MsiBuilder.Feature);
                    }
                }
            }
            #endregion

            // Prerequisites
            if (cmbPrerequisite.SelectedIndex != 0) /* If selected item is not NONE */ {
                MsiCompiler.BootstrapperName = (string)cmbPrerequisite.SelectedValue;
            }
        }

        private void CreateFeature(TreeNode featureNode, Wix.Feature parentFeature) {
            FeatureProperty childFeatureProperty = (FeatureProperty)featureNode.Tag;
            Wix.Feature feature = new Wix.Feature();
            feature.Id = childFeatureProperty.Id;
            feature.Level = "1";
            feature.Title = childFeatureProperty.Name;
            feature.Description = childFeatureProperty.Description;
            parentFeature.Items = Common.AddItemToArray(parentFeature.Items, feature);
            MsiBuilder.FeatureTable.Add(childFeatureProperty.Id, feature);

            if (featureNode.Nodes.Count > 0) {
                foreach (TreeNode childFeature in featureNode.Nodes) {
                    CreateFeature(childFeature, feature);
                }
            }
        }

        #endregion

        #region Other methods

        private void ClearProductInformation() {
            ProductCode.Text = UpgradeCode.Text = PackageId.Text = string.Empty;
            ProductName.Text = string.Empty;
            Title.Text = Author.Text = Version.Text = Manufacturer.Text = string.Empty;
            ManufacturerUrl.Text = SupportUrl.Text = string.Empty;
            chk64Bit.Checked = false;
            Description.Text = Comments.Text = string.Empty;
            LicenseFile.Text = Output.Text = IconFile.Text = string.Empty;
            pbIcon.Image = null;
            rbMondo.Checked = true;
            txtBanner.Text = txtDialog.Text = "[Default]";
            cmbLanguage.SelectedIndex = 0;
            txtMajorVersion.Text = "1";
            txtMinorVersion.Text = "0";
        }

        public ProductInformation SetProductInformation() {
            productInformation.ProductCode = ProductCode.Text;
            productInformation.UpgradeCode = UpgradeCode.Text;
            productInformation.PackageId = PackageId.Text;
            productInformation.ProductName = ProductName.Text;
            productInformation.Title = Title.Text;
            productInformation.Author = Author.Text;
            productInformation.Version = Version.Text;
            productInformation.Manufacturer = Manufacturer.Text;
            productInformation.ManufacturerUrl = ManufacturerUrl.Text;
            productInformation.SupportUrl = SupportUrl.Text;
            productInformation.Is64Bit = chk64Bit.Checked;
            productInformation.Description = Description.Text;
            productInformation.Comments = Comments.Text;
            productInformation.LicenseFile = LicenseFile.Text;
            productInformation.OutputFile = Output.Text;
            productInformation.AddRemoveIcon = IconFile.Text;
            if (rbMondo.Checked) productInformation.UserInterfaceType = UIType.Mondo;
            else if (rbFeatureTree.Checked) productInformation.UserInterfaceType = UIType.FeatureTree;
            else if (rbInstall.Checked) productInformation.UserInterfaceType = UIType.InstallDir;
            else if (rbMinimal.Checked) productInformation.UserInterfaceType = UIType.Minimal;
            productInformation.BannerImage = txtBanner.Text;
            productInformation.DialogImage = txtDialog.Text;
            productInformation.Language = cmbLanguage.Text;
            productInformation.MajorInstallerVersion = txtMajorVersion.Text;
            productInformation.MinorInstallerVersion = txtMinorVersion.Text;

            return productInformation;
        }

        public void LoadProductInformation() {
            ProductCode.Text = productInformation.ProductCode;
            UpgradeCode.Text = productInformation.UpgradeCode;
            PackageId.Text = productInformation.PackageId;
            ProductName.Text = productInformation.ProductName;
            Title.Text = productInformation.Title;
            Author.Text = productInformation.Author;
            Version.Text = productInformation.Version;
            Manufacturer.Text = productInformation.Manufacturer;
            ManufacturerUrl.Text = productInformation.ManufacturerUrl;
            SupportUrl.Text = productInformation.SupportUrl;
            chk64Bit.Checked = productInformation.Is64Bit;
            Description.Text = productInformation.Description;
            Comments.Text = productInformation.Comments;
            LicenseFile.Text = productInformation.LicenseFile;
            Output.Text = productInformation.OutputFile;
            IconFile.Text = productInformation.AddRemoveIcon;
            if (File.Exists(IconFile.Text)) pbIcon.Image = (new Icon(IconFile.Text)).ToBitmap();
            switch (productInformation.UserInterfaceType) {
                case UIType.Mondo: rbMondo.Checked = true; break;
                case UIType.FeatureTree: rbFeatureTree.Checked = true; break;
                case UIType.InstallDir: rbInstall.Checked = true; break;
                case UIType.Minimal: rbMinimal.Checked = true; break;
            }
            txtBanner.Text = productInformation.BannerImage;
            txtDialog.Text = productInformation.DialogImage;
            cmbLanguage.Text = productInformation.Language;
            txtMajorVersion.Text = productInformation.MajorInstallerVersion;
            txtMinorVersion.Text = productInformation.MinorInstallerVersion;
        }

        public void LoadDefaultInfo(ProductInformation information) {
            if (File.Exists(Globals.productInformationFile)) {
                XmlDocument document = new XmlDocument();
                document.Load(Globals.productInformationFile);

                XmlNodeList fieldList = document.GetElementsByTagName("Property");
                FieldInfo[] fields = information.GetType().GetFields();
                foreach (XmlNode fieldNode in fieldList) {
                    foreach (FieldInfo field in fields) {
                        string name = fieldNode.Attributes["name"].Value;
                        if (name == field.Name) {
                            if (field.FieldType == typeof(bool))
                                field.SetValue(information, Convert.ToBoolean(fieldNode.Attributes["value"].Value));
                            else if (field.FieldType == typeof(UIType))
                                field.SetValue(information, Enum.Parse(typeof(UIType), fieldNode.Attributes["value"].Value));
                            else
                                field.SetValue(information, (object)fieldNode.Attributes["value"].Value);
                            break;
                        }
                    }
                }
            }
        }

        public void SaveDefaultInfo(ProductInformation information) {
            XmlDocument doc = new XmlDocument();
            XmlNode declaration = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(declaration);

            XmlElement root = doc.CreateElement("ProductInformation");
            doc.AppendChild(root);

            Type type = information.GetType();
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields) {
                XmlElement fieldElement = doc.CreateElement("Property");

                XmlAttribute attribute = doc.CreateAttribute("name");
                attribute.Value = field.Name;
                fieldElement.Attributes.Append(attribute);
                XmlAttribute valueAttribute = doc.CreateAttribute("value");
                valueAttribute.Value = Convert.ToString(field.GetValue(information));
                fieldElement.Attributes.Append(valueAttribute);

                root.AppendChild(fieldElement);
            }
            doc.Save(Globals.productInformationFile);
        }
        #endregion
    }
}
