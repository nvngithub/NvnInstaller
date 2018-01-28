namespace NvnInstaller.Scheduler
{
    partial class ScheduleItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.chkListDays = new System.Windows.Forms.CheckedListBox();
            this.chkListMonths = new System.Windows.Forms.CheckedListBox();
            this.dgrExcludeDates = new System.Windows.Forms.DataGridView();
            this.dtpExcludeDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddExcludeTime = new System.Windows.Forms.Button();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dgrTimes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRootFolder = new System.Windows.Forms.Label();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseProjectFile = new System.Windows.Forms.Button();
            this.txtProjectFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNameFormat = new System.Windows.Forms.ComboBox();
            this.cmbDateFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseRoot = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ExcludeTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrExcludeDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTimes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(258, 494);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkListDays
            // 
            this.chkListDays.CheckOnClick = true;
            this.chkListDays.FormattingEnabled = true;
            this.chkListDays.Items.AddRange(new object[] {
            "All",
            "Sunday",
            "Monday",
            "Tuesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.chkListDays.Location = new System.Drawing.Point(6, 32);
            this.chkListDays.Name = "chkListDays";
            this.chkListDays.Size = new System.Drawing.Size(97, 124);
            this.chkListDays.TabIndex = 1;
            this.chkListDays.ThreeDCheckBoxes = true;
            this.chkListDays.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListDays_ItemCheck);
            // 
            // chkListMonths
            // 
            this.chkListMonths.CheckOnClick = true;
            this.chkListMonths.FormattingEnabled = true;
            this.chkListMonths.Items.AddRange(new object[] {
            "All",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.chkListMonths.Location = new System.Drawing.Point(109, 32);
            this.chkListMonths.Name = "chkListMonths";
            this.chkListMonths.Size = new System.Drawing.Size(97, 124);
            this.chkListMonths.TabIndex = 2;
            this.chkListMonths.ThreeDCheckBoxes = true;
            this.chkListMonths.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListMonths_ItemCheck);
            // 
            // dgrExcludeDates
            // 
            this.dgrExcludeDates.AllowUserToAddRows = false;
            this.dgrExcludeDates.AllowUserToResizeColumns = false;
            this.dgrExcludeDates.AllowUserToResizeRows = false;
            this.dgrExcludeDates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrExcludeDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrExcludeDates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExcludeTimeColumn});
            this.dgrExcludeDates.Location = new System.Drawing.Point(6, 45);
            this.dgrExcludeDates.Name = "dgrExcludeDates";
            this.dgrExcludeDates.ReadOnly = true;
            this.dgrExcludeDates.RowHeadersVisible = false;
            this.dgrExcludeDates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrExcludeDates.Size = new System.Drawing.Size(383, 98);
            this.dgrExcludeDates.TabIndex = 3;
            // 
            // dtpExcludeDate
            // 
            this.dtpExcludeDate.CustomFormat = "";
            this.dtpExcludeDate.Location = new System.Drawing.Point(6, 19);
            this.dtpExcludeDate.Name = "dtpExcludeDate";
            this.dtpExcludeDate.Size = new System.Drawing.Size(193, 20);
            this.dtpExcludeDate.TabIndex = 4;
            // 
            // btnAddExcludeTime
            // 
            this.btnAddExcludeTime.Location = new System.Drawing.Point(205, 16);
            this.btnAddExcludeTime.Name = "btnAddExcludeTime";
            this.btnAddExcludeTime.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcludeTime.TabIndex = 5;
            this.btnAddExcludeTime.Text = "Add";
            this.btnAddExcludeTime.UseVisualStyleBackColor = true;
            this.btnAddExcludeTime.Click += new System.EventHandler(this.btnAddExcludeDate_Click);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(309, 29);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(75, 23);
            this.btnAddTime.TabIndex = 8;
            this.btnAddTime.Text = "Add";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "h:mm tt";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(212, 32);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(91, 20);
            this.dtpTime.TabIndex = 7;
            // 
            // dgrTimes
            // 
            this.dgrTimes.AllowUserToAddRows = false;
            this.dgrTimes.AllowUserToResizeColumns = false;
            this.dgrTimes.AllowUserToResizeRows = false;
            this.dgrTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgrTimes.Location = new System.Drawing.Point(212, 58);
            this.dgrTimes.Name = "dgrTimes";
            this.dgrTimes.ReadOnly = true;
            this.dgrTimes.RowHeadersVisible = false;
            this.dgrTimes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrTimes.Size = new System.Drawing.Size(177, 98);
            this.dgrTimes.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Selected Times";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lblRootFolder
            // 
            this.lblRootFolder.AutoSize = true;
            this.lblRootFolder.Location = new System.Drawing.Point(50, 19);
            this.lblRootFolder.Name = "lblRootFolder";
            this.lblRootFolder.Size = new System.Drawing.Size(62, 13);
            this.lblRootFolder.TabIndex = 9;
            this.lblRootFolder.Text = "Root Folder";
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Location = new System.Drawing.Point(118, 19);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(185, 20);
            this.txtRootFolder.TabIndex = 10;
            // 
            // btnBrowseProjectFile
            // 
            this.btnBrowseProjectFile.Location = new System.Drawing.Point(339, 3);
            this.btnBrowseProjectFile.Name = "btnBrowseProjectFile";
            this.btnBrowseProjectFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseProjectFile.TabIndex = 11;
            this.btnBrowseProjectFile.Text = "Browse...";
            this.btnBrowseProjectFile.UseVisualStyleBackColor = true;
            this.btnBrowseProjectFile.Click += new System.EventHandler(this.btnBrowseProjectFile_Click);
            // 
            // txtProjectFile
            // 
            this.txtProjectFile.Location = new System.Drawing.Point(77, 6);
            this.txtProjectFile.Name = "txtProjectFile";
            this.txtProjectFile.ReadOnly = true;
            this.txtProjectFile.Size = new System.Drawing.Size(256, 20);
            this.txtProjectFile.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Project File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Folder name format";
            // 
            // cmbNameFormat
            // 
            this.cmbNameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameFormat.FormattingEnabled = true;
            this.cmbNameFormat.Location = new System.Drawing.Point(118, 58);
            this.cmbNameFormat.Name = "cmbNameFormat";
            this.cmbNameFormat.Size = new System.Drawing.Size(243, 21);
            this.cmbNameFormat.TabIndex = 15;
            // 
            // cmbDateFormat
            // 
            this.cmbDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateFormat.FormattingEnabled = true;
            this.cmbDateFormat.Location = new System.Drawing.Point(118, 85);
            this.cmbDateFormat.Name = "cmbDateFormat";
            this.cmbDateFormat.Size = new System.Drawing.Size(243, 21);
            this.cmbDateFormat.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Date format";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseRoot);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbDateFormat);
            this.groupBox1.Controls.Add(this.lblRootFolder);
            this.groupBox1.Controls.Add(this.txtRootFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbNameFormat);
            this.groupBox1.Location = new System.Drawing.Point(15, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 119);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // btnBrowseRoot
            // 
            this.btnBrowseRoot.Location = new System.Drawing.Point(309, 19);
            this.btnBrowseRoot.Name = "btnBrowseRoot";
            this.btnBrowseRoot.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseRoot.TabIndex = 24;
            this.btnBrowseRoot.Text = "Browse...";
            this.btnBrowseRoot.UseVisualStyleBackColor = true;
            this.btnBrowseRoot.Click += new System.EventHandler(this.btnBrowseRoot_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "(Example:- c:\\Test\\Output Folder)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Days";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Months";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.chkListDays);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkListMonths);
            this.groupBox2.Controls.Add(this.dgrTimes);
            this.groupBox2.Controls.Add(this.btnAddTime);
            this.groupBox2.Controls.Add(this.dtpTime);
            this.groupBox2.Location = new System.Drawing.Point(15, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 167);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schedule";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Schedule a build @";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgrExcludeDates);
            this.groupBox3.Controls.Add(this.dtpExcludeDate);
            this.groupBox3.Controls.Add(this.btnAddExcludeTime);
            this.groupBox3.Location = new System.Drawing.Point(15, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 157);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exclude specific dates";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(339, 494);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ExcludeTimeColumn
            // 
            this.ExcludeTimeColumn.HeaderText = "Excluded dates";
            this.ExcludeTimeColumn.Name = "ExcludeTimeColumn";
            this.ExcludeTimeColumn.ReadOnly = true;
            // 
            // ScheduleItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(430, 527);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtProjectFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowseProjectFile);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScheduleItemForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.ScheduleItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrExcludeDates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTimes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox chkListDays;
        private System.Windows.Forms.CheckedListBox chkListMonths;
        private System.Windows.Forms.DataGridView dgrExcludeDates;
        private System.Windows.Forms.DateTimePicker dtpExcludeDate;
        private System.Windows.Forms.Button btnAddExcludeTime;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DataGridView dgrTimes;
        private System.Windows.Forms.Label lblRootFolder;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Button btnBrowseProjectFile;
        private System.Windows.Forms.TextBox txtProjectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNameFormat;
        private System.Windows.Forms.ComboBox cmbDateFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowseRoot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExcludeTimeColumn;
    }
}