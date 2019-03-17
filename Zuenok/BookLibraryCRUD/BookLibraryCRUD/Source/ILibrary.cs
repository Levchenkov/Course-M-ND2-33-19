using System.Collections.Generic;

namespace BookLibraryCRUD
{
    /// <inheritdoc />
    /// <summary>
    /// interface for using CRUD methods
    /// </summary>
    public interface ILibrary : IGet<Book>
    {
        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">entity from <see cref="LibraryContext"></param>
        /// <returns>true if successful</returns>
        bool Add(Book book);

        /// <summary>
        /// Edit entity book
        /// </summary>
        /// <param name="id">ID book</param>
        /// <returns>true if successful</returns>
        bool Edit(int id);


        /// <summary>
        /// Delete entity book
        /// </summary>
        /// <param name="id">ID book</param>
        /// <returns>true if successful</returns>
        bool Delete(int id);


        /// <summary>
        /// Returns a list of all library books.
        /// </summary>
        /// <returns>IList data about all the books</returns>
        IEnumerable<Book> GetBooks();
    }
}