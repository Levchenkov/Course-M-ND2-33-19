using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class BookRepository: IRepository<Book>
    {
        private readonly List<Book> bookList;
        private IFileWorker obb1;

        public BookRepository(IFileWorker obb)
        {
            obb1 = obb;
            bookList = obb1.ReadFromJsonFile<List<Book>>("output1.json");
        }

        public Book Get(int id)
        {
            var bookGot = bookList.FirstOrDefault(x => x.ID == id);
            if (bookGot != null)
            {
                return bookGot;
            }

            throw new Exception("Book with such id not found");
        }
        public void Add(Book book)
        {
            bookList.Add(book);
        }
        public void Edit(Book book)
        {
            Remove(book.ID);
            Add(book);
        }
        public void Remove(int id)
        {
            Book forDel = Get(id);
            bookList.Remove(forDel);
        }
        public void Save()
        {
           obb1.WriteToJsonFile<List<Book>>("output1.json", bookList);
        }
    }
}
