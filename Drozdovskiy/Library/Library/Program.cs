using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
namespace Library
{
    public class BookCatalog
    {

        private readonly IList<Book> catalog;
        private FileInfo fileinfo = new FileInfo(@"catalog.json");
        public BookCatalog()
        {
            if (File.Exists(@"catalog.json") && fileinfo.Length != 0)
            {
                catalog = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(@"catalog.json"));
            }
            else
            {
                string first_book_title, input;
                int first_book_pages;
                Console.WriteLine("Input the first book's title");
                first_book_title = Console.ReadLine();
                Console.WriteLine("Input the first book's amount of pages");
                input = Console.ReadLine();
                first_book_pages = Convert.ToInt32(Validate(input));
                catalog = new List<Book>
                {
                    new Book
                    {
                    Id = 1,
                    Title = first_book_title,
                    Pages = first_book_pages
                    }
                };
                File.WriteAllText(@"catalog.json", JsonConvert.SerializeObject(catalog));
                Console.Clear();
            }
        }
        public string Validate(string input)
        {
            int tempInt;
            if (Int32.TryParse(input, out tempInt))
            {
                return input;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Input the correct number");
                    input = Console.ReadLine();
                    if (Int32.TryParse(input, out tempInt))
                    {
                        return input;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        public void ShowCatalog()
        {
            for (int i = 0; i < catalog.Count; i++)
                Console.WriteLine(catalog.ElementAt(i).Id + " " + catalog.ElementAt(i).Title + " " + catalog.ElementAt(i).Pages);
            Console.WriteLine("Press any key");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            string input;
            int id;
            BookCatalog library = new BookCatalog();
            while (true)
            {
                Console.WriteLine("             || Menu ||");
                Console.WriteLine("1 - Look through the books catalog");
                Console.WriteLine("2 - Add a new book to the catalog");
                Console.WriteLine("3 - Remove an existing book from the catalog");
                Console.WriteLine("4 - Change an existing book of the catalog");
                Console.WriteLine("0 - End");
                input = Console.ReadLine();
                int choice = Convert.ToInt32(library.Validate(input));
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        library.ShowCatalog();
                        break;
                    case 2:
                        Book new_book = new Book();
                        new_book.Id = library.catalog.Count() + 1;
                        Console.WriteLine("Input the new book's title");
                        new_book.Title = Console.ReadLine();
                        Console.WriteLine("Input the new book's amount of pages");
                        input = Console.ReadLine();
                        new_book.Pages = Convert.ToInt32(library.Validate(input));
                        library.Add(new_book);
                        Console.Clear();
                        break;
                    case 3:
                        library.ShowCatalog();
                        Console.WriteLine("Input an id of the book, which you wan't to remove");
                        input = Console.ReadLine();
                        id = Convert.ToInt32(library.Validate(input)) - 1;
                        library.Remove(id);
                        Console.Clear();
                        break;
                    case 4:
                        library.ShowCatalog();
                        Console.WriteLine("Input an id of the book, which you wan't to change");
                        input = Console.ReadLine();
                        id = Convert.ToInt32(library.Validate(input)) - 1;
                        library.Change(id);
                        Console.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default: throw new Exception("Incorrect input");
                }
                if (choice == 0)
                {
                    break;
                }
            }
        }
        public void Add(Book new_element)
        {
            catalog.Add(new_element);
            File.WriteAllText(@"catalog.json", JsonConvert.SerializeObject(catalog));
        }
        public void Remove(int id)
        {
            catalog.RemoveAt(id);

            if (catalog.ElementAt(0).Id != 1)
                for (int i = 0; i < catalog.Count(); i++)
                    catalog.ElementAt(i).Id--;

            for (int i = 0; i < catalog.Count() - 1; i++)
            {
                if (catalog.ElementAt(i + 1).Id - catalog.ElementAt(i).Id > 1)
                    catalog.ElementAt(i + 1).Id--;
            }
            File.WriteAllText(@"catalog.json", JsonConvert.SerializeObject(catalog));
        }
        public void Change(int id)
        {
            File.WriteAllText(@"catalog.json", JsonConvert.SerializeObject(catalog));
            Console.WriteLine("Which field do you wan't to change?");
            Console.WriteLine("1 - Title");
            Console.WriteLine("2 - Pages");
            string input = Console.ReadLine();
            int choice = Convert.ToInt32(Validate(input));
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Input the new title");
                    catalog.ElementAt(id).Title = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Input the new amount of pages");
                    catalog.ElementAt(id).Pages = Convert.ToInt32(Console.ReadLine());
                    break;
                default: throw new Exception("Incorrect input");
            }
        }
    }
    public class Book
    {
        public int Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public int Pages
        {
            get;
            set;
        }
    }
}