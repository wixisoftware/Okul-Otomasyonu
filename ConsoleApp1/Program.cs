using OKUL_OTOMASYON.Business.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MD5_Encrypt_Decrypt md = new MD5_Encrypt_Decrypt();

         Console.WriteLine(   md.Encrypt("12345"));

            Console.ReadKey();

        }
    }
}
