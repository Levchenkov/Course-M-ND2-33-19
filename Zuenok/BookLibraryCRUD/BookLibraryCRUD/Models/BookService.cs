using System;
using System.Collections.Generic;

namespace BookLibraryCRUD
{
    public class BookService
    {
        private readonly ILibrary repository;

        public BookService(ILibrary repository)
        {
            if (repository != null) this.repository = repository;
            Books = repository?.GetBooks();
        }

        public IEnumerable<Book> Books { get; }

        public Book Get(int id)
        {
            return repository?.Get(id) != null
                ? repository.Get(id)
                : repository?.GetLast();
        }

        public int GetLastId()
        {
            return repository.GetLast().Id;
        }

        public void AddBook(string title)
        {
            Console.WriteLine(repository.Add(new Book
            {
                Id = repository.GetLast().Id + 1, Title = title
            })
                ? $"Book \"{title}\" added successfully."
                : $"Attention!! book \"{title}\" not added.");
        }

        public void EditBook(int id)
        {
            var book = repository.Get(id);
            Console.WriteLine(repository.Edit(id)
                                  ? $"Book \"{book.Title}\" updated successfully."
                                  : $"Attention!! book \"{book.Title}\" not updated.");
        }

        public void DeleteBook(int id)
        {
            var book = repository.Get(id);
            Console.WriteLine(repository.Delete(id)
                                  ? $"Book \"{book.Title}\" deleted successfully."
                                  : $"Attention!! book \"{book.Title}\" not deleted.");
        }
    }
}