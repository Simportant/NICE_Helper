using System;
using System.IO;
using System.Text;

namespace NICE_Helper
{
    public class ErrorLogger
    {       
        static readonly string _outFile;

        static ErrorLogger()
        {
            try {
                string outPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Logs\\";

                Helper.MakeFolder(outPath);

                _outFile = string.Concat( outPath, System.Security.Principal.WindowsIdentity.GetCurrent().Name, ".log").Replace("VOICERECORDING\\", "");

            }
            catch (Exception) { throw; }
        }

        public static void Log(string Message, string Source, Helper.LogLevel Level, Boolean PopUp)
        {
            try {
                using (FileStream strm = new FileStream(_outFile, FileMode.Append))
                {
                    using (StreamWriter wrtr = new StreamWriter(strm))
                    {
                        StringBuilder str = new StringBuilder();
                        str.Append(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToString("dd/MM/yyyy") + " ");
                        str.Append(Level.ToString());
                        str.Append(": [" + Source + "] - ");
                        str.Append(Message);
                        wrtr.WriteLine(str.ToString());
                    }
                }
                if (PopUp)
                    System.Windows.Forms.MessageBox.Show(Message, Helper.Title, System.Windows.Forms.MessageBoxButtons.OK, Helper.GetIcon(Level));
            }
            catch (Exception) { throw; }
        }

        

    }
}
