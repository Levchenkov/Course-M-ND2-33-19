using System;
using BookLibrary;
using System.Threading;

namespace HometaskN1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowDialog();
            var BookRepo = new BookRepository();
            ConsoleKeyInfo key;
            var ok = false;
            var book = new Book();
            int id;
            string title;
            do
            {
                key = Console.ReadKey();
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D0:
                            Console.WriteLine("\nEnter Id...");
                            ok = int.TryParse(Console.ReadLine(), out id);
                            book = BookRepo.Get(id);
                            ShowBook(book);
                            break;
                        case ConsoleKey.D1:
                            Console.WriteLine("\nEnter Id...");
                            ok = int.TryParse(Console.ReadLine(), out id);
                            Console.WriteLine("\nEnter Title...");
                            title = Console.ReadLine();
                            book = new Book(id, title);
                            BookRepo.Add(book);
                            BookRepo.SaveChanges();
                            Console.WriteLine("\nBook added:");
                            ShowBook(book);
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("\nEnter Id...");
                            ok = int.TryParse(Console.ReadLine(), out id);                            
                            Console.WriteLine("\nEnter Title...");
                            title = Console.ReadLine();
                            book = new Book(id, title);
                            BookRepo.Change(book);
                            BookRepo.SaveChanges();
                            Console.WriteLine("\nBook changed:");
                            ShowBook(book);
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("\nEnter Id...");
                            ok = int.TryParse(Console.ReadLine(), out id);
                            BookRepo.Delete(id);
                            BookRepo.SaveChanges();
                            Console.WriteLine("\nBook: {0} deleted", id);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ok = false;
                    ShowDialog();
                    continue;
                }
            } while (key.Key != ConsoleKey.Escape || !ok);
        }

        static void ShowBook(Book book)
        {
            Console.WriteLine(book.Id);
            Console.WriteLine(book.Title);
        }

        static void ShowDialog()
        {
            Console.WriteLine("Select what do you want to do with a Book in Repository...");
            Console.WriteLine("0. Get");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Change");
            Console.WriteLine("3. Delete");
        }
    }
}
