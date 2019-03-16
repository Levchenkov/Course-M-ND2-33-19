using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryCRUD
{
    public class LibraryRepository : ILibrary
    {
        private readonly IList<Book> data;
        private readonly LibraryDBInitializator db;

        public LibraryRepository()
        {
            db = new LibraryDBInitializator();
            data = db.Books;
        }


        public Book Get(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            return result ?? throw new Exception($"Element with id = {id} not found.");
        }

        public Book GetLast()
        {
            var result = data.LastOrDefault();
            return result ?? throw new Exception("Book library is empty.");
        }

        public bool Add(Book book)
        {
            if (book == null) return false;
            data.Add(book);
            db.SetDbToJson();
            return true;
        }

        public bool Edit(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result == null) return false;
            EditForm(result);
            db.SetDbToJson();
            return true;
        }

        public bool Delete(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result == null) return false;
            data.Remove(result);
            db.SetDbToJson();
            return true;
        }

        public IEnumerable<Book> GetBooks()
        {
            return data;
        }

        private void EditForm(Book book)
        {
            Console.WriteLine($"Book \"{book.Title}\" edit.\n");
            Console.Write("Enter new book title: ");
            book.Title = Console.ReadLine();
            Console.WriteLine("".PadRight(50, '\u2500'));
        }
    }
}