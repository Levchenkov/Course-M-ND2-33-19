using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikhodko.BookCatalogue.Service.Contracts.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Remove(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
