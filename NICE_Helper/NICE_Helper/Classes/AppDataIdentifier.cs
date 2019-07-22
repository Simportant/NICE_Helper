using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace NICE_Helper
{
    class AppDataIdentifier : BatchHelper
    {

        public BindingList<FileDetail> FoldersFound { get; }
        public int FoldersCount { get { return (FoldersFound != null) ? FoldersFound.Count() : 0; } }
        public bool ReadyForDeletion { get { return FoldersFound.Where(x => (x.Selected == true)).ToList().Count > 0; } }
        public AppDataIdentifier()
        {
            FoldersFound = new BindingList<FileDetail>();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append(@"for /d %%i in (C:\Users\*) do dir %%i\AppData\Roaming\Nice_Systems\Real-Time\RTClient.exe.config* /s /b /a:-D");
                str.Append(@" >> ");
                str.Append(@"""");
                str.Append(_outFile);
                str.Append(@"""");
                str.AppendLine();

                if (RunBatch(str.ToString()) == Helper.RESULT_GOOD)
                    ListFromOutput();

                Helper.DeleteFile(_batchFile);
                Helper.DeleteFile(_outFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FlipSelectedFlag(string userName)
        {           
            FileDetail ap = new FileDetail();
            ap = FoldersFound.FirstOrDefault(x => x.User == userName);
            ap.Selected = !ap.Selected;
        }

        public void RemoveSelectedItems()
        {
            // Call ToList() here because otherwise we'll enumerate a collection while modifying it.
            List<FileDetail> usersToRemove = new List<FileDetail>();
            usersToRemove = FoldersFound.Where(x => (x.Selected == true)).ToList();
            
            foreach (FileDetail found in usersToRemove)
            {
                Directory.Delete(found.Path, true);
                FoldersFound.Remove(found);
            }            
        }
                
        private void ListFromOutput()
        {
            using (StreamReader sw = new StreamReader(_outFile))
            {
                string line;
                string user;
                string nm;

                while ((line = sw.ReadLine()) != null)
                {
                    // only if like a config file.
                    if (line.ToLower().Contains(".exe.config"))
                    {
                        FileInfo oFileInfo = new FileInfo(line);
                        nm = line.Replace(@"C:\Users\", "");
                        user = nm.Substring(0, nm.IndexOf(@"\AppData"));
                        FoldersFound.Add(new FileDetail(user, oFileInfo.DirectoryName, false));
                    }
                }
            }
        }




    }
}
