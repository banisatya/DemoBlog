using DemoBlog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlog.ConsoleApplication
{
    class Program
    {
        public static string PasswordEncrypt(string password)
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

        static void Main(string[] args)
        {
            Console.WriteLine("This is beginning");
            try
            {
                string str = DateTime.Now.ToString("MMMM dd, yyyy");
                Console.WriteLine(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ex.InnerException);
            }
            Console.WriteLine("This is end");
            //DemoContext db = new DemoContext();
            //var lst = (from u in db.User select u).ToList().Count;
            //int count = db.Blog.Count();
            Console.ReadKey();
        }
    }
}
