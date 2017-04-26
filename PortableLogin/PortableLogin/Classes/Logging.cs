using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLogin
{
    public static class Logging
    {
        /// <summary>
        /// Formats exception to a readable string and logs is to exceptions file
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            string exceptionMsg = "Message :" + ex.Message + " " + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                "" + Environment.NewLine + "Date :" + DateTime.Now.ToString();
            Console.WriteLine(exceptionMsg);
            FileMinapulation.WriteException(exceptionMsg);

        }
        /// <summary>
        /// Logs a string to exceptions file
        /// </summary>
        /// <param name="issue"></param>
        public static void Log(string issue)
        {
            Console.WriteLine(issue);
            FileMinapulation.WriteException(issue + " " + "Date :" + DateTime.Now.ToString());
        }
    }
   
}
