using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Business.Security
{
    public class PasswordPowerDetected
    {
        public enum PasswordStrenghLevel
        {
            Gecersiz,
            Zayif,
            Normal,
            Guclu,
            Guvenli

        }

        public PasswordStrenghLevel GetLevel (string password)
        {
            int score = GeneratePasswordScore(password);
            // içeride yazıcağımız mettotlara göre 0 ile 100 arasında şifremize puanlama yapılıcak ve seviyesini alıcağız



            if (score <50 )
            {
                return PasswordStrenghLevel.Gecersiz;
            }else if (score <60 )
            {
                return PasswordStrenghLevel.Zayif;
            }
            else if (score <80)
            {
                return PasswordStrenghLevel.Normal;
            }
            else if (score <90)
            {
                return PasswordStrenghLevel.Guclu;
            }
            else if (score > 90)
            {
                return PasswordStrenghLevel.Guvenli;
            }
            else
            {
                return PasswordStrenghLevel.Gecersiz;
            }
        }


        public int GeneratePasswordScore(string password)
        {
            if (password ==null)
            {
                return 0;
            }


            // length - kucukharf - buyukharf -sayısal -sembol
            var result = LenghtScore(password) + LowerLetterScore(password) + UpperLetterScore(password) + DigitScore(password) + SymbolScore(password);

            if (result>100)
            {
                return 100;
            }
         return result;
        }

        private int LenghtScore(string password)
        {
                                                            //6 
            var result =  Math.Min(10,password.Length) *6; // 36 
            // en yüksek 60
            return result;
        }


        private int LowerLetterScore(string password)
        {    //6   12Aa.B  6-5 = 1 puanlık kucuk
            var result = password.Length - Regex.Replace(password, "[a-z]","").Length;
            return result;
        }

        private int UpperLetterScore(string password)
        {
            //6   12Aa.B  6-4 = 2 puanlık buyuk
            var result = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
            return result;
        }


        private int DigitScore(string password)
        {
            //6   12Aa.B  6-4 = 2 puanlık sayı
            var result = password.Length - Regex.Replace(password, "[0-9]", "").Length;
            return Math.Min(10,result)*5; // 20
            //int rawScore = Regex.Replace(password, "[a-zA-Z0-9]", "").Length;

           // return result;
        }

        private int SymbolScore(string password)
        {
            //6   12Aa.B  1 puanlık sayı
            var result = Regex.Replace(password, "[a-zA-Z0-9]", "").Length;
            return Math.Min(10, result) * 5; // 5

        }

    }
}
