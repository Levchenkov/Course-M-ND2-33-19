namespace BookLibraryCRUD.Source
{
    /// <summary>
    ///     BookService interface
    /// </summary>
    public interface IBookService
    {
        Book Get(int id);

        int GetLastId();

        void AddBook(string title);

        void EditBook(int id);

        void DeleteBook(int id);
    }
}