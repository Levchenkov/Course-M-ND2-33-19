using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IList<Book> data;
        private readonly IFileHandler fileHandler;

        public BookRepository(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            data = fileHandler.Load().ToList();
        }


        public Book Get(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            throw new Exception("Element not found");
        }


        public void Add(Book item)
        {
            data.Add(item);
        }


        public bool Edit(Book item)
        {
            int index = data.IndexOf(item);
            if (index == -1) {
                return false;
            }

            Book book = data.ElementAt(index);
            book.Title = item.Title;

            return true;
        }


        public bool Remove(Book item)
        {
            throw new NotImplementedException();
        }
    }
}