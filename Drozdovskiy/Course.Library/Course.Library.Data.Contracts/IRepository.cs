using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts.Entities;

namespace Course.Library.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void SaveChanges();
        IEnumerable<Book> GetAll();
        IEnumerable<Genre> GetGenres();
        IEnumerable<Language> GetLanguages();
    }
}

