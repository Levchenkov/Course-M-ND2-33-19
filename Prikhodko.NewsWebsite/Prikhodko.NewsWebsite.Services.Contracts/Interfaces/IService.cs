using System.Collections.Generic;

namespace Prikhodko.NewsWebsite.Services.Contracts.Interfaces
{
    public interface IService<T>
    {
        void Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void Delete(T item);
    }
}
