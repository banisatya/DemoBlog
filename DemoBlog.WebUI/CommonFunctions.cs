using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DemoBlog.WebUI
{
    public static class CommonFunctions
    {
        public static string EncryptPassword(string password)
        {
            string encryptedPassword = "";
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var originalBytes = Encoding.Default.GetBytes(password);
                    byte[] encodedBytes = md5.ComputeHash(originalBytes);
                    encryptedPassword = Convert.ToBase64String(encodedBytes);
                }
            }
            catch (Exception)
            {
            }
            return encryptedPassword;
        }
    }
}