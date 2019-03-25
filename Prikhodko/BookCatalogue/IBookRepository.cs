using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogue
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        void Add(Book item);
        void Update(Book item);
        void Remove(int id);
    }
}
