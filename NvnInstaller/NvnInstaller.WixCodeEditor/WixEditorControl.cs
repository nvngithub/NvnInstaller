using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fireball.CodeEditor.SyntaxFiles;

namespace NvnInstaller.WixCodeEditor {
    public partial class WixEditorControl : UserControl {
        public WixEditorControl() {
            InitializeComponent();

            CodeEditorSyntaxLoader.SetSyntax(codeEditorControl, SyntaxLanguage.XML);
        }
    }
}
