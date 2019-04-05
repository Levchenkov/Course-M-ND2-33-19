using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts.Entities;

namespace Course.Library.Data.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        T Get<T>(int id) where T : class;
        IEnumerable<Genre> GetGenres();
        IEnumerable<Language> GetLanguages();
        ITransaction BeginTransaction();
        void Add<T>(T entity) where T : class;
        IEnumerable<Book> GetAll<T>() where T : class;
        void Remove<T>(int id) where T : class;
    }
}
