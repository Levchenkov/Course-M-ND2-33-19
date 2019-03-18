using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace BookCatalogJSON
{
    public class Program
    {
        public static void DisplayBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                WriteLine($"Name of book: {book.Name}\t year of book: {book.Year}\t author of book: {book.Author}");
            }
        }
        public static string ShowOptions()
        {
            WriteLine("1. add book");
            WriteLine("2. edit book");
            WriteLine("3. del book");
            var option = ReadLine();
            return option;
        }

        public static Book AddBook()
        {
            WriteLine("Name of book:");
            var name = ReadLine().Trim();
            WriteLine("Year of book:");
            var year = Convert.ToInt32(ReadLine().Trim());
            WriteLine("Author of book:");
            var author = ReadLine().Trim();
            return new Book(name, year, author);
        }
        public static int DelBook()
        {
            WriteLine("Which book would you like to del? input ID, start from 0");
            return Convert.ToInt32(ReadLine());
        }
        public static List<Book> EditBook(List<Book> b)
        {
            WriteLine("Which book would you like to edit? input ID, start from 0");
            int idEditBook = Convert.ToInt32(ReadLine());
            WriteLine("new name:");
            var newName = ReadLine();
            b[idEditBook].Name = newName;
            WriteLine("new year:");
            var newYear = Convert.ToInt32( ReadLine());
            b[idEditBook].Year = newYear;
            WriteLine("new Author:");
            var newAuthor = ReadLine();
            b[idEditBook].Author = newAuthor;
            return b;
        }
        static void Main(string[] args)
        {
            List<Book> listBooks = new List<Book>();
            Book book = new Book("My life", 1990, "Romanov");
            Book book1 = new Book("Your life", 2000, "Stepanov");
            Book book2 = new Book("This life", 2010, "Pavlov");
            listBooks.Add(book);
            listBooks.Add(book1);
            listBooks.Add(book2);
            switch (ShowOptions())
            {
                case "1"://add
                    var newBook = AddBook();
                    listBooks.Add(newBook);
                    break;
                case "2"://edit
                    DisplayBooks(listBooks);
                    DisplayBooks(EditBook(listBooks));
                    break;
                case "3"://del
                    DisplayBooks(listBooks);
                    listBooks.RemoveAt(DelBook());
                    DisplayBooks(listBooks);
                    break;
            }

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"c:\BookCatalog.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listBooks);
            }
            ReadLine();
        }
    }
}
