using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts;
using Course.Library.Data.Contracts.Entities;

namespace Course.Library.Data.EntityFramework
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            var dbSet = dbContext.Set<T>();
            
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            var dbSet = dbContext.Set<T>();
            var result = dbSet.Find(id);
            return result;
        }

        public IEnumerable<Book> GetAll()
        {
            var dbSet = dbContext.Set<Book>();
            var result = dbSet.ToList();
            return result;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var dbSet = dbContext.Set<Genre>();
            var result = dbSet.ToList();
            return result;
        }

        public IEnumerable<Language> GetLanguages()
        {
            var dbSet = dbContext.Set<Language>();
            var result = dbSet.ToList();
            return result;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<T>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
            SaveChanges();
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            dbContext.Set<T>().AddOrUpdate(entity);
        }
    }
}
