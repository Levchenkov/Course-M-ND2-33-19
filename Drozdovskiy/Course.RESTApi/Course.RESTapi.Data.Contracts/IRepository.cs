using Course.RESTapi.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.RESTapi.Data.Contracts
{
    public interface IRepository<T> where T:class
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        IEnumerable<Book> GetAll();
        void SaveChanges();
    }
}
