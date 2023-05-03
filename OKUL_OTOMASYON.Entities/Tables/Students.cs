using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Entities.Tables
{
    public class Students
    {
        [Key]
        public int ID { get; set; }
        public string OgrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }



        public int CinsiyetID { get; set; }
      //  public virtual Cinsiyet Cinsiyet { get; set; }


        public int SubeID { get; set; }
      //  public virtual Subeler Subeler { get; set; }






    }
}
