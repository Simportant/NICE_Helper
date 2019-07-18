
namespace NICE_Helper
{
    public class Helper
    {
       
        public enum LogLevel {ALL,DEBUG,INFO,WARN,ERROR,FATAL}
        public enum FileStatus {Open,Closed,Writing,Error}
               
        public static string Title = "Log Viewer";
        public static int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
        public static int RESULT_GOOD = 0;
        public static int RESULT_BAD = -1;

        public static System.Windows.Forms.MessageBoxIcon GetIcon(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.ALL:
                    return System.Windows.Forms.MessageBoxIcon.None;
                case LogLevel.DEBUG:
                    return System.Windows.Forms.MessageBoxIcon.Asterisk;
                case LogLevel.INFO:
                    return System.Windows.Forms.MessageBoxIcon.Information;
                case LogLevel.WARN:
                    return System.Windows.Forms.MessageBoxIcon.Warning;
                case LogLevel.ERROR:
                    return System.Windows.Forms.MessageBoxIcon.Error;
                case LogLevel.FATAL:
                    return System.Windows.Forms.MessageBoxIcon.Stop;
                default:
                    return System.Windows.Forms.MessageBoxIcon.Hand;
            }
        }

        public static void DeleteFile(string outFile)
        {
            try
            {
                if (System.IO.File.Exists(outFile))
                    System.IO.File.Delete(outFile);
            }
            catch (System.Exception)
            {
                throw;
            }            
        }
        
        public static void MakeFolder(string NewFolderName)
        {
            if (!System.IO.Directory.Exists(NewFolderName))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(NewFolderName);
                }         
                catch (System.Exception) 
                {
                    throw;
                }
            }
        }


    }
}


