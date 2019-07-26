using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NICE_Helper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up Log4Net
            string outPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs";
            if (!System.IO.Directory.Exists(outPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(outPath);
                }
                catch (System.Exception) { throw; }
            }
            Helper.MakeFolder(outPath);
            log4net.GlobalContext.Properties["LogFileName"] = string.Concat(outPath, @"\NICE_Helper.log");
            log4net.Config.XmlConfigurator.Configure();

            Application.Run(new frmMain());
        }


    }
}
