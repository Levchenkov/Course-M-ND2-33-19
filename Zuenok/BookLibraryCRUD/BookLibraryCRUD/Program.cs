using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BookLibraryCRUD
{
    [DataContract]
    public class Book
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Title { get; set; }
    }

#region Services

    public interface IRepository<out T>
    {
        T Get(int id);
        T GetLast();
    }

    public interface IBookCRUD : IRepository<Book>
    {
        bool Add(Book book);
        bool Edit(int id);
        bool Delete(int id);
        IEnumerable<Book> GetBooks();
    }

    public class BookRepository : IBookCRUD
    {
        private readonly IList<Book> data;

        public BookRepository() => data = new List<Book>
        {
            new Book {Id = 1, Title = "Title1"},
            new Book {Id = 2, Title = "Title2"},
            new Book {Id = 3, Title = "Title3"}
        };

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
            return true;
        }

        public bool Edit(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result == null) return false;
            EditForm(result);
            return true;
        }

        public bool Delete(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result == null) return false;
            data.Remove(result);
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

    public class BookService
    {
        private readonly IBookCRUD repository;

        public BookService(IBookCRUD repository)
        {
            if (repository != null) this.repository = repository;
            Books = repository?.GetBooks();
        }

        public IEnumerable<Book> Books { get; }

        public Book Get(int id)
        {
            return repository?.Get(id) != null
                ? repository.Get(id)
                : repository?.GetLast();
        }

        public int GetLastId()
        {
            return repository.GetLast().Id;
        }

        public void AddBook(string title)
        {
            Console.WriteLine(repository.Add(new Book
            {
                Id = repository.GetLast().Id + 1, Title = title
            })
                ? $"Book \"{title}\" added successfully."
                : $"Attention!! book \"{title}\" not added.");
        }

        public void EditBook(int id)
        {
            var book = repository.Get(id);
            Console.WriteLine(repository.Edit(id)
                                  ? $"Book \"{book.Title}\" updated successfully."
                                  : $"Attention!! book \"{book.Title}\" not updated.");
        }

        public void DeleteBook(int id)
        {
            var book = repository.Get(id);
            Console.WriteLine(repository.Delete(id)
                                  ? $"Book \"{book.Title}\" deleted successfully."
                                  : $"Attention!! book \"{book.Title}\" not deleted.");
        }
    }

#endregion Services

    internal class Program
    {
        private static void OutBooks(BookService bookService)
        {
            Console.WriteLine("*".PadRight(20, '*'));
            foreach (var book in bookService.Books)
                Console.WriteLine($"Id book [{book.Id}] : {book.Title}");
        }

        private static void Main()
        {
            Console.WriteLine("Hello Books!");

            IBookCRUD repository = new BookRepository();
            var bookService = new BookService(repository);

            try
            {
                Console.WriteLine(bookService.Get(bookService.GetLastId() + 1000).Title);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            bookService.AddBook("War and piece, part 1.");
            Console.WriteLine(bookService.Get(bookService.GetLastId()).Id.ToString(),
                              bookService.Get(bookService.GetLastId()).Title);

            bookService.AddBook("War and piece, part 2.");
            Console.WriteLine(bookService.Get(bookService.GetLastId()).Id.ToString(),
                              bookService.Get(bookService.GetLastId()).Title);

            OutBooks(bookService);

            Console.WriteLine("*".PadRight(20, '*'));
            bookService.EditBook(bookService.GetLastId());
            OutBooks(bookService);

            Console.WriteLine("*".PadRight(20, '*'));
            bookService.DeleteBook(bookService.GetLastId());
            OutBooks(bookService);

            Console.WriteLine();
        }
    }
}