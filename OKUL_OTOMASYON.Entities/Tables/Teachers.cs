using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Entities.Tables
{
    public class Teachers
    {

        public int ID { get; set; }

        public string TCKN { get; set; }
        public string OgretmenNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     


        public DateTime DogumTarihi { get; set; }
        public DateTime StartDate { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }



        public int AlanID { get; set; }
      //  public virtual Alan Alan { get; set; }



        public int SubeID { get; set; }
      //  public virtual Subeler Subeler { get; set; }



        public int CinsiyetID { get; set; }
     //   public virtual Cinsiyet Cinsiyet { get; set; }



      //  public virtual List<SubeTeacher> SubeTeacher { get; set; }



    }
}
