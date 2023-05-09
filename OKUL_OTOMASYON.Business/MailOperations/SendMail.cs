using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace OKUL_OTOMASYON.Business.MailOperations
{
    public class SendMail
    {
        // inner class  

        public class StudentsSendMails
        {



        }


        public class TeachersSendMails
        {
            public void TeacherMesssage(string Subject,string Content)
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("wixiokul@outlook.com"); // Kimden Gidiceği
                mail.To.Add("ahmetcanb785@gmail.com");
                mail.Subject = Subject;
                mail.Body = Content;

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("wixiokul@outlook.com", "Yildiz0343,");
                smtp.Port = 587;
                smtp.Host = "smtp.outlook.com";
                smtp.EnableSsl = true; // Doğru adrese ulaşana kadar şifreli gidiyor.

                smtp.Send(mail); // Maili Smtp üzerinden sendlemiş olduk.



            }


        }

    }
}
