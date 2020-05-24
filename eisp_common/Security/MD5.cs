using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Eisp.Common.Security
{
   public class MD5
    {
        public static string HashString(string value)
        {
            return HashString(value, Encoding.Default);
        }

        public static string HashString(string value, Encoding encoder)
        {
            if (encoder == null) encoder = Encoding.Default;
            byte[] buffer = encoder.GetBytes(value);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bt = md5.ComputeHash(buffer);
            md5.Clear();

            string result = BitConverter.ToString(bt);
            return result.Replace("-", "").ToLower();
        }

        public static string HashFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return HashFile(file);
        }

        public static string HashFile(Stream file)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bt = md5.ComputeHash(file);

            file.Close();
            md5.Clear();

            string result = BitConverter.ToString(bt);
            return result.Replace("-", "").ToLower();
        }
    }
}
