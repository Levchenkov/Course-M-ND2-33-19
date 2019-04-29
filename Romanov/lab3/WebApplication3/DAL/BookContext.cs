using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using Newtonsoft.Json;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Data.Entity.Core.Objects;

namespace WebApplication3.DAL
{
    public class BookContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified);

            foreach (var item in modifiedEntities)
            {
                var itemType = ObjectContext.GetObjectType(item.Entity.GetType());
                if (itemType == typeof(Book))
                {
                    var bookID = ((Book)item.Entity).BookID;
                    var originalEntity = Set(itemType).AsNoTracking().Cast<Book>().First(x => x.BookID == bookID);
                    Log log = new Log()
                    {
                        ID = bookID,
                        DateChanged = DateTime.Now,
                        OldValue = originalEntity,
                        NewValue = (Book)item.Entity
                    };
                    File.AppendAllText(HttpContext.Current.Server.MapPath("~/App_Data/Changes.json"), JsonConvert.SerializeObject(log));


                }
            }

            return base.SaveChanges();
        }
    }


    public class Log
    {
        public int ID { get; set; }
        public DateTime DateChanged { get; set; }
        public Book OldValue { get; set; }
        public Book NewValue { get; set; }
    }

}