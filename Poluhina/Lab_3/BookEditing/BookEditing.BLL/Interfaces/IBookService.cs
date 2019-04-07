using BookEditing.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEditing.BLL.Interfaces
{
   public interface IBookService<T> where T : class
    {
        IEnumerable<T> GetList();
        void Add(T item);
        void Change(T item);
        void Remove(int id);
        T Get(int id);
    }
}
