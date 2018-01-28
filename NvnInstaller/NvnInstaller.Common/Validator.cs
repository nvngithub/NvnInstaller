using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace NvnInstaller {
    public class Validator {
        public static List<BuildLogMessage> ValidateTree(TreeView tree, bool checkSrc, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            messages.AddRange(ValidateRepeatingNodes(tree, null, module));
            messages.AddRange(CheckLength(tree, null, module));
            messages.AddRange(CheckAcceptableChars(tree, null, module));
            messages.AddRange(CheckProperties(tree, null, module));
            if (checkSrc) {
                messages.AddRange(CheckFileSrc(tree, null, module));
            }
            if (module == Modules.Components) {
                messages.AddRange(CheckFeatureExists(tree, null, module));
            }
            return messages;
        }

        private static List<BuildLogMessage> CheckFeatureExists(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                if (childNode.Tag != null && childNode.Tag is ComponentNode) {
                    ComponentNode componentNode = (ComponentNode)childNode.Tag;
                    if (componentNode.Property.Feature != null && Common.FeatureExists(componentNode.Property.Feature.Id) == false) {
                        BuildLogMessage buildMessage = new BuildLogMessage();
                        buildMessage.Message = "Feature " + componentNode.Property.Feature.Name + " assigned to the file: " + childNode.FullPath + " is not found in the feature tree.";
                        buildMessage.Type = LogType.ERROR;
                        buildMessage.Module = Modules.Components;
                        messages.Add(buildMessage);
                    }
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(CheckFeatureExists(tree, childNode, module));
                }
            }

            return messages;
        }

        private static List<BuildLogMessage> CheckProperties(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                if (childNode.Tag != null && childNode.Tag.GetType() == typeof(ComponentNode)) {
                    ComponentNode componentNode = (ComponentNode)childNode.Tag;
                    if (componentNode.Type == ComponentType.InternetShortcut) {
                        if (String.IsNullOrEmpty(componentNode.Property.ShortcutProperty.URL)) {
                            BuildLogMessage message = new BuildLogMessage();
                            message.Message = "Internet shortcut URL is not set : " + childNode.FullPath;
                            message.Type = LogType.ERROR;
                            message.Module = module;
                            messages.Add(message);
                        } else {
                            BuildLogMessage message = ValidateUrl("Internet shortcut URL", componentNode.Property.ShortcutProperty.URL, module);
                            if(message != null) messages.Add(message);
                        }
                    }
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(CheckProperties(tree, childNode, module));
                }
            }

            return messages;
        }

        private static List<BuildLogMessage> ValidateRepeatingNodes(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            Dictionary<string, List<TreeNode>> values = new Dictionary<string, List<TreeNode>>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                string key = childNode.Text;
                if (values.ContainsKey(key)) {
                    List<TreeNode> value = values[key];
                    value.Add(childNode);
                } else {
                    List<TreeNode> valueNodes = new List<TreeNode>();
                    valueNodes.Add(childNode);
                    values.Add(key, valueNodes);
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(ValidateRepeatingNodes(tree, childNode, module));
                }
            }

            // check keys in dictionary with count more than 1
            foreach (string key in values.Keys) {
                List<TreeNode> listNodes = values[key];
                if (listNodes.Count > 1) {
                    BuildLogMessage message = new BuildLogMessage();
                    message.Message = "Duplicate node found with name :" + key +". Node path: "+node.FullPath;
                    message.Type = LogType.ERROR;
                    message.Module = module;
                    messages.Add(message);
                }
            }
            return messages;
        }

        private static List<BuildLogMessage> CheckFileSrc(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            List<TreeNode> errorNodes = new List<TreeNode>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                ComponentNode componentNode = (ComponentNode)childNode.Tag;
                if (componentNode.Type == ComponentType.File) {
                    if (File.Exists(componentNode.Property.SourcePath) == false) {
                        errorNodes.Add(childNode);
                    }
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(CheckFileSrc(tree, childNode, module));
                }
            }

            // add messages
            foreach (TreeNode errorNode in errorNodes) {
                BuildLogMessage message = new BuildLogMessage();
                message.Message = "Source file not found:" + errorNode.Text + ". (" + errorNode.FullPath + ")";
                message.Type = LogType.ERROR;
                message.Module = module;
                messages.Add(message);
            }
            return messages;
        }

        private static List<BuildLogMessage> CheckLength(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            List<TreeNode> errorNodes = new List<TreeNode>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                if (childNode.Text.Length > Common.MaxPropertyLength) {
                    errorNodes.Add(childNode);
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(CheckLength(tree, childNode, module));
                }
            }

            foreach (TreeNode errorNode in errorNodes) {
                BuildLogMessage message = new BuildLogMessage();
                message.Message = "Node length is more than set limit:" + Common.MaxPropertyLength;
                message.Type = LogType.ERROR;
                message.Module = module;
                messages.Add(message);
            }
            return messages;
        }

        private static List<BuildLogMessage> CheckAcceptableChars(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            List<TreeNode> errorNodes = new List<TreeNode>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                if (ContainsInvalidChar(childNode.Text)) {
                    errorNodes.Add(childNode);
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(CheckAcceptableChars(tree, childNode, module));
                }
            }

            foreach (TreeNode errorNode in errorNodes) {
                BuildLogMessage message = new BuildLogMessage();
                message.Message = "Node length is more than set limit:" + Common.MaxPropertyLength;
                message.Type = LogType.ERROR;
                message.Module = module;
                messages.Add(message);
            }
            return messages;
        }

        private static List<BuildLogMessage> CheckSystemFolderNames(TreeView tree, TreeNode node, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            List<TreeNode> errorNodes = new List<TreeNode>();
            TreeNodeCollection nodes = node == null ? tree.Nodes : node.Nodes;

            foreach (TreeNode childNode in nodes) {
                if (IsSystemFolderName(childNode.Text)) {
                    errorNodes.Add(childNode);
                }
                if (childNode.Nodes.Count > 0) {
                    messages.AddRange(CheckSystemFolderNames(tree, childNode, module));
                }
            }

            // add messages
            foreach (TreeNode errorNode in errorNodes) {
                BuildLogMessage message = new BuildLogMessage();
                message.Message = "System folder name used:" + errorNode.Text;
                message.Type = LogType.ERROR;
                message.Module = module;
                messages.Add(message);
            }
            return messages;
        }

        private static bool ContainsInvalidChar(string value) {
            if (value.Contains("`"))
                return true;
            if (value.Contains("$"))
                return true;
            return false;
        }

        public static BuildLogMessage ContainsInvalidChar(string value, string name, LogType errorType) {
            if (ContainsInvalidChar(value)) {
                BuildLogMessage logMessage = new BuildLogMessage();
                logMessage.Message = name + " contains invalid character";
                logMessage.Type = errorType;

                return logMessage;
            }
            return null;
        }

        public static List<BuildLogMessage> ContainsInvalidChar(string[] values, string[] names, LogType errorType, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            for (int i = 0; i < values.Length; i++) {
                string value = values[i];
                string name = names[i];
                if (ContainsInvalidChar(value)) {
                    BuildLogMessage logMessage = new BuildLogMessage();
                    logMessage.Message = name + " contains invalid character";
                    logMessage.Type = errorType;
                    logMessage.Module = module;

                    messages.Add(logMessage);
                }
            }
            return messages;
        }

        private static bool IsSystemFolderName(string name) {
            if (name.Equals("[Product Name]")) {
                return true;
            } else if (name.Equals("[Program Files]")) {
                return true;
            } else if (name.Equals("[Manufacturer]")) {
                return true;
            } else if (name.Equals("[Start Menu]", StringComparison.OrdinalIgnoreCase)) {
                return true;
            } else if (name.Equals("[Desktop]", StringComparison.OrdinalIgnoreCase)) {
                return true;
            }
            return false;
        }

        public static BuildLogMessage ValidateUrl(string name, string url, Modules module) {
            string strRegex = "^(https?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
                + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                + "|" // allows either IP or domain
                + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
                + "[a-z]{2,6})" // first level domain- .com or .museum
                + "(:[0-9]{1,4})?" // port number- :80
                + "((/?)|" // a slash isn't required if there is no file name
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(url) == false) {
                BuildLogMessage logMessage = new BuildLogMessage();
                logMessage.Message = name + " [" + url + "]" + " is invalid Or empty.";
                logMessage.Type = LogType.Warning;
                logMessage.Module = module;

                return logMessage;
            }
            return null;
        }

        private static Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
        public static BuildLogMessage ValidateGuid(string candidate, string idName) {
            if (String.IsNullOrEmpty(candidate) || isGuid.IsMatch(candidate) == false) {
                BuildLogMessage logMessage = new BuildLogMessage();
                logMessage.Message = idName + " is not valid";
                logMessage.Type = LogType.ERROR;

                return logMessage;
            }
            return null;
        }

        public static BuildLogMessage IsNullOrEmpty(string value, string name, LogType errorType, Modules module) {
            if (String.IsNullOrEmpty(value)) {
                BuildLogMessage logMessage = new BuildLogMessage();
                logMessage.Message = name + " is empty";
                logMessage.Type = errorType;
                logMessage.Module = module;

                return logMessage;
            }
            return null;
        }

        public static List<BuildLogMessage> IsNullOrEmpty(string[] values, string[] names, LogType errorType, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            for (int i = 0; i < values.Length; i++) {
                string name = names[i];
                string value = values[i];
                if (String.IsNullOrEmpty(value)) {
                    BuildLogMessage logMessage = new BuildLogMessage();
                    logMessage.Message = name + " is empty";
                    logMessage.Type = errorType;
                    logMessage.Module = module;

                    messages.Add(logMessage);
                }
            }

            return messages;
        }

        public static List<BuildLogMessage> ValidatePropertyLength(string[] values, string[] names, LogType errorType, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            for (int i = 0; i < values.Length; i++) {
                string name = names[i];
                string value = values[i];
                if (value.Length > Common.MaxPropertyLength) {
                    BuildLogMessage logMessage = new BuildLogMessage();
                    logMessage.Message = name + " length is more than the set limit: " + Common.MaxPropertyLength;
                    logMessage.Type = errorType;
                    logMessage.Module = module;

                    messages.Add(logMessage);
                }
            }

            return messages;
        }

        public static List<BuildLogMessage> ValidateDescriptionLength(string[] values, string[] names, LogType errorType, Modules module) {
            List<BuildLogMessage> messages = new List<BuildLogMessage>();
            for (int i = 0; i < values.Length; i++) {
                string name = names[i];
                string value = values[i];
                if (value.Length > Common.MaxDescriptionLength) {
                    BuildLogMessage logMessage = new BuildLogMessage();
                    logMessage.Message = name + " length is more than the set limit: " + Common.MaxDescriptionLength;
                    logMessage.Type = errorType;
                    logMessage.Module = module;

                    messages.Add(logMessage);
                }
            }

            return messages;
        }

        public static BuildLogMessage ValidateVersionNumber(string version) {
            BuildLogMessage logMessage = new BuildLogMessage();
            logMessage.Message = String.Format("Version {0} number is not in valid format", version);
            logMessage.Type = LogType.ERROR;
            logMessage.Module = Modules.ProductInformation;
            string[] versionParts = version.Split(".".ToCharArray());
            if (versionParts.Length > 4) {
                return logMessage;
            }
            foreach (string versionPart in versionParts) {
                int result = 0;
                if (Int32.TryParse(versionPart, out result) == false)
                    return logMessage;
            }
            return null;
        }

        public static List<BuildLogMessage> ValidateRepeatingItems(List<string> values, string text, LogType type, Modules module) {
            List<BuildLogMessage> logMessages = new List<BuildLogMessage>();
            foreach (string value in values) {
                int count = 0;
                foreach (string val in values) {
                    if (val == value) {
                        count++;
                    }
                }
                if (count > 1) {
                    BuildLogMessage buildMessage = new BuildLogMessage();
                    buildMessage.Message = String.Format(text, value);
                    buildMessage.Type = type;
                    buildMessage.Module = module;
                    logMessages.Add(buildMessage);
                }
            }
            return null;
        }
    }
}
