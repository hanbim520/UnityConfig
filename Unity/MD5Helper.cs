using System;
using System.Text;
using System.Security.Cryptography;

namespace GameConfig
{

    public class MD5Helper
    {
        private static MD5 md5 = MD5.Create();

        private MD5Helper()
        {
        }

        public static string HashString(string strSource)
        {
            return HashString(Encoding.UTF8, strSource);
        }


        public static string HashString(Encoding encode, string strSource)
        {
            return HashString(encode.GetBytes(strSource));
        }

        public static string HashString(byte[] bySource)
        {
            byte[] source = md5.ComputeHash(bySource);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
