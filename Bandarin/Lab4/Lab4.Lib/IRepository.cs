using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Lib
{
    public interface IRepository<T> where T:class
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void SaveChanges();
    }
}
