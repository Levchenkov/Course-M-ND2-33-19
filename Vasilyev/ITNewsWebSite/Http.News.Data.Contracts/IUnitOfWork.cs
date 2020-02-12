using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Http.News.Data.Contracts
{
    public interface IUnitOfWork
    {
        T GetItem<T>(int id) where T : class;
        T GetCategory<T>(int id) where T : class;
        IQueryable<T> GetAllItems<T>() where T : class;
        IQueryable<T> GetAllCategories<T>() where T : class;
        void AddItem<T>(T entity) where T : class;
        void DeleteItem<T>(int id) where T : class;
        void AddCategory<T>(T entity) where T : class;
        void DeleteCategory<T>(int id) where T : class;
        void SaveChanges();
        ITransaction BeginTransaction();
    }
}
