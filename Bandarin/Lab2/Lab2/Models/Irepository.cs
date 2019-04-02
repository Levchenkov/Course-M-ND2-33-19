using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public interface IRepository<T>
    {
        T Get(int id);

        void Add(T book);
        void Edit(T book);
        void Remove(int id);
        void Save();
    }
}