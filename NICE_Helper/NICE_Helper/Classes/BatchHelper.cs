using System;
using System.IO;

namespace NICE_Helper
{
    public abstract class BatchHelper 
    {
        protected string _outPath;
        protected string _outFile;
        protected string _batchFile;

        public BatchHelper()
        {
            _outPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Logs\\";

            Helper.MakeFolder(_outPath);

            _outFile = _outPath + "output.txt";
            _batchFile = _outPath + "temp.bat";

        }
        protected int RunBatch(string BatchCommand)
        {
            
            int result = Helper.RESULT_GOOD;
            try {
                CreateBatch(BatchCommand);

                using (System.Diagnostics.Process myProcess = new System.Diagnostics.Process())
                {
                    myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    myProcess.StartInfo.FileName = _batchFile;
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.Verb = "runas";
                    myProcess.Start();
                    myProcess.WaitForExit();
                }

                if (File.Exists(_outFile))
                    result = Helper.RESULT_GOOD;
                else
                    result = Helper.RESULT_BAD;
                
            }
            catch (Exception) { throw; }

            return result;
        }

        protected void CreateBatch(string BatchCommand)
        {
            try {
                using (FileWriter btch = new FileWriter(_batchFile))
                {
                    btch.WriteLine(BatchCommand);
                }
            }
            catch (Exception)  { throw; }
        }

    }
}
