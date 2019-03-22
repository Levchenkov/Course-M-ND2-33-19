using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEditor.Models
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
        void SaveChanges();
    }
}
