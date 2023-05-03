using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Entities.Tables
{
    public class Cinsiyet
    {


        #region Teori
        // Access Modifier (Erişim Belirteçleri)   

        // Public : Her yerden erişilebilir
        //private : sadece bulunduğu class yada interface içersinde erişilebilir.
        //protected :  bulunduğu class ya da interface ve bu classtan türetilmiş yani kalıtım ile alınmış diğer class içerisnden erişilebilir nesne

        //internal : sadece bulunduğu proje içerisinde 
        #endregion

        [Key]
        public int ID { get; set; }
        public string CinsiyetName { get; set; }


        //todo Virtual Methodları çalışın
       // public virtual List<Students> Students { get; set; }

    }
}
