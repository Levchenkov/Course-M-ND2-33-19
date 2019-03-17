using System;

namespace BookCatalog
{
    public class BookRepository : IElement<Book>
    {
        internal BookInitialization initialization;
        public BookRepository()
        {
            initialization = new BookInitialization();
            initialization.InitialInitialization();
        }
        public void Show()
        {
            foreach (var item in initialization.listBooks)
            {
                Console.WriteLine($"\nName: {item.Name}" +
                   $"\nAuthor: {item.Author}" +
                   $"\nYear: {item.Year}" +
                   $"\nGenre: {item.Genre}\n");
            }
        }
        public virtual void Add(Book book)
        {
            initialization.listBooks.Add(book);
        }
        public virtual void Change(int index, Book newBook)
        {
            initialization.listBooks[index] = newBook;
        }
        public virtual void Remove(int index)
        {
            var book = initialization.listBooks[index];
            if (book != null)
                initialization.listBooks.Remove(book);
        }
        public virtual int GetCount()
        {
            return initialization.listBooks.Count;
        }
    }
}

