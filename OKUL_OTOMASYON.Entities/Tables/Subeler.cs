using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Entities.Tables
{
    public class Subeler
    {

        [Key]
        public int ID { get; set; }
        public string SubeName { get; set; }

      //  public virtual List<Students> Students { get; set; }
       // public virtual List<Teachers> Teachers { get; set; }

    }
}
