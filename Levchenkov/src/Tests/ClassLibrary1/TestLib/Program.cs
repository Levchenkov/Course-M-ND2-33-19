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

            //bookRepository.SaveChanges();

            Book newBook = bookRepository.Get(3);

            Console.WriteLine("Book id: {0}, book title: {1}", newBook.Id, newBook.Title);


            //Console.WriteLine("Hello World!");

        }
    }
}
