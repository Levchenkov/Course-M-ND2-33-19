using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Contracts;

namespace Lab2.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        // Context
        private readonly IList<T> data;
        private readonly IFileHandler<T> fileHandler;

        // Constructor
        protected RepositoryBase(IFileHandler<T> fileHandler)
        {
            this.fileHandler = fileHandler;
            data = fileHandler.Load().ToList();
        }

        public void Create(T entity) => data.Add(entity);

        public void Delete(T entity)
        {
            if (!data.Remove(entity))
            {
                throw new Exception("Element not found");
            }
        }

        public IEnumerable<T> GetAll()
        {
            return data;
        }

        public void Save() => fileHandler.Save(data.ToList());

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return data.FirstOrDefault(predicate);
        }

        public int Max(Func<T, int> predicat)
        {
            if (data.Count == 0)
            {
                return -1;
            }
            return data.Max(predicat);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
