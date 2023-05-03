using OKUL_OTOMASYON.Entities.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.DataAccessLayer.ContextBase
{
    public class DatabaseEntities: DbContext
    {

        #region Teori 
        //todo base() ifadesi ne için kuıllanılır?

        // Veri tabanı bağlantısı sırasında ne işlem yapılıcağının ayarlanmsı hakkında bilgiler.


        /*            Database.SetInitializer(new DropCreateDatabaseAlways<DataAccessClass>()); 
                 ifadesi de bir tablo initilaze stratejisidir. Tablolar SetInıtilaizerin içine koyacağınız argumana göre initilaze edilir.
        CreateDatabaseIfNotExist: Eğer sunucuda, oluşturmak istenen database bulunmuyorsa yeni databasei oluşturur. Varsayılan initilazie ayarı budur.

        DropCreateDatabaseIfModelChanges: Eğer sunucudaki databasein şema ya da model yapısında bir değişiklik varsa databasei önce siler sonra yeniden oluşturur.

        DropDatabaseAlways : Her zaman databasei önce sunucudan siler sonra yeniden oluşturur.
                    //Başlatmayı ayarlama metodudur. */

        #endregion


        public DatabaseEntities()
        {

          Database.SetInitializer<DatabaseEntities>(null);
        }

        public DbSet<Alan> Alan { get; set; }
        public DbSet<Cinsiyet> Cinsiyet { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subeler> Subeler { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // database sql tarafında ne ise onu kullanıcak

            modelBuilder.Entity<Alan>().ToTable("Alan");
            modelBuilder.Entity<Cinsiyet>().ToTable("Cinsiyet");
            modelBuilder.Entity<Dersler>().ToTable("Dersler");
            modelBuilder.Entity<Students>().ToTable("Students");
            modelBuilder.Entity<Subeler>().ToTable("Subeler");
            modelBuilder.Entity<Teachers>().ToTable("Teachers");

          


           base.OnModelCreating(modelBuilder);
        }




    }
}
