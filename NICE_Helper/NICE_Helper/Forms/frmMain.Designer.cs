namespace NICE_Helper
{
    partial class frmMain
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.cmdLogFilesFind = new System.Windows.Forms.Button();
            this.cmdLogFilesExtract = new System.Windows.Forms.Button();
            this.chkIncludeConfigs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConfigs = new System.Windows.Forms.Label();
            this.lblLogs = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.sStrip = new System.Windows.Forms.StatusStrip();
            this.ssTextBox = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblOpen = new System.Windows.Forms.Label();
            this.MyTabControl = new System.Windows.Forms.TabControl();
            this.tabRTLogs = new System.Windows.Forms.TabPage();
            this.tabProjectFiles = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblZippedFolder = new System.Windows.Forms.Label();
            this.lblZippedFound = new System.Windows.Forms.Label();
            this.lblZippedMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdProjFilesUnzip = new System.Windows.Forms.Button();
            this.cmdProjFilesFind = new System.Windows.Forms.Button();
            this.tabAppDataFolders = new System.Windows.Forms.TabPage();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.lblAppDataMesage = new System.Windows.Forms.Label();
            this.lblAppDataInstructions = new System.Windows.Forms.Label();
            this.cmdAppDataDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdAppDataFilesFind = new System.Windows.Forms.Button();
            this.dgvAppsDataFolders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.sStrip.SuspendLayout();
            this.MyTabControl.SuspendLayout();
            this.tabRTLogs.SuspendLayout();
            this.tabProjectFiles.SuspendLayout();
            this.tabAppDataFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppsDataFolders)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdClose.Location = new System.Drawing.Point(658, 767);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 43);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(25, 12);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(737, 481);
            this.dgvHistory.TabIndex = 1;
            this.dgvHistory.TabStop = false;
            this.dgvHistory.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellContentDoubleClick);
            // 
            // cmdLogFilesFind
            // 
            this.cmdLogFilesFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLogFilesFind.Location = new System.Drawing.Point(326, 125);
            this.cmdLogFilesFind.Name = "cmdLogFilesFind";
            this.cmdLogFilesFind.Size = new System.Drawing.Size(100, 28);
            this.cmdLogFilesFind.TabIndex = 11;
            this.cmdLogFilesFind.Text = "Identify";
            this.cmdLogFilesFind.UseVisualStyleBackColor = true;
            this.cmdLogFilesFind.Click += new System.EventHandler(this.cmdLogFilesFind_Click);
            // 
            // cmdLogFilesExtract
            // 
            this.cmdLogFilesExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLogFilesExtract.Enabled = false;
            this.cmdLogFilesExtract.Location = new System.Drawing.Point(326, 167);
            this.cmdLogFilesExtract.Name = "cmdLogFilesExtract";
            this.cmdLogFilesExtract.Size = new System.Drawing.Size(100, 28);
            this.cmdLogFilesExtract.TabIndex = 12;
            this.cmdLogFilesExtract.TabStop = false;
            this.cmdLogFilesExtract.Text = "Extract";
            this.cmdLogFilesExtract.UseVisualStyleBackColor = true;
            this.cmdLogFilesExtract.Click += new System.EventHandler(this.cmdLogFilesExtract_Click);
            // 
            // chkIncludeConfigs
            // 
            this.chkIncludeConfigs.AutoSize = true;
            this.chkIncludeConfigs.Location = new System.Drawing.Point(432, 134);
            this.chkIncludeConfigs.Name = "chkIncludeConfigs";
            this.chkIncludeConfigs.Size = new System.Drawing.Size(152, 21);
            this.chkIncludeConfigs.TabIndex = 14;
            this.chkIncludeConfigs.TabStop = false;
            this.chkIncludeConfigs.Text = "Include Config Files";
            this.chkIncludeConfigs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(323, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 71);
            this.label1.TabIndex = 3;
            this.label1.Text = "Returns a list of RT Logs from each Roaming Profile on this PC.  Can include any " +
    "RT Config files if required.  Thes files can be zipped and exported by using the" +
    " Extract button.";
            // 
            // lblConfigs
            // 
            this.lblConfigs.AutoSize = true;
            this.lblConfigs.Location = new System.Drawing.Point(48, 100);
            this.lblConfigs.Name = "lblConfigs";
            this.lblConfigs.Size = new System.Drawing.Size(70, 17);
            this.lblConfigs.TabIndex = 2;
            this.lblConfigs.Text = "See Code";
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(48, 73);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(70, 17);
            this.lblLogs.TabIndex = 1;
            this.lblLogs.Text = "See Code";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(48, 46);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(70, 17);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "See Code";
            // 
            // sStrip
            // 
            this.sStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssTextBox,
            this.ProgressBar});
            this.sStrip.Location = new System.Drawing.Point(0, 897);
            this.sStrip.Name = "sStrip";
            this.sStrip.Size = new System.Drawing.Size(787, 29);
            this.sStrip.SizingGrip = false;
            this.sStrip.TabIndex = 13;
            this.sStrip.Text = "statusStrip1";
            // 
            // ssTextBox
            // 
            this.ssTextBox.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ssTextBox.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.ssTextBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ssTextBox.Name = "ssTextBox";
            this.ssTextBox.Size = new System.Drawing.Size(570, 24);
            this.ssTextBox.Spring = true;
            this.ssTextBox.Text = "see code";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(200, 23);
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpen.Location = new System.Drawing.Point(471, 16);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(238, 17);
            this.lblOpen.TabIndex = 4;
            this.lblOpen.Text = "* Double Click on a file to open.";
            this.lblOpen.Visible = false;
            // 
            // MyTabControl
            // 
            this.MyTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MyTabControl.Controls.Add(this.tabRTLogs);
            this.MyTabControl.Controls.Add(this.tabProjectFiles);
            this.MyTabControl.Controls.Add(this.tabAppDataFolders);
            this.MyTabControl.Location = new System.Drawing.Point(21, 500);
            this.MyTabControl.Name = "MyTabControl";
            this.MyTabControl.SelectedIndex = 0;
            this.MyTabControl.Size = new System.Drawing.Size(741, 251);
            this.MyTabControl.TabIndex = 17;
            this.MyTabControl.SelectedIndexChanged += new System.EventHandler(this.MyTabControl_SelectedIndexChanged);
            // 
            // tabRTLogs
            // 
            this.tabRTLogs.Controls.Add(this.chkIncludeConfigs);
            this.tabRTLogs.Controls.Add(this.cmdLogFilesExtract);
            this.tabRTLogs.Controls.Add(this.lblOpen);
            this.tabRTLogs.Controls.Add(this.label1);
            this.tabRTLogs.Controls.Add(this.cmdLogFilesFind);
            this.tabRTLogs.Controls.Add(this.lblUsers);
            this.tabRTLogs.Controls.Add(this.lblLogs);
            this.tabRTLogs.Controls.Add(this.lblConfigs);
            this.tabRTLogs.Location = new System.Drawing.Point(4, 25);
            this.tabRTLogs.Name = "tabRTLogs";
            this.tabRTLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabRTLogs.Size = new System.Drawing.Size(733, 222);
            this.tabRTLogs.TabIndex = 0;
            this.tabRTLogs.Text = "RT Logs";
            this.tabRTLogs.UseVisualStyleBackColor = true;
            // 
            // tabProjectFiles
            // 
            this.tabProjectFiles.Controls.Add(this.label3);
            this.tabProjectFiles.Controls.Add(this.lblZippedFolder);
            this.tabProjectFiles.Controls.Add(this.lblZippedFound);
            this.tabProjectFiles.Controls.Add(this.lblZippedMessage);
            this.tabProjectFiles.Controls.Add(this.label2);
            this.tabProjectFiles.Controls.Add(this.cmdProjFilesUnzip);
            this.tabProjectFiles.Controls.Add(this.cmdProjFilesFind);
            this.tabProjectFiles.Location = new System.Drawing.Point(4, 25);
            this.tabProjectFiles.Name = "tabProjectFiles";
            this.tabProjectFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjectFiles.Size = new System.Drawing.Size(733, 222);
            this.tabProjectFiles.TabIndex = 1;
            this.tabProjectFiles.Text = "Project Files";
            this.tabProjectFiles.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 71);
            this.label3.TabIndex = 6;
            this.label3.Text = "Returns a list of Compressed RT Designer Project files.  Any found files can then" +
    " be un-zipped.";
            // 
            // lblZippedFolder
            // 
            this.lblZippedFolder.AutoSize = true;
            this.lblZippedFolder.Location = new System.Drawing.Point(337, 16);
            this.lblZippedFolder.Name = "lblZippedFolder";
            this.lblZippedFolder.Size = new System.Drawing.Size(66, 17);
            this.lblZippedFolder.TabIndex = 5;
            this.lblZippedFolder.Text = "see code";
            this.lblZippedFolder.Visible = false;
            // 
            // lblZippedFound
            // 
            this.lblZippedFound.AutoSize = true;
            this.lblZippedFound.Location = new System.Drawing.Point(337, 42);
            this.lblZippedFound.Name = "lblZippedFound";
            this.lblZippedFound.Size = new System.Drawing.Size(66, 17);
            this.lblZippedFound.TabIndex = 4;
            this.lblZippedFound.Text = "see code";
            this.lblZippedFound.Visible = false;
            // 
            // lblZippedMessage
            // 
            this.lblZippedMessage.AutoSize = true;
            this.lblZippedMessage.Location = new System.Drawing.Point(337, 77);
            this.lblZippedMessage.Name = "lblZippedMessage";
            this.lblZippedMessage.Size = new System.Drawing.Size(254, 17);
            this.lblZippedMessage.TabIndex = 3;
            this.lblZippedMessage.Text = "Uncompress the above RT Project files";
            this.lblZippedMessage.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Find compressed RT Project files";
            // 
            // cmdProjFilesUnzip
            // 
            this.cmdProjFilesUnzip.Enabled = false;
            this.cmdProjFilesUnzip.Location = new System.Drawing.Point(608, 77);
            this.cmdProjFilesUnzip.Name = "cmdProjFilesUnzip";
            this.cmdProjFilesUnzip.Size = new System.Drawing.Size(95, 30);
            this.cmdProjFilesUnzip.TabIndex = 1;
            this.cmdProjFilesUnzip.Text = "Unzip...";
            this.cmdProjFilesUnzip.UseVisualStyleBackColor = true;
            this.cmdProjFilesUnzip.Click += new System.EventHandler(this.cmdProjFilesUnzip_Click);
            // 
            // cmdProjFilesFind
            // 
            this.cmdProjFilesFind.Location = new System.Drawing.Point(145, 42);
            this.cmdProjFilesFind.Name = "cmdProjFilesFind";
            this.cmdProjFilesFind.Size = new System.Drawing.Size(95, 30);
            this.cmdProjFilesFind.TabIndex = 0;
            this.cmdProjFilesFind.Text = "Find...";
            this.cmdProjFilesFind.UseVisualStyleBackColor = true;
            this.cmdProjFilesFind.Click += new System.EventHandler(this.cmdProjFilesFind_Click);
            // 
            // tabAppDataFolders
            // 
            this.tabAppDataFolders.Controls.Add(this.chkSelectAll);
            this.tabAppDataFolders.Controls.Add(this.lblAppDataMesage);
            this.tabAppDataFolders.Controls.Add(this.lblAppDataInstructions);
            this.tabAppDataFolders.Controls.Add(this.cmdAppDataDelete);
            this.tabAppDataFolders.Controls.Add(this.label4);
            this.tabAppDataFolders.Controls.Add(this.cmdAppDataFilesFind);
            this.tabAppDataFolders.Location = new System.Drawing.Point(4, 25);
            this.tabAppDataFolders.Name = "tabAppDataFolders";
            this.tabAppDataFolders.Size = new System.Drawing.Size(733, 222);
            this.tabAppDataFolders.TabIndex = 2;
            this.tabAppDataFolders.Text = "AppData Folders";
            this.tabAppDataFolders.UseVisualStyleBackColor = true;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(30, 159);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(148, 21);
            this.chkSelectAll.TabIndex = 17;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Select/unselect all.";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblAppDataMesage
            // 
            this.lblAppDataMesage.AutoSize = true;
            this.lblAppDataMesage.Location = new System.Drawing.Point(27, 97);
            this.lblAppDataMesage.Name = "lblAppDataMesage";
            this.lblAppDataMesage.Size = new System.Drawing.Size(70, 17);
            this.lblAppDataMesage.TabIndex = 16;
            this.lblAppDataMesage.Text = "See Code";
            this.lblAppDataMesage.Visible = false;
            // 
            // lblAppDataInstructions
            // 
            this.lblAppDataInstructions.AutoSize = true;
            this.lblAppDataInstructions.Location = new System.Drawing.Point(27, 123);
            this.lblAppDataInstructions.Name = "lblAppDataInstructions";
            this.lblAppDataInstructions.Size = new System.Drawing.Size(359, 17);
            this.lblAppDataInstructions.TabIndex = 15;
            this.lblAppDataInstructions.Text = "Select from the list the Real-Time Folders to be deleted.";
            this.lblAppDataInstructions.Visible = false;
            // 
            // cmdAppDataDelete
            // 
            this.cmdAppDataDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAppDataDelete.Enabled = false;
            this.cmdAppDataDelete.Location = new System.Drawing.Point(479, 91);
            this.cmdAppDataDelete.Name = "cmdAppDataDelete";
            this.cmdAppDataDelete.Size = new System.Drawing.Size(100, 28);
            this.cmdAppDataDelete.TabIndex = 14;
            this.cmdAppDataDelete.Text = "Delete";
            this.cmdAppDataDelete.UseVisualStyleBackColor = true;
            this.cmdAppDataDelete.Click += new System.EventHandler(this.cmdAppDataDelete_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(411, 41);
            this.label4.TabIndex = 13;
            this.label4.Text = "Returns a list of AppData Directories (Roaming Profiles) that contain a Real-Time" +
    " Folder.   These can (optionally) be deleted.";
            // 
            // cmdAppDataFilesFind
            // 
            this.cmdAppDataFilesFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAppDataFilesFind.Location = new System.Drawing.Point(479, 26);
            this.cmdAppDataFilesFind.Name = "cmdAppDataFilesFind";
            this.cmdAppDataFilesFind.Size = new System.Drawing.Size(100, 28);
            this.cmdAppDataFilesFind.TabIndex = 12;
            this.cmdAppDataFilesFind.Text = "Identify";
            this.cmdAppDataFilesFind.UseVisualStyleBackColor = true;
            this.cmdAppDataFilesFind.Click += new System.EventHandler(this.cmdAppDataFilesFind_Click);
            // 
            // dgvAppsDataFolders
            // 
            this.dgvAppsDataFolders.AllowUserToAddRows = false;
            this.dgvAppsDataFolders.AllowUserToDeleteRows = false;
            this.dgvAppsDataFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppsDataFolders.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAppsDataFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppsDataFolders.Location = new System.Drawing.Point(25, 14);
            this.dgvAppsDataFolders.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAppsDataFolders.MultiSelect = false;
            this.dgvAppsDataFolders.Name = "dgvAppsDataFolders";
            this.dgvAppsDataFolders.RowHeadersVisible = false;
            this.dgvAppsDataFolders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAppsDataFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAppsDataFolders.Size = new System.Drawing.Size(737, 479);
            this.dgvAppsDataFolders.TabIndex = 18;
            this.dgvAppsDataFolders.TabStop = false;
            this.dgvAppsDataFolders.Visible = false;
            this.dgvAppsDataFolders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppsDataFolders_CellClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 926);
            this.ControlBox = false;
            this.Controls.Add(this.dgvAppsDataFolders);
            this.Controls.Add(this.MyTabControl);
            this.Controls.Add(this.sStrip);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVL RT Logs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.sStrip.ResumeLayout(false);
            this.sStrip.PerformLayout();
            this.MyTabControl.ResumeLayout(false);
            this.tabRTLogs.ResumeLayout(false);
            this.tabRTLogs.PerformLayout();
            this.tabProjectFiles.ResumeLayout(false);
            this.tabProjectFiles.PerformLayout();
            this.tabAppDataFolders.ResumeLayout(false);
            this.tabAppDataFolders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppsDataFolders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button cmdLogFilesFind;
        private System.Windows.Forms.Button cmdLogFilesExtract;
        private System.Windows.Forms.CheckBox chkIncludeConfigs;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.StatusStrip sStrip;
        private System.Windows.Forms.ToolStripStatusLabel ssTextBox;
        private System.Windows.Forms.Label lblConfigs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.TabControl MyTabControl;
        private System.Windows.Forms.TabPage tabRTLogs;
        private System.Windows.Forms.TabPage tabProjectFiles;
        private System.Windows.Forms.Button cmdProjFilesUnzip;
        private System.Windows.Forms.Button cmdProjFilesFind;
        private System.Windows.Forms.Label lblZippedFound;
        private System.Windows.Forms.Label lblZippedMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblZippedFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabAppDataFolders;
        private System.Windows.Forms.DataGridView dgvAppsDataFolders;
        private System.Windows.Forms.Label lblAppDataInstructions;
        private System.Windows.Forms.Button cmdAppDataDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdAppDataFilesFind;
        private System.Windows.Forms.Label lblAppDataMesage;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}