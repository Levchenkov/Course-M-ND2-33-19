using Lab2.Contracts;

namespace Lab2.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public JsonFileHandler _bookFileHandler;
        private IBookRepository _book;

        public RepositoryWrapper(JsonFileHandler bookFileHandler)
        {
            _bookFileHandler = bookFileHandler;
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_bookFileHandler);
                }

                return _book;
            }
        }
    }
}
