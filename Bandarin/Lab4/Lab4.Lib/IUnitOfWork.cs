using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Lib
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        
        T Get<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Remove<T>(int id) where T : class;
    }
}
