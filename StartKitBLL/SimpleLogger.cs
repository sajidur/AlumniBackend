using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartKitBLL
{
    internal class SimpleLogger
    {
        public static void Log(string text)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            path =path+"/"+ DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
            File.AppendAllText(path, text);
        }
    }
}
