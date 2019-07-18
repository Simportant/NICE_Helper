using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Log_Viewer
{
   
    public class FileAccessor : Ifile
    {
        private string _Delimiter;
        private string _FileName;
        private FileStream _Stream;
        private StreamWriter _Writer;
        private Helper.FileStatus _FileStatus;

        public FileAccessor(string fileName, FileMode mode)
        {
            _FileName = fileName;
            _FileStatus = Helper.FileStatus.Closed;         
            if (_FileName.Length > 5)
            {
                OpenFile(_FileName, FileMode.Create);
            }
        }

        public FileAccessor(string delimiter)
        {
            _Delimiter = delimiter;
            _FileStatus = Helper.FileStatus.Closed;
            GetFile();
            if (_FileName.Length > 5)
            {
                OpenFile(_FileName, FileMode.Create);
            }
        }

        public void OpenFile(string LogFile, FileMode Mode)
        {
            if (_FileStatus == Helper.FileStatus.Closed)
            {
                try
                {
                    _FileStatus = Helper.FileStatus.Open;
                    _Stream = new FileStream(LogFile, Mode);
                    _Writer = new StreamWriter(_Stream);
                }
                catch(Exception ex)
                {
                    CloseFile();
                    WriteLog(ex.Message);
                    throw new Exception("Could not open file");
                }
            }
        }
        public void CloseFile()
        {
            try
            {
                if (_FileStatus != Helper.FileStatus.Closed)
                {
                    _Writer.Close();
                    _Writer.Dispose();
                    _Stream.Close();
                    _Stream.Dispose();
                    _FileStatus = Helper.FileStatus.Closed;
                }
            }
            catch { /*throw new Exception("Could close file");*/ }
        }
        public void GetFile()
        {
            // Save content of data grid to csv.
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _FileName = saveFileDialog1.FileName;
            }
            else
            {
                _FileName = "";
            }
        }
        public void WriteEntry(string Entry)
        {
            _Writer.WriteLine(Entry);
        }

        public string FileName { get { return _FileName; } }
        public string Delimiter { get { return _Delimiter; } }
        public Boolean ValidFile { get { return (_FileStatus == Helper.FileStatus.Open); } }

    }
}
