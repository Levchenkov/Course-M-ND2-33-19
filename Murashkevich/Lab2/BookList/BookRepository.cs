using System;
using System.Collections.Generic;
using System.Linq;

namespace BookList
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly List<Book> listBooks;
        private readonly IFileHandler<Book> fileHandler;

        public BookRepository(IFileHandler<Book> fileHandler)
        {
            this.fileHandler = fileHandler;
            listBooks = fileHandler.Load();
        }

        public Book Get(int id)
        {
            var index = listBooks.FindIndex(x => x.Id == id);
            return listBooks[index];
        }

        public int GetIndex(int id)
        {
            return listBooks.FindIndex(x => x.Id == id);
        }

        public void Add(Book obj)
        {
            int id = new int();
            if (listBooks.Count == 0)
                obj.Id = 1;
            else
            {
                id = listBooks.LastOrDefault().Id;
                obj.Id = ++id;
            }
            listBooks.Add(obj);
        }

        public void Edit(int id, Book obj)
        {
            var index = listBooks.FindIndex(x => x.Id == id);
            listBooks[index] = obj;
        }

        public void Delete(int id)
        {
            var index = listBooks.FindIndex(x => x.Id == id);
            listBooks.RemoveAt(index);
        }

        public void SaveChanges()
        {
            fileHandler.Save(listBooks);
        }
    }
}
