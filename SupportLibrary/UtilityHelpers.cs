using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportLibrary
{
    public class UtilityHelpers
    {
        public static void WriteLog(string fileName, string logText)
        {
            StreamWriter sw = null;
            try
            {
                //sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw = new StreamWriter(fileName, true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + logText);
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
    }
}
