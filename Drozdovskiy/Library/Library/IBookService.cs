using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IBookService<T>
    {
        void Add(T entity);
        void Remove(int id);
        void Change(T entity);
        void ShowCatalog();
        T Get(int id);
    }
}
