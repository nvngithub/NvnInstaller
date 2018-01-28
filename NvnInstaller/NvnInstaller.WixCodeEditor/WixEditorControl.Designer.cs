namespace NvnInstaller.WixCodeEditor {
    partial class WixEditorControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            Fireball.Windows.Forms.LineMarginRender lineMarginRender1 = new Fireball.Windows.Forms.LineMarginRender();
            this.codeEditorControl = new Fireball.Windows.Forms.CodeEditorControl();
            this.syntaxDocument1 = new Fireball.Syntax.SyntaxDocument(this.components);
            this.SuspendLayout();
            // 
            // codeEditorControl
            // 
            this.codeEditorControl.ActiveView = Fireball.Windows.Forms.CodeEditor.ActiveView.BottomRight;
            this.codeEditorControl.AutoListPosition = null;
            this.codeEditorControl.AutoListSelectedText = "";
            this.codeEditorControl.AutoListVisible = false;
            this.codeEditorControl.CopyAsRTF = false;
            this.codeEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorControl.Document = this.syntaxDocument1;
            this.codeEditorControl.InfoTipCount = 1;
            this.codeEditorControl.InfoTipPosition = null;
            this.codeEditorControl.InfoTipSelectedIndex = 0;
            this.codeEditorControl.InfoTipVisible = false;
            lineMarginRender1.Bounds = new System.Drawing.Rectangle(19, 0, 19, 16);
            this.codeEditorControl.LineMarginRender = lineMarginRender1;
            this.codeEditorControl.Location = new System.Drawing.Point(0, 0);
            this.codeEditorControl.LockCursorUpdate = false;
            this.codeEditorControl.Name = "codeEditorControl";
            this.codeEditorControl.Saved = false;
            this.codeEditorControl.ShowScopeIndicator = false;
            this.codeEditorControl.Size = new System.Drawing.Size(746, 512);
            this.codeEditorControl.SmoothScroll = false;
            this.codeEditorControl.SplitviewH = -4;
            this.codeEditorControl.SplitviewV = -4;
            this.codeEditorControl.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.codeEditorControl.TabIndex = 0;
            this.codeEditorControl.Text = "codeEditorControl1";
            this.codeEditorControl.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // EditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.codeEditorControl);
            this.Name = "EditorControl";
            this.Size = new System.Drawing.Size(746, 512);
            this.ResumeLayout(false);

        }

        #endregion

        private Fireball.Windows.Forms.CodeEditorControl codeEditorControl;
        private Fireball.Syntax.SyntaxDocument syntaxDocument1;
    }
}
