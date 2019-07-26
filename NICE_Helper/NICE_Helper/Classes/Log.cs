using System;
using System.IO;
using System.Text;

namespace NICE_Helper
{
    public class Log
    {  
        static Log()
        {
            // Set up Log4Net
            //string outPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Helper.MakeFolder(outPath);
            //log4net.GlobalContext.Properties["LogFileName"] = string.Concat(outPath, @"\NICE_Helper");
            //log4net.Config.XmlConfigurator.Configure();
        }

    }
}
