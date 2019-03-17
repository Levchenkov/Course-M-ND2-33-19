using System;
using System.Collections.Generic;

namespace BookLibraryCRUD
{
    /// <summary>
    ///     CRUD library service
    /// </summary>
    public class BookService
    {
        /// <summary>
        ///     Book repository
        /// </summary>
        private readonly ILibrary repository;

        /// <summary>
        ///     Ctor book repository
        /// </summary>
        /// <param name="repository">book repository</param>
        public BookService(ILibrary repository)
        {
            if (repository != null) this.repository = repository;
            Books = repository?.GetBooks();
        }

        /// <summary>
        ///     All books from book repository
        /// </summary>
        public IEnumerable<Book> Books { get; }

        /// <summary>
        ///     Access to the book by ID, in case such ID is missing,
        ///     returns the last element in the list
        /// </summary>
        /// <param name="id">ID code</param>
        /// <returns>Book entity</returns>
        public Book Get(int id)
        {
            return repository?.Get(id) != null
                ? repository.Get(id)
                : repository?.GetLast();
        }

        /// <summary>
        ///     Getting ID of the last item in the list of books
        /// </summary>
        /// <returns>ID code</returns>
        public int GetLastId()
        {
            return repository.GetLast().Id;
        }

        /// <summary>
        ///     Adding new book;
        ///     ID is formed as the last created incremented by one.
        /// </summary>
        /// <param name="title">new title Book</param>
        public void AddBook(string title)
        {
            Console.WriteLine(repository.Add(new Book
            {
                Id = repository.GetLast().Id + 1, Title = title
            })
                ? $"Book \"{title}\" added successfully."
                : $"Attention!! book \"{title}\" not added.");
        }

        /// <summary>
        ///     Editing of the book entity
        ///     (essentially only the title of the book is being edited).
        /// </summary>
        /// <param name="id">ID code</param>
        public void EditBook(int id)
        {
            var book = repository.Get(id);
            Console.WriteLine(repository.Edit(id)
                                  ? $"Book \"{book.Title}\" updated successfully."
                                  : $"Attention!! book \"{book.Title}\" not updated.");
        }

        /// <summary>
        ///     Deleting book entity
        /// </summary>
        /// <param name="id">ID code</param>
        public void DeleteBook(int id)
        {
            var book = repository.Get(id);
            Console.WriteLine(repository.Delete(id)
                                  ? $"Book \"{book.Title}\" deleted successfully."
                                  : $"Attention!! book \"{book.Title}\" not deleted.");
        }
    }
}