using MyClassLibrary;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new BookRepository(new JsonFileHandler());
            a.Add(new Book {Title = "asf", Id = 423 });

            a.SaveChanges();
            Console.ReadKey();
        }
    }
}
