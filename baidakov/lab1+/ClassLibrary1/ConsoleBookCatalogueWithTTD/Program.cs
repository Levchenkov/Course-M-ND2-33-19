using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace ConsoleBookCatalogueWithTTD
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new JsonFileHandler();
            var booklist = new BookRepository(books);
            IList<Book> data = booklist.View();
            Console.WriteLine("Welcome to Books catalogue");
            string choice = "";
            int iId;
            string iTitle = "";
            while (choice != "q")
            {
                Console.WriteLine("Press 'w' to wiew all books in catalogue");
                Console.WriteLine("Press 'a' to Add new book");
                Console.WriteLine("Press 'd' to Delete book");
                Console.WriteLine("Press 'u' to Update book info");
                Console.WriteLine("Press 'q' to Quit");
                Console.WriteLine("Make Your choice");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "w":
                        Console.WriteLine();
                        Console.WriteLine("Books in catalogue");
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Id \t Title ");
                        Console.WriteLine("********************************************");
                       foreach (var b in data)
                        {
                            Console.WriteLine($"{ b.Id} { b.Title}");
                        }
                        //Console.WriteLine(booklist.View());
                        Console.WriteLine("********************************************");
                        Console.WriteLine();
                        break;
                    case "a":
                        Console.WriteLine("***Add new book***");
                        Console.WriteLine("Enter new book Id:");
                        iId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new book Name:");
                        iTitle = Console.ReadLine();
                        booklist.Add(new Book { Title = iTitle, Id = iId });
                        Console.WriteLine($"Added book '{iTitle}'");
                        break;
                    case "d":
                        Console.WriteLine("***Deleting book***");
                        Console.WriteLine("Enter id book to delete:");
                        iId = Convert.ToInt32(Console.ReadLine());
                        booklist.Delete(iId);
                        Console.WriteLine($"Book has been deleted");
                        break;
                    case "u":
                        Console.WriteLine("**Change book info***");
                        Console.WriteLine("Enter book index:");
                        iId = Convert.ToInt32(Console.ReadLine());
                        booklist.Get(iId);
                        Console.WriteLine("Enter new book Id:");
                        int iId2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new book Name:");
                        iTitle = Console.ReadLine();
                        booklist.Edit(iId, new Book { Title = iTitle, Id = iId2 });
                        Console.WriteLine($"Book has been updated");
                        break;
                    case "q":
                        Console.WriteLine("Quit...");
                        break;
                    default:
                        Console.WriteLine("Incorrect choise");
                        break;
                }
                booklist.SaveChanges();
            }
        }
    }
}
