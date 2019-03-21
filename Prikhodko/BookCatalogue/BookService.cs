using System.Collections.Generic;

namespace BookCatalogue
{
    public class BookService
    {
        IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            if(book == null)
            {
                return;
            }
            else
            {
                bookRepository.Add(book);
            }
        }

        public Book GetBook(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            else
            {
                return bookRepository.GetBook(id);
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetBooks();
        }

        public void Remove(int id)
        {
            if (id <= 0)
            {
                return;
            }
            else
            {
                bookRepository.Remove(id);
            }
        }

        public void Update(Book book)
        {
            if (book == null)
            {
                return;
            }
            else
            {
                bookRepository.Update(book);
            }
        }
    }
}
