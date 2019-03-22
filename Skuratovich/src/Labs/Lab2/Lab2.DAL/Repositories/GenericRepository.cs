using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.DAL.Entities;
using Lab2.DAL.Interfaces;

namespace Lab2.DAL.Repositories
{
    public class GenericRepository<TEntity>: IRepository<TEntity> where TEntity : EntityBase
    {
        // Context
        private readonly IList<TEntity> data;
        private readonly IGenericFileHandler<TEntity> fileHandler;

        public GenericRepository(IGenericFileHandler<TEntity> fileHandler)
        {
            this.fileHandler = fileHandler;
            data = fileHandler.Load().ToList();
        }

        public void Add(TEntity entity) => data.Add(entity);

        public void Delete(int Id)
        {
            var book = GetByID(Id);
            data.Remove(book);
        }

        public void Edit(TEntity entity)
        {
            var result = data.FirstOrDefault(x => x.Id == entity.Id);

            if (result != null)
            {
                result = entity;
            }
            else
            {
                throw new Exception("Element not found");
            }
        }

        public List<TEntity> GetAll()
        {
            return data as List<TEntity>;
        }

        public TEntity GetByID(int? id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            throw new Exception("Element not found");
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
