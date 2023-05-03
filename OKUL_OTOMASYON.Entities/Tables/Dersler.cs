using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Entities.Tables
{
    public class Dersler
    {

        [Key]
        public int ID { get; set; }
        public string DersName { get; set; }

    //    public virtual List<Teachers> Teachers { get; set; }

    }
}
