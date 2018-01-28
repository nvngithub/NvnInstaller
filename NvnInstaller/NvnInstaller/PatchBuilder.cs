using System;
using System.Collections.Generic;
using System.Text;
using Wix = NvnInstaller.WixClasses;

namespace NvnInstaller {
    class PatchBuilder {

        public static List<string> ComponentIds = new List<string>();

        private static void Init() {
            ComponentIds.Clear();
        }

        public static void Build() {
            // Build original MSI file
            MsiBuilder.Build(BuildTypes.Msi);
            // Build MSI file with patch applied
            MsiBuilder.Build(BuildTypes.Patch);
            // Generate WiX xml code to build patch file
            // Create a transform between the two installation packages.            
            // Build Patch file
        }

        private void GenerateWixCodePatch() {
        }
    }
}
