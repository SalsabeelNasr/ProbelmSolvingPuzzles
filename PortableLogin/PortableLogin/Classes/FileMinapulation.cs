using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PortableLogin
{
    public static class FileMinapulation
    {
       // public static string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
        public static string appPath ="";
        private static string usernameAndPasswordFile = appPath + "credentials";
        private static string exceptionsFile = appPath + "exceptions";
        /// <summary>
        /// Reads username and password entries from a file called credentials
        /// in the solution path 
        /// </summary>
        /// <returns>returns a user object with username and password 
        /// if anything didn't work it logs the issue to 
        /// exceptions file and returns null</returns>
        public static User ReadUserNameAndPassword()
        {
            try
            {	 
                string[] text = File.ReadAllLines(usernameAndPasswordFile);
                User user = new User();
                if (!string.IsNullOrEmpty(text[0]))
                    user.Username = text[0].Split('=')[1];

                if (!string.IsNullOrEmpty(text[1]))
                    user.Password = text[1].Split('=')[1];

                if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                    return user;
                else
                {
                    Logging.Log("username or password were retreived empty from the file" + " " + "Date :" + DateTime.Now.ToString());
                    return null;
                }
            }
            catch (Exception e)
            {
                Logging.Log(e);
                return null;
            }
        }
        /// <summary>
        /// Writes password to a file called credentials
        /// in the solution path 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns true if writing to file was successfull,
        /// if anything went wrong it loggs errors to exceptions file and
        /// returns false</returns>
        public static bool WritePassword(string password)
        {
            try
            {
                string[] text = File.ReadAllLines(usernameAndPasswordFile);
                if (File.ReadAllText(usernameAndPasswordFile).ToString().Length > 0)
                {
                    File.WriteAllText(usernameAndPasswordFile, string.Empty);
                }
                using (StreamWriter writer = File.AppendText(usernameAndPasswordFile))
                {
                    writer.WriteLine(text[0]);
                    writer.WriteLine("Password=" + password);
                }
                return true;
            }
            catch (Exception e)
            {
                Logging.Log(e);
                return false;
            }
        }
        /// <summary>
        /// Logs exceptions with date to a file called exception in the 
        /// the solution path
        /// </summary>
        /// <param name="exceptionMsg"></param>
        public static void WriteException(string exceptionMsg)
        {
            using (StreamWriter writer = File.AppendText(exceptionsFile))
            {
                try
                {
                    writer.WriteLine(exceptionMsg);
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                catch (Exception e)
                {
                    Logging.Log(e);
                }
            }

        }
    }
    
}
