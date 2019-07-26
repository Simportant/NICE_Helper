using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace NICE_Helper
{
    public partial class frmMain : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private FileIdentifier _foundFiles;
        private AppDataIdentifier _foundFolders;

        public frmMain()
        {
            InitializeComponent();
            
            try {
                log.Debug("Application Starting.....");

                this.Text = string.Concat(this.Text, " (Version ", System.Reflection.Assembly.GetEntryAssembly().GetName().Version, ")");
                // In run mode set info labels blank (rather than "See Code" which is visible in the Designer).
                this.lblUsers.Text = "";
                this.lblLogs.Text = "";
                this.lblConfigs.Text = "";
                this.lblZippedFolder.Text = "";
                this.lblZippedFound.Text = "";
                this.lblZippedMessage.Text = "";
                SetScreen();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLogFilesExtract_Click(object sender, EventArgs e)
        {
            try {
                string folder = string.Empty;

                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    DialogResult result = dlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        folder = dlg.SelectedPath;
                        folder = string.Concat(folder, @"\" + Environment.MachineName, @"\");
                    }
                }

                if (folder != string.Empty)
                {
                    RunExtract(folder);
                    MessageBox.Show("Log Extracted to: " + folder + @"\", Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName, " - Extract Complete");
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName, " - Extract Failed");
            }
        }
        private void cmdLogFilesFind_Click(object sender, EventArgs e)
        {
            try {
                SetScreen();
                IdentifyLogFiles();

                if ((_foundFiles != null) && (_foundFiles.CountUsers > 0))
                {
                    this.cmdLogFilesExtract.Enabled = true;
                    FillDataGrid();
                    this.lblUsers.Text = string.Concat("RT Users found: ", _foundFiles.CountUsers.ToString());
                    this.lblLogs.Text = string.Concat("Log files found: ", _foundFiles.CountLogs.ToString());
                    this.lblConfigs.Text = ( this.chkIncludeConfigs.Checked ? string.Concat("Config files found: ", _foundFiles.CountConfigs.ToString()) : string.Empty );
                    this.lblOpen.Visible = true;
                }
                else
                    this.lblUsers.Text = "No files found";
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName, " - Find Files Failed.");
            }
        }        
        
        private void cmdProjFilesFind_Click(object sender, EventArgs e)
        {
            try {

                string folder = string.Empty;

                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    // Not required when we are looking for specific files.
                    dlg.ShowNewFolderButton = false;
                    // If this is a re-run then start at the last location.
                    dlg.SelectedPath = this.lblZippedFolder.Text;

                    DialogResult result = dlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        folder = dlg.SelectedPath;
                        folder = string.Concat(folder, @"\");
                    }
                }
                
                if (folder != string.Empty)
                {                    
                    _foundFiles = new FileIdentifier(folder);

                    if ((_foundFiles != null) && (_foundFiles.CountFiles > 0))
                    {
                        SetScreen();
                        FillDataGrid();
                        this.lblZippedFolder.Text = folder;
                        this.lblZippedFolder.Visible = true;
                        this.lblZippedFound.Text = string.Concat("RT Designer Zipped Projects files: ", _foundFiles.CountFiles.ToString());
                        this.lblZippedFound.Visible = true;
                        this.lblZippedMessage.Visible = true;
                        this.cmdProjFilesUnzip.Enabled = true;
                    }
                    else
                        MessageBox.Show("No files found");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmdProjFilesUnzip_Click(object sender, EventArgs e)
        {
            try {

                // Use the FileWriter Class to uncompress compress each file in the folder.
                using (FileWriter fl = new FileWriter())
                {
                    DirectoryInfo di = new DirectoryInfo(this.lblZippedFolder.Text);
                    int result = fl.Uncompress(di);

                    switch (result)
                    {
                        case -1:
                            MessageBox.Show(@"An eror occurred, see the log");
                            break;
                            
                        case 0:                            
                            MessageBox.Show(@"7-Zip does not exists as expected, it should be here: C:\Program Files\7-Zip\7z.exe");
                            break;
                            
                        default:
                            MessageBox.Show(string.Concat(result.ToString(), " Project files extracted to ", string.Concat(di.FullName, @"Unzipped\")));
                            this.lblZippedMessage.Visible = false;
                            this.cmdProjFilesUnzip.Enabled = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdAppDataDelete_Click(object sender, EventArgs e)
        {
            try {

                if (_foundFolders.ReadyForDeletion)
                {
                    if (MessageBox.Show("Are you sure, this action cannot be undone?", Helper.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _foundFolders.RemoveSelectedItems();
                        MessageBox.Show("Folders deleted. Please refresh to confirm.", Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetScreen();
                    }
                }
                else
                    MessageBox.Show("Please select items for deletion!", Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cmdAppDataFilesFind_Click(object sender, EventArgs e)
        {
            try {

                SetScreen();
                _foundFolders = new AppDataIdentifier();
                
                if ((_foundFolders != null) && (_foundFolders.FoldersCount > 0))
                {
                    FillAppUserGrid();
                    this.lblAppDataInstructions.Visible = true;
                    this.lblAppDataMesage.Visible = true;
                    this.lblAppDataMesage.Text = string.Concat("Real-Time Folders found: ", _foundFolders.FoldersCount.ToString());
                    this.cmdAppDataDelete.Enabled = true;
                    this.chkSelectAll.Visible = true;
                }
                else
                {
                    this.lblAppDataMesage.Visible = true;
                    this.lblAppDataMesage.Text = "No Real-Time Folders found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MyTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetScreen();           
        }
        private void dgvHistory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            // Only allow this on the Logs Tab.
            if (this.MyTabControl.SelectedTab.Text != "RT Logs") { return; }

            try {
                string FileAndPath;
                FileAndPath = this.dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString() + @"\" + this.dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                var p = new Process();
                p.StartInfo.FileName = FileAndPath;
                p.Start();
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                MessageBox.Show(ex.Message, Helper.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvAppsDataFolders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && this.dgvAppsDataFolders.CurrentCell != null)
                _foundFolders.FlipSelectedFlag(this.dgvAppsDataFolders.Rows[e.RowIndex].Cells[1].Value.ToString());

        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_foundFolders != null)
                foreach (FileDetail ap in _foundFolders.FoldersFound)
                    ap.Selected = this.chkSelectAll.Checked;

            this.dgvAppsDataFolders.Refresh();
        }

        private void SetScreen()
        {
            // General
            _foundFolders = null;

            this.dgvHistory.DataSource = null;
            this.dgvHistory.Rows.Clear();
            this.dgvAppsDataFolders.DataSource = null;
            this.dgvAppsDataFolders.Rows.Clear();            
            this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName);

            if (this.MyTabControl.SelectedTab.Text == "AppData Folders")
            {
                // AppData Folders Tab.                
                this.lblAppDataMesage.Visible = false;
                this.lblAppDataInstructions.Visible = false;
                this.chkSelectAll.Checked = false;
                this.chkSelectAll.Visible = false;
                this.cmdAppDataDelete.Enabled = false;
                this.dgvHistory.Visible = false;
                this.dgvAppsDataFolders.Visible = true;
            }
            else
            {
                // RT Logs Tab
                this.cmdLogFilesExtract.Enabled = false;
                this.lblUsers.Text = string.Empty;
                this.lblLogs.Text = string.Empty;
                this.lblConfigs.Text = string.Empty;
                this.lblOpen.Visible = false;

                // Zipped Project Files Tab
                this.cmdProjFilesUnzip.Enabled = false;
                this.lblZippedFound.Text = string.Empty;
                this.lblZippedFound.Visible = false;
                this.lblZippedMessage.Visible = false;
                this.lblZippedFolder.Visible = false;
                this.dgvHistory.Visible = true;
                this.dgvAppsDataFolders.Visible = false;
            }
        }
        private void FillDataGrid()
        {
            this.dgvHistory.DataSource = _foundFiles.FilesFound;
            
            this.dgvHistory.Columns[0].HeaderText = "Selected";
            this.dgvHistory.Columns[0].DataPropertyName = "Selected";
            this.dgvHistory.Columns[0].Width = 0;
            this.dgvHistory.Columns[0].Visible = false;

            this.dgvHistory.Columns[1].HeaderText = "User";
            this.dgvHistory.Columns[1].DataPropertyName = "User";
            this.dgvHistory.Columns[1].Width = 130;
            this.dgvHistory.Columns[1].Visible = true;

            this.dgvHistory.Columns[2].HeaderText = "Path";
            this.dgvHistory.Columns[2].DataPropertyName = "Path";
            this.dgvHistory.Columns[2].Width = 0;
            this.dgvHistory.Columns[2].Visible = false;

            this.dgvHistory.Columns[3].HeaderText = "File";
            this.dgvHistory.Columns[3].DataPropertyName = "File";
            this.dgvHistory.Columns[3].Width = 120;
            this.dgvHistory.Columns[3].Visible = true;

            this.dgvHistory.Columns[4].HeaderText = "Date";
            this.dgvHistory.Columns[4].DataPropertyName = "Date";
            this.dgvHistory.Columns[4].Width = 130;
            this.dgvHistory.Columns[4].Visible = true;

            this.dgvHistory.Columns[5].HeaderText = "Size";
            this.dgvHistory.Columns[5].DataPropertyName = "Size";
            this.dgvHistory.Columns[5].Width = 100;
            this.dgvHistory.Columns[5].Visible = true;
            
            this.dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.StretchThisColumn(1);

            if (this.chkIncludeConfigs.Checked)
            {
                foreach (DataGridViewRow r in this.dgvHistory.Rows)
                {
                    if (r.Cells[2].Value.ToString().Contains("exe.config"))
                        this.dgvHistory.Rows[r.Index].DefaultCellStyle.ForeColor = System.Drawing.Color.CadetBlue;
                }
            }

            this.cmdLogFilesExtract.Select();
        }

        private void FillAppUserGrid()
        {
            // Build a sub list of User & Path
            this.dgvAppsDataFolders.DataSource = _foundFolders.FoldersFound;

            this.dgvAppsDataFolders.Columns[0].HeaderText = "Selected";
            this.dgvAppsDataFolders.Columns[0].DataPropertyName = "Selected";
            this.dgvAppsDataFolders.Columns[0].Width = 100;
            this.dgvAppsDataFolders.Columns[0].Visible = true;

            this.dgvAppsDataFolders.Columns[1].HeaderText = "User";
            this.dgvAppsDataFolders.Columns[1].DataPropertyName = "User";
            this.dgvAppsDataFolders.Columns[1].Width = 130;
            this.dgvAppsDataFolders.Columns[1].Visible = true;

            this.dgvAppsDataFolders.Columns[2].HeaderText = "Path";
            this.dgvAppsDataFolders.Columns[2].DataPropertyName = "Path";
            this.dgvAppsDataFolders.Columns[2].Width = 100;
            this.dgvAppsDataFolders.Columns[2].Visible = true;

            this.dgvAppsDataFolders.Columns[3].HeaderText = "File";
            this.dgvAppsDataFolders.Columns[3].DataPropertyName = "File";
            this.dgvAppsDataFolders.Columns[3].Width = 0;
            this.dgvAppsDataFolders.Columns[3].Visible = false;

            this.dgvAppsDataFolders.Columns[4].HeaderText = "Date";
            this.dgvAppsDataFolders.Columns[4].DataPropertyName = "Date";
            this.dgvAppsDataFolders.Columns[4].Width = 0;
            this.dgvAppsDataFolders.Columns[4].Visible = false;

            this.dgvAppsDataFolders.Columns[5].HeaderText = "Size";
            this.dgvAppsDataFolders.Columns[5].DataPropertyName = "Size";
            this.dgvAppsDataFolders.Columns[5].Width = 0;
            this.dgvAppsDataFolders.Columns[5].Visible = false;
                        
            this.dgvAppsDataFolders.EnableHeadersVisualStyles = false;
            this.dgvAppsDataFolders.StretchThisColumn(2);

        }

        private void RunExtract(string folder)
        {
            try {
                // Get each unique Path.
                SortedList<string, string> UniquePaths = new SortedList<string, string>();
                foreach (FileDetail x in _foundFiles.FilesFound)
                    if (!UniquePaths.Keys.Contains(x.Path))
                        UniquePaths.Add(x.Path, x.User);

                // Use the FileWriter Class to compress each file in the list.
                using (FileWriter fl = new FileWriter())
                {
                    // create a folder for each name.
                    for (int i = 0; i < UniquePaths.Count; i++)
                    {
                        string logPath = UniquePaths.Keys[i].ToString();
                        string filePath = string.Concat(folder, UniquePaths.Values[i].ToString(), @"\");

                        Helper.MakeFolder(filePath);

                        // and zip each file into the new folder.
                        DirectoryInfo di = new DirectoryInfo(logPath);
                        fl.Compress(di, filePath, this.chkIncludeConfigs.Checked);
                    }
                }
            }
            catch (Exception) { throw; }
        }


        private void IdentifyLogFiles()
        {
            try {

                int step = 0;
                DateTime start = DateTime.Now.AddMinutes(2);
                
                // Set the Background Worker to run the FindFiles process.           
                InitializeBackgroundWorker();               

                // Loop that sets the progress bar to increment until the Background Worker returns.
                while (backgroundWorker1 != null)
                {
                    // Every 10000 steps do an update.
                    if ((step % 1000000) == 0)
                        this.ProgressBar.PerformStep();

                    step += 1;

                    if (step > 200000000)
                    {
                        // Might want to cancel the Background Worker if it takes too long?
                        if (DateTime.Now.TimeOfDay > start.TimeOfDay)
                            if ((backgroundWorker1 != null) && (backgroundWorker1.WorkerSupportsCancellation == true))
                            {
                                // Cancel the asynchronous operation.
                                backgroundWorker1.CancelAsync();
                                backgroundWorker1 = null;
                            }

                        step = 0;
                        this.ProgressBar.Value = step;                        
                    }
                }

                this.ProgressBar.Value = 0;

            }
            catch (Exception) { throw; }
        }
        
        private void InitializeBackgroundWorker()
        {
            try {
                backgroundWorker1 = new BackgroundWorker();

                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.WorkerReportsProgress = true; // not used in this Solution as we shell out a batch file so dont get any feedback from it.

                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception) { throw; }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // This event handler is where the actual, potentially time-consuming work is done.    
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
                e.Cancel = true;
            else
            {
                try {
                    // This is the main bit......
                    _foundFiles = new FileIdentifier(this.chkIncludeConfigs.Checked);
                }
                catch (Exception) { throw; }
                finally
                {
                    // Can bail out once the main bit above is complete.
                    // Need to check here in case the TimeOut in IdentifyLogFiles() has set this to null.
                    if (backgroundWorker1 != null)
                        if (backgroundWorker1.WorkerSupportsCancellation == true)
                        {
                            // Cancel the asynchronous operation.
                            backgroundWorker1.CancelAsync();
                            backgroundWorker1 = null;
                        }
                }              
            }
        }

        private void backgroundWorker1_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e)
        {
            // This event handler deals with the results of the background operation.
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
                this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName, " - ", e.Error.Message);
            else if (e.Cancelled)
                // Next, handle the case where the user canceled the operation.
                // Note that due to a race condition in the DoWork event handler, the Cancelled
                // flag may not have been set, even though CancelAsync was called.
                this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName, " - Search Cancelled");
            else
                // Finally, handle the case where the operation succeeded.
                this.ssTextBox.Text = string.Concat("PC Name: ", Environment.MachineName, " - Search Complete");            
        }


    }
}

