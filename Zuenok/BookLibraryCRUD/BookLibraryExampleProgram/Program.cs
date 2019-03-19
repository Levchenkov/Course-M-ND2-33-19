using System;
using BookLibraryCRUD;

namespace BookLibraryExampleProgram
{
    /// <summary>
    ///     Example of using BookLibraryCRUD library
    /// </summary>
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

            ILibrary repository = new LibraryRepository();
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