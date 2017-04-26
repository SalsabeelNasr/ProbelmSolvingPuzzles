using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PortableLogin
{
    public class User
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// Returns a SH1 hash of a string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string hashPassword(string password)
        {
            try
            {
                var sha1 = new SHA1CryptoServiceProvider();
                string sha1data = BitConverter.ToString(sha1.ComputeHash(Encoding.Unicode.GetBytes(password))).Replace("-", "").ToLower();
                return sha1data;
            }
            catch (Exception e)
            {
                Logging.Log(e);
                return null;
            }

        }
        /// <summary>
        /// Validates that username is not empty or null or
        /// a white space or exceeding 20 charchters long
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool isValidUsername(string username)
        {
            
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            } 
            else if (username == string.Empty)
            {
                return false;
            }
            else if (username.Length > 20)
            {
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Validates that password is not empty or null or
        /// a white space or exceeding 20 charchters long
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool isValidPassword(string password)
        {
            
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            else if (password == string.Empty)
            {
                return false;
            }
            else if (password.Length > 20)
            {
                return false;
            }
            else
                return true;
        }
    }
}
