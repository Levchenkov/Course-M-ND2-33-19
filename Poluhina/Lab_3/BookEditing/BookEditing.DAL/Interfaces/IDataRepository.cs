using System.Collections.Generic;

namespace BookEditing.DAL.Interfaces
{ 
    public interface IDataRepository<T> where T : class
    {
        IEnumerable<T> GetList();
        void Add(T item);
        void Change(T item);
        void Remove(int id);
        T Get(int id);

        //MultiSelectList list();
    }
}
