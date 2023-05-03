using OKUL_OTOMASYON.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.DataAccessLayer.ContextBase.GenericRepository
{
    public interface  IEFGenericRepository<T>
    {

        T Add(T entity);

        List<T> GetAll();

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        List<T> GetList(Expression<Func< T,bool>> filter = null);
        T Get(Expression<Func< T,bool>> filter = null);

        // i=> i.firstname == "Ahmet"  ifadesi gibi yapılarla bir filtreleme göndererek belirli bir alana bağlı kalmadan filtreleem sağlar

    }
}
