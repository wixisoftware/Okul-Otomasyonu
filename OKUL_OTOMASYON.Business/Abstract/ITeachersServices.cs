using OKUL_OTOMASYON.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Business.Abstract
{
    public interface ITeachersServices
    {

        bool GetTeacherWithInfo(string txtOgretmenNo,string txtTCKimlikNo,string txtEMail);

        void KodGonder();
        bool IsCodeTrue(string Kod);

        List<Teachers> GetAll();
        bool isValid(string TCKN, string OgretmenNo, string Password);
    }
}
