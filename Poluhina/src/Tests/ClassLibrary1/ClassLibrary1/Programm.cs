namespace BookCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository();
            books.Change(1, new Book { Author = "Leo Tolstoy", Name = "War and Peace", Year = 1865, Genre = "novel" });
            books.Add(new Book { Author = "Ivan Turgenev ", Name = "Notes hunter ", Year = 1852, Genre = "novel" });
            books.Remove(3);
            books.Show();
            books.initialization.JsonSerializer();
            Console.ReadKey();
        }
    }
}
