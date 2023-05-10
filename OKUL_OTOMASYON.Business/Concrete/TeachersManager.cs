using OKUL_OTOMASYON.Business.Abstract;
using OKUL_OTOMASYON.Business.MailOperations;
using OKUL_OTOMASYON.Business.Security;
using OKUL_OTOMASYON.DataAccessLayer.ContextBase.GenericRepository;
using OKUL_OTOMASYON.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Business.Concrete
{
    public class TeachersManager : ITeachersServices
    {
        IEFGenericRepository<Teachers> _context = new EFGenericRepository<Teachers>();
        public List<Teachers> GetAll()
        {
        return   _context.GetAll();
        }

        public bool isValid(string TCKN,string OgretmenNo,string Password)
        {
            MD5_Encrypt_Decrypt md = new MD5_Encrypt_Decrypt();
            string hash = md.Encrypt(Password);
            var result = _context.Get( i => i.TCKN == TCKN && i.OgretmenNo==OgretmenNo && i.PasswordHash == hash);

            if (result != null)
            {
                return true;
            }
            return false;

        }

        //todo admin girişinin kontrolünü güncelleyeceğiz
        public bool isAdmin(string TCKN, string OgretmenNo)
        {
            if (TCKN == "00000000000" && OgretmenNo =="00000")
            {
                return true;
            }
          
            return false;

        }

        public string kod="";
       public void KodGonder()
        {
            // 6 haneli bir kod üreticeğiz
            Random rndm = new Random();
            
            for (int i = 0; i < 6; i++)
            {
                 kod += rndm.Next(0, 9).ToString();

            }

            SendMail.TeachersSendMails sn = new SendMail.TeachersSendMails();
            sn.TeacherMesssage("Doğrulama Kodu", kod);



        }

        public bool IsCodeTrue(string Kod)
        {
            if (kod == Kod)
            {
                return true;
            }
            return false;
        }

        public bool GetTeacherWithInfo(string txtOgretmenNo, string txtTCKimlikNo, string txtEMail)
        {
            var result = _context.Get(i => i.OgretmenNo == txtOgretmenNo && i.TCKN == txtTCKimlikNo && i.Email == txtEMail);

            if (result == null)
            {
                return false;

            }

            return true;
        }
    }
}
