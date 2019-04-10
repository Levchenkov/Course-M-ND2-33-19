using System;

namespace BookCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository(new JsonFormat());
            books.Change(1, new Book { Id = 1, Author = "Leo Tolstoy", Name = "War and Peace", Year = 1865, Genre = "novel" });
            books.Add(new Book { Id = 5, Author = "Ivan Turgenev ", Name = "Notes hunter ", Year = 1852, Genre = "novel" });
            books.Remove(5);
            books.Show();
            books.SerializeAndSave();
            Console.ReadKey();
        }
    }
}
