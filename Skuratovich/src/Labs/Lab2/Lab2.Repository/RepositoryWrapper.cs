using Lab2.Contracts;

namespace Lab2.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public JsonFileHandler bookFileHandler;
        private IBookRepository book;

        public RepositoryWrapper(JsonFileHandler bookFileHandler)
        {
            this.bookFileHandler = bookFileHandler;
        }

        public IBookRepository Book
        {
            get
            {
                if (book == null)
                {
                    book = new BookRepository(bookFileHandler);
                }

                return book;
            }
        }
    }
}
