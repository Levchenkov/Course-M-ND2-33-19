using BookEditing.BLL.DTO;
using System.Collections.Generic;

namespace BookEditing.BLL.Interfaces
{
    public interface IBookService<T> where T : class
    {
        IEnumerable<T> GetList();
        void Add(T item);
        void Change(T item);
        void Remove(int id);
        T Get(int id);
        List<LanguageDTO> GetLanguageDTO();
    }
}
