using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace NICE_Helper
{
    class FileIdentifier : BatchHelper
    {
        private readonly bool _includeConfigs;

        public BindingList<FileDetail> FilesFound { get; }
        public int CountLogs { get; private set; }
        public int CountConfigs { get; private set; }
        public int CountUsers { get; private set; }
        public int CountFiles { get; private set; }

        public FileIdentifier(bool IncludeConfigs)
        {
            _includeConfigs = IncludeConfigs;
            FilesFound = new BindingList<FileDetail>();
            try {
                string cmd = CreateBatchCommand();

                if (RunBatch(cmd) == Helper.RESULT_GOOD)
                    ListFromOutput();

                Helper.DeleteFile(_batchFile);
                Helper.DeleteFile(_outFile);
            }
            catch (Exception) { throw; }
        }

        public FileIdentifier(string path)
        {
            FilesFound = new BindingList<FileDetail>();
            ListZippedProjectFiles(path);
        }

        private void ListZippedProjectFiles(string path)
        {
            try {
                // Only get files that begin with the letter "z".
                string[] found = Directory.GetFiles(path, "*.z*");
                foreach (string fl in found)
                {
                    FileInfo oFileInfo = new FileInfo(fl);
                    FilesFound.Add(new FileDetail(
                                oFileInfo.Name,
                                oFileInfo.CreationTime.ToShortDateString(),
                                oFileInfo.Directory.FullName,
                                oFileInfo.Length));

                    CountFiles += 1;
                }
            }
            catch (Exception) { throw; }
        }
        

        private string CreateBatchCommand()
        {

            StringBuilder str = new StringBuilder();
            if (_includeConfigs)
            {
                str.Append(@"for /d %%i in (C:\Users\*) do dir %%i\AppData\Roaming\Nice_Systems\Real-Time\*.exe.config* /s /b /a:-D");
                str.Append(@" >> ");
                str.Append(@"""");
                str.Append(_outFile);
                str.Append(@"""");
                str.AppendLine();
            }

            str.Append(@"for /d %%i in (C:\Users\*) do dir %%i\AppData\Roaming\Nice_Systems\Real-Time\log\*.log.* /s /b /a:-D");
            str.Append(@" >> ");
            str.Append(@"""");
            str.Append(_outFile);
            str.Append(@"""");

            return str.ToString();

        }
        
        private void ListFromOutput()
        {
            using (StreamReader sw = new StreamReader(_outFile))
            {
                string line;
                string user;
                string nm;
                DateTime dtCreationTime;
                ArrayList names = new ArrayList();

                while ((line = sw.ReadLine()) != null)
                {
                    // only if like a log file.
                    if (line.ToLower().Contains(".log"))
                    {
                        FileInfo oFileInfo = new FileInfo(line);
                        dtCreationTime = oFileInfo.CreationTime;
                        nm = line.Replace(@"C:\Users\", "");
                        user = nm.Substring(0, nm.IndexOf(@"\AppData"));

                        FilesFound.Add(new FileDetail(oFileInfo.Directory.FullName,
                                                  user,
                                                  oFileInfo.Name,
                                                  dtCreationTime.ToString(),
                                                  oFileInfo.Length));
                        CountLogs += 1;

                        // Add each unique user.
                        if (!names.Contains(user))
                            names.Add(user);
                    }

                    // only if like a config file.
                    if (line.ToLower().Contains(".exe.config"))
                    {
                        FileInfo oFileInfo = new FileInfo(line);
                        dtCreationTime = oFileInfo.CreationTime;
                        nm = line.Replace(@"C:\Users\", "");
                        user = nm.Substring(0, nm.IndexOf(@"\AppData"));

                        FilesFound.Add(new FileDetail(oFileInfo.Directory.FullName,
                                                  user,
                                                  oFileInfo.Name,
                                                  dtCreationTime.ToString(),
                                                  oFileInfo.Length));
                        CountConfigs += 1;

                        // Add each unique user.
                        if (!names.Contains(user))
                            names.Add(user);
                    }
                }

                CountUsers = names.Count;

            }
        }



    }
}
