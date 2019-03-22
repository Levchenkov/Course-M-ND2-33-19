using System.Collections.Generic;
using Lab2.DAL.Entities;

namespace Lab2.DAL.Interfaces
{
    public interface IGenericFileHandler<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> Load();
        void Save(List<TEntity> entities);

    }
}