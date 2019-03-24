using System;
using System.Collections.Generic;
using System.Text;

namespace WebLibrary.Models
{
    public interface IBookService<T>
    {
        void Add(T entity);
        void Remove(int id);
        void Change(T entity);
        T Get(int id);
    }
}
