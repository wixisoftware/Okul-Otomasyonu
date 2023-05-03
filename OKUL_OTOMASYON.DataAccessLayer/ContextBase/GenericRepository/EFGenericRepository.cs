using OKUL_OTOMASYON.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.DataAccessLayer.ContextBase.GenericRepository
{
    public class EFGenericRepository<T> : IEFGenericRepository<T> where T : class
    {
        private DatabaseEntities db = new DatabaseEntities();
        private DbSet<T> _dbSet;

        public EFGenericRepository()
        {
            _dbSet = db.Set<T>();
        }

        #region Manuel Ekleme hali
        //DatabaseEntities db = new DatabaseEntities();
        //public Users Add(Users user)
        //{
        //    db.users.Add(user); 
        //    db.SaveChanges();

        //    return user;
        //}

        //public void Delete(Users user)
        //{
        //    db.users.Remove(user);
        //    db.SaveChanges();

        //    //db.Entry<Users>(user).State = System.Data.Entity.EntityState.Deleted;
        //    //db.SaveChanges();
        //}

        //public List<Users> GetAll()
        //{
        //   return db.users.ToList();
        //}

        //public void Update(Users user)
        //{
        //   db.Entry<Users>(user).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //}

        #endregion

        public T Add(T entity)
        {
            var result = _dbSet.Add(entity);

          //  var result2 = db.Set<T>().Add(entity);
          // Kapsülleme ile dbset yaptığımız için daha kolay ve pratikleştiriyoruz.
            db.SaveChanges();
            
            // db.users.Add();
            return result;

        }

        public void Delete(T entity)
        {
           //_dbSet.Remove(entity);

            db.Entry<T>(entity).State = EntityState.Deleted;
            db.SaveChanges();
           // T ile yazılan versiyonda bağımlı kalmadan bir genel havuz yapısı oluşturmuş oluyoruz.
         //   db.Entry<Users>(entity).State = EntityState.Deleted;
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {

            // İf yazımının 1. yolu Basic
            //if (filter == null)
            //{
            //  return  _dbSet.ToList();
            //}
            //else
            //{
            //     return _dbSet.Where(filter).ToList();  
            //    // Tablo içersinde gönderilen filtreye göre arama yapıyor
            //}

            // Ternary if
            //2. yol  

            return filter == null 
                ?  _dbSet.ToList()
                : _dbSet.Where(filter).ToList();

        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return db.Set<T>().SingleOrDefault(filter);
        }

        public List<T> GetAll()
        {

         return  _dbSet.ToList();
        }

        public T GetById(int id)
        {
          

           // db.users.SingleOrDefault(i => i.Id == id);
            // SingleOrDefault tek bir değer döndürür find gibide kullanabilirz
            //db.Set<T>().Find(id);
            //db.users.Find(id);

            return _dbSet.Find(id);

        }

        public void Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}
