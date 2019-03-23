using System;
using Lab2.Contracts;
using Lab2.Entities;

namespace Lab2.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IBookFileHandler _bookFileHendler;
        private IBookRepository _book;

        public RepositoryWrapper(IBookFileHandler bookFileHendler)
        {
            _bookFileHendler = bookFileHendler;
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_bookFileHendler);
                }

                return _book;
            }
        }
    }
}
