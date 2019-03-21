using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryCRUD
{
    /// <inheritdoc />
    /// <summary>
    ///     Core business logic for implementing CRUD
    /// </summary>
    public class LibraryRepository : ILibrary
    {
        private readonly IList<Book> data;
        private readonly LibraryDBInitializator db;

        /// <summary>
        ///     Ctor for init <see cref="LibraryRepository" />
        /// </summary>
        public LibraryRepository()
        {
            db = new LibraryDBInitializator();
            data = db.Books;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Implementation of access by ID
        /// </summary>
        /// <param name="id">ID code</param>
        /// <returns>Book by ID</returns>
        public Book Get(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            return result ?? throw new Exception($"Element with id = {id} not found.");
        }

        /// <inheritdoc />
        /// <summary>
        ///     Accessing the last item in the book library
        /// </summary>
        /// <returns>Last book</returns>
        public Book GetLast()
        {
            return data.LastOrDefault();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creating and adding a new book to the list of library books
        /// </summary>
        /// <param name="book">New entity of the <see cref="LibraryContext" /></param>
        /// <returns>true if successful</returns>
        public void Add(Book book)
        {
            data.Add(book);
            db.SaveDbToJson();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Editing book entity from list of library books
        /// </summary>
        /// <param name="id">ID code</param>
        /// <returns>true if successful</returns>
        public Book Edit(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                EditForm(result);
                db.SaveDbToJson();
            }

            return result;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Deleting book entity from list of library books
        /// </summary>
        /// <param name="id">ID code</param>
        /// <returns>true if successful</returns>
        public void Delete(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                data.Remove(result);
                db.SaveDbToJson();
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///     Returns a list of all library books.
        /// </summary>
        /// <returns>IList data about all the books</returns>
        public IEnumerable<Book> GetBooks()
        {
            return data;
        }

        /// <summary>
        ///     Simple form for edit book entity
        /// </summary>
        /// <param name="book">Book entity</param>
        private void EditForm(Book book)
        {
            Console.WriteLine($"Book \"{book.Title}\" edit.\n");
            Console.Write("Enter new book title: ");
            book.Title = Console.ReadLine();
            Console.WriteLine("".PadRight(50, '\u2500'));
        }
    }
}