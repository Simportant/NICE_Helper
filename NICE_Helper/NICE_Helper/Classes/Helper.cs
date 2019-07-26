
namespace NICE_Helper
{
    public class Helper
    {
        
        public enum FileStatus {Open,Closed,Writing,Error}
               
        public static string Title = "Log Viewer";
        public static int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
        public static int RESULT_GOOD = 0;
        public static int RESULT_BAD = -1;

        public static void DeleteFile(string outFile)
        {
            try  {
                if (System.IO.File.Exists(outFile))
                    System.IO.File.Delete(outFile);
            }
            catch (System.Exception) { throw; }            
        }
        
        public static void MakeFolder(string NewFolderName)
        {
            if (!System.IO.Directory.Exists(NewFolderName))
            {
                try {
                    System.IO.Directory.CreateDirectory(NewFolderName);
                }         
                catch (System.Exception)  { throw; }
            }
        }


    }
}


