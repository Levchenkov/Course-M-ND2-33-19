using System.Collections.Generic;

namespace BookCatalogue
{
    public class BookService : IService<Book>
    {
        IRepository<Book> bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Add(Book book)
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

        public Book Get(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            else
            {
                return bookRepository.Get(id);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return bookRepository.GetAll();
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
