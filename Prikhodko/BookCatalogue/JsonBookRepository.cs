using System.Collections.Generic;
using System.Linq;

namespace BookCatalogue
{
    public class JsonBookRepository : IRepository<Book>
    {
        private static readonly string cataloguePath = "books.json";
        private bool booksLoaded = false;
        private List<Book> books;
        public List<Book> Books
        {
            get
            {
                if (!booksLoaded)
                {
                    using (var context = new JsonDataContext<Book>(cataloguePath))
                    {
                        books = context.LoadData().ToList();
                    }
                    booksLoaded = true;
                }
                return books;
            }
        }

        public JsonBookRepository()
        {
            books = new List<Book>();
        }

        
        public void Add(Book book)
        {
            if (book == null)
            {
                return;
            }
            else
            {
                book.Id = GetId();
                using (var context = new JsonDataContext<Book>(cataloguePath))
                {
                    books.Add(book);
                    context.Save(books);
                }
            }
        }

        private int GetId()
        {
            return Books.Count + 1;
        }

        public Book Get(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            else
            {
                return books.FirstOrDefault(b => b.Id == id);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return Books;
        }

        public void Remove(int id)
        {
            if (id <= 0)
            {
                return;
            }
            else
            {
                using (var context = new JsonDataContext<Book>(cataloguePath))
                {
                    books.Remove(Books.FirstOrDefault(b => b.Id == id));
                    context.Save(books);
                }
            }
        }

        public void Update(Book book)
        {
            if(book == null || book.Id <= 0)
            {
                return;
            }
            else
            {
                using (var context = new JsonDataContext<Book>(cataloguePath))
                {
                    Book temp = books.FirstOrDefault(b => b.Id == book.Id);
                    temp.Author = book.Author;
                    temp.Title = book.Title;
                    temp.DateOfissue = book.DateOfissue;
                    context.Save(books);
                }
            }
        }
    }
}
