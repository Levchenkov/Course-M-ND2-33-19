using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogue;

namespace BookCatalogueConsole
{
    class Program
    {
        static string[] menu = new string[]
        {
            "1. Show all books",
            "2. Add a book",
            "3. Find a book",
            "4. Update book's info",
            "5. Delete a book",
            "6. Exit"
        };
        static BookManager bm = new BookManager();

        static void Main(string[] args)
        {
            DoUserAction();
            Console.ReadLine();
        }

        static void DoUserAction()
        {
            while(true)
            {
                ShowMenu();
                int userChoice = bm.ReviewInput(0, menu.Length);
                switch (userChoice)
                {
                    case 1:
                        bm.GetBooks();
                        break;
                    case 2:
                        bm.AddBook();
                        break;
                    case 3:
                        bm.FindBook();
                        break;
                    case 4:
                        bm.Update();
                        break;
                    case 5:
                        bm.Remove();
                        break;
                    default: Console.WriteLine("Closing the app");
                        break;
                }
                if (userChoice == 6)
                {
                    break;
                }
                Console.ReadLine();
            }
        }
        
        static void ShowMenu()
        {
            Console.WriteLine("Please select action:");
            Console.WriteLine("");
            foreach(string s in menu)
            {
                Console.WriteLine(s);
            }
        }
    }
}
