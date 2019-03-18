using System;
using ClassLibrary1;

namespace TestLib
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonFileHandler jsonFileHandler = new JsonFileHandler();
            BookRepository bookRepository = new BookRepository(jsonFileHandler);

            //bookRepository.Add(new Book { Id = 4, Title = "New book" });

            bookRepository.SaveChanges();

            WriteBook(bookRepository.Get(1));
            WriteBook(bookRepository.Get(3));
            WriteBook(bookRepository.Get(2));
            WriteBook(bookRepository.Get(4));


        }

        static void WriteBook(Book book)
        {
            Console.WriteLine("Book id: {0}, title: {1}", book.Id, book.Title);
        }
    }
}
