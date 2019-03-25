using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
namespace Library
{

    public class BookCatalog
    {
        static void Main(string[] args)
        {
            JsonFileHandler fileHandler = new JsonFileHandler();
            BookService library = new BookService(fileHandler);
            Console.WriteLine("-=====Menu=====-");
            Console.WriteLine("1 - Show catalog");
            Console.WriteLine("2 - Add new book");
            Console.WriteLine("3 - Remove book");
            Console.WriteLine("4 - Change book");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("-==============-");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    library.ShowCatalog();
                    break;
                case 2:
                    Book new_book = new Book();
                    Console.WriteLine("Input information about book");
                    try
                    {
                        Console.WriteLine("Input new ID");
                        new_book.Id = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        throw new Exception("Incorrect input!");
                    }
                    Console.WriteLine("Input new Title");
                    new_book.Title = Console.ReadLine();
                    Console.WriteLine("Input new amount of Pages");
                    new_book.Pages = Convert.ToInt32(Console.ReadLine());
                    library.Add(new_book);
                    break;
                case 3:
                    try
                    {
                        library.ShowCatalog();
                        Console.WriteLine("Input necessary id");
                        library.Remove(Convert.ToInt32(Console.ReadLine()));
                    }
                    catch
                    {
                        throw new Exception("Incorrect input!");
                    }
                    break;
                case 4:
                    Book change_book = new Book();
                    library.ShowCatalog();
                    try
                    {
                        Console.WriteLine("Input ID");
                        change_book.Id = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        throw new Exception("Incorrect input!");
                    }
                    Console.WriteLine("Input new information about book");
                    Console.WriteLine("Input new Title");
                    change_book.Title = Console.ReadLine();
                    Console.WriteLine("Input new amount of Pages");
                    change_book.Pages = Convert.ToInt32(Console.ReadLine());
                    library.Change(change_book);
                    break;
                case 0:
                    break;
                default: throw new Exception("Incorrect input!");
            }
        }

    }
}