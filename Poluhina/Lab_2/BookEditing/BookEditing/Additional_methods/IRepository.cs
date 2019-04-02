using BookEditing.Models;
using System.Collections.Generic;

namespace BookEditing.Additional_methods
{
    interface IRepository<T>
    {
        void Add(T book);
        List<Book> Change(int id, T newElement);
        void Remove(int id);
        IEnumerable<Book> GetBooks();
        void SerializeAndSave();
    }
}
