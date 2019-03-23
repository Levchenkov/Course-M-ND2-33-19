using System;
using System.Collections.Generic;
using System.IO;

namespace BookCatalog
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> listBooks { get; set; }
        private JsonFormat jsonFormatter;
        public BookRepository()
        {
            jsonFormatter = new JsonFormat();
            if (File.Exists(@"D:\book.json"))
            {
                listBooks = jsonFormatter.Deserialize(listBooks);
            }
            else
            {
                listBooks = new List<Book>
            {
                new Book{ Id=1, Author= "Michael Bulgakov", Name="The Master and Margarita", Year=1929, Genre="novel" },
                new Book{ Id=2,Author= "Ivan Turgenev", Name="Asya", Year=1858, Genre="novel"},
                new Book{ Id=3,Author= "Nikolai Gogol", Name="Dead Souls", Year=1842, Genre="novel"},
                new Book{ Id=4,Author= "Alexey Tolstoy ", Name="Going around ", Year=1922, Genre="novel"}
            };
                jsonFormatter.Serialize(listBooks);
            }
        }
        public void SerializeAndSave()
        {
            jsonFormatter.Serialize(listBooks);
        }
        public void Show()
        {
            foreach (var item in listBooks)
            {
                Console.WriteLine($"\nId: {item.Id}" +
                   $"\nName: {item.Name}" +
                   $"\nAuthor: {item.Author}" +
                   $"\nYear: {item.Year}" +
                   $"\nGenre: {item.Genre}\n");
            }
        }
        public virtual void Add(Book book)
        {
            listBooks.Add(book);
        }
        public virtual void Change(int id, Book newBook)
        {
            var book = listBooks?.Find(x => x.Id == id);
            if (book != null)
            {
                book = newBook;
            }
        }
        public virtual void Remove(int id)
        {
            var book = listBooks?.Find(x => x.Id == id);
            if (book != null)
                listBooks.Remove(book);
        }
        public virtual int GetCount()
        {
            return listBooks.Count;
        }
    }
}

