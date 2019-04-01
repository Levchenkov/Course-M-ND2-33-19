using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikhodko.BookCatalogue.Data.Contracts.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Remove(int id);
        IEnumerable<T> GetAll();
    }
}
