using OKUL_OTOMASYON.Business.Abstract;
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

            var result = _context.Get( i => i.TCKN == TCKN && i.OgretmenNo==OgretmenNo && i.PasswordHash == Password );

            if (result != null)
            {
                return true;
            }
            return false;

        }
    }
}
