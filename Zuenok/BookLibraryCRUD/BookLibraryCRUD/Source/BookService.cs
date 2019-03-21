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
            var book = repository.Get(id);
            return book ?? repository.GetLast();
        }

        /// <summary>
        ///     Getting ID of the last item in the list of books
        /// </summary>
        /// <returns>ID code</returns>
        public int GetLastId()
        {
            var res = repository.GetLast()?.Id;
            if (res != null) return (int) res;
            throw new Exception($"Element with id = {(int?) null} not found.");
        }

        /// <summary>
        ///     Adding new book;
        ///     ID is formed as the last created incremented by one.
        /// </summary>
        /// <param name="title">new title Book</param>
        public void AddBook(string title)
        {
            var newId = repository.GetLast() == null ? 1 : repository.GetLast().Id + 1;
            var newBook = new Book {Id = newId, Title = title};
            repository.Add(newBook);
        }


        /// <summary>
        ///     Editing of the book entity
        ///     (essentially only the title of the book is being edited).
        /// </summary>
        /// <param name="id">ID code</param>
        public void EditBook(int id)
        {
            repository.Edit(id);
        }

        /// <summary>
        ///     Deleting book entity
        /// </summary>
        /// <param name="id">ID code</param>
        public void DeleteBook(int id)
        {
            repository.Delete(id);
        }
    }
}