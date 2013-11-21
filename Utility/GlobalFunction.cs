using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace MyGames.Utility
{
    public class GlobalFunction
    {
        public static string MD5(string s)
        {
            //md5
            byte[] result = Encoding.Default.GetBytes(s);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string val = BitConverter.ToString(output).Replace("-", "");

            return val;
        }
    }
}
