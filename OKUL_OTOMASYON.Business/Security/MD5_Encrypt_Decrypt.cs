using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Business.Security
{
    public class MD5_Encrypt_Decrypt
    {

        #region Encrypt etme
     
        public string Encrypt(string text) //12345 
        {

     
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.Default.GetBytes(text));
            byte[] keys = md5.Hash;

            StringBuilder strBuild = new StringBuilder();

            for (int i = 0; i < keys.Length; i++)
            {
                strBuild.Append(keys[i].ToString("x2"));
                //x2 ifadesi byte olarak gelen ifadeyi 16 lık sayı sistemine çeviriyor
            }
          
            return strBuild.ToString();
        }


        #endregion


        #region Decrypt etme

        #endregion


    }
}
