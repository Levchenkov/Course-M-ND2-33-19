using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalogue;

namespace BookCatalogueConsole
{
    public class BookManager
    {
        private readonly BookService bookService;

        public BookManager(BookService bookService)
        {
            if(bookService != null)
            {
                this.bookService = bookService;
            }
            else
            {
                bookService = new BookService(new JsonBookRepository());
            }
        }

        public BookManager()
        {
            bookService = new BookService(new JsonBookRepository());
        }

        public void AddBook()
        {
            bookService.AddBook(GetBookDetailsFromUser(new Book()));
        }

        private Book GetBook()
        {
            Book book = bookService.GetBook(GetIdFromUser());
            return book;
        }

        public void FindBook()
        {
            Console.WriteLine(GetBook());
        }

        public void GetBooks()
        {
            IEnumerable<Book> books = bookService.GetBooks();
            if(books.Count() == 0)
            {
                Console.WriteLine("No books currently catalogued");
            }
            else
                foreach (Book b in books)
            {
                Console.WriteLine(b);
            }
        }

        public void Remove()
        {
            bookService.Remove(GetIdFromUser());
        }

        public void Update()
        {
            Book book = GetBook();
            bookService.Update(GetBookDetailsFromUser(book));
        }

        private int GetIdFromUser()
        {
            Console.WriteLine("Please enter the id of the book you are interested in");
            return ReviewInput(1);
        }

        public int ReviewInput(int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            while (true)
            {
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out int input))
                {
                    if (input >= minValue & input <= maxValue)
                    {
                        Console.WriteLine();
                        return input;
                    }
                }
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
            }
        }

        private Book GetBookDetailsFromUser(Book book)
        {
            Console.WriteLine("Please enter book's name:");
            book.Name = Console.ReadLine();
            Console.WriteLine("Please enter the name and last name of the book's author");
            book.Author = Console.ReadLine();
            Console.WriteLine("Please enter the date of issue of the book");
            book.YearOfIssue = ReviewInput(-2000, DateTime.Now.Year);
            return book;
        }
    }
}
