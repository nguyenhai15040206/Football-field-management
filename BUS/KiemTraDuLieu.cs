using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{
   public static class KiemTraDuLieu
    {
        // mã hóa dữ liệu
        public static string MD5Hash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text 
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
            byte[] result = md5.Hash;
            // get hash result after compute it

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // change it into 2 hexadecimal digits
                //for each byte
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }


        ///Kiểm tra số điện thoại
        ///

        public static bool KtraSoDienThoai(string input)
        {
            if (input[0] == '0' && input.Trim().Length == 10 && KtraDuLieu(input))
                return true;
            return false;
        }
        public static bool KtraDuLieu(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }


        //Ktra email
        public static bool KtraEmail(String input)
        {
            input = input ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return true;
            return false;
        }
    }
}
