using ClassLibrary;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepository a = new BookRepository();

            a.Delete(1);

            a.SaveBookRepository();

            Console.ReadKey();
        }
    }
}
