using System;
using System.IO;

namespace NICE_Helper
{
    public abstract class BatchHelper 
    {
        public static string _outPath;
        public static string _outFile;
        public static string _batchFile;
        public static string _batchCommand;

        public BatchHelper()
        {
            _outPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Logs\\";

            Helper.MakeFolder(_outPath);

            _outFile = _outPath + "output.txt";
            _batchFile = _outPath + "temp.bat";

        }
        public static int RunBatch(string BatchCommand)
        {
            
            int result = Helper.RESULT_GOOD;
            try
            {
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
            catch (Exception ex)
            {
                ErrorLogger.Log(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, Helper.LogLevel.ERROR, true);
                result = Helper.RESULT_BAD;
            }

            return result;
        }
        
        private static void CreateBatch(string BatchCommand)
        {
            try
            {
                using (FileWriter btch = new FileWriter(_batchFile))
                {
                    btch.WriteLine(BatchCommand);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, Helper.LogLevel.ERROR, true);
                throw;
            }
        }

    }
}
