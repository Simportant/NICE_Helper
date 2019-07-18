
namespace NICE_Helper
{
    class FileDetail
    {
        long _Bytes;
        
        public FileDetail(string file, string date, string path, long bytes)
        {
            Path = path;
            User = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"VOICERECORDING\", "");
            File = file;
            Date = date;
            _Bytes = bytes;
        }
        public FileDetail(string path, string user, string file, string date, long bytes)
        {
            Path = path;
            User = user;
            File = file;
            Date = date;            
            _Bytes = bytes;            
        }

        public FileDetail(string user, string path, bool isSelected)
        {
            Selected = isSelected;
            User = user;
            Path = path;
        }
        public FileDetail()
        {
        }

        public bool Selected { get; set; }
        public string File { get; }
        public string Date { get; }
        public string User { get; private set; }
        public string Path { get; private set; }
        public string Size 
        { 
            get 
            { 
                if (_Bytes < 1025)
                    return _Bytes.ToString() + " bytes"; 
                else
                    return (_Bytes / 1024).ToString() + " KB"; 
            }
        }
       
    }
}
