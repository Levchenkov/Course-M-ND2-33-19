using System.Collections.Generic;
using Lab2.DAL.Entities;

namespace Lab2.DAL.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        //TODO: Check Task
        //Task<List<T>> GetAll();
        //Task<T> GetByID(int? id);
        List<T> GetAll();
        T GetByID(int? id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(int Id);

        //TODO: Check
        void Save();
        //Task<int> Save();
    }
}