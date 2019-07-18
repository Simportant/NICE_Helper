using System;

namespace NICE_Helper
{
    class AppData
    {
        public bool Selected { get; set; }
        public String User { get; private set; }
        public String Path { get; private set; }

        public AppData(string user, string path, bool isSelected)
        {
            Selected = isSelected;
            User = user;
            Path = path;
        }
        public AppData()
        {
        }

    }
}
