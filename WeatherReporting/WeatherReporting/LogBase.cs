using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReporting
{
    public class Logger 
    {
        public static string logFile = ConfigurationManager.AppSettings["LogDirectory"] + DateTime.Now.ToString("yyyy-MM-dd") + "Log.txt";
        public static string exception;

        /// <summary>
        /// Exception details
        /// </summary>
        /// <param name="e"></param>
        public static void ExceptionLog(Exception e)
        {
            exception = "\n Message: "+e.Message+"\n Data: "+e.StackTrace;
        }

        /// <summary>
        /// Creating Log
        /// </summary>
        /// <param name="log"></param>
        public static void Log(string log)
        {            
            if (!System.IO.File.Exists(logFile))
            {
                System.IO.FileStream file= System.IO.File.Create(logFile);
                file.Close();
            }
            using (StreamWriter streamWriter = new StreamWriter(logFile, true))
            {
                    streamWriter.WriteLine(log);
                    streamWriter.Close();
            }          
        }
    }
}
