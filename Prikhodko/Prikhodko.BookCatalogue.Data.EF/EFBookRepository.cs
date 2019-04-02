using System.Collections.Generic;
using System.Linq;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;

namespace Prikhodko.BookCatalogue.Data.EF
{
    public class EFBookRepository : IRepository<Book>
    {
        private readonly ApplicationDbContext dbContext;

        public EFBookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Book book)
        {
            if (book == null)
            {
                return;
            }
            else
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
        }

        public Book Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            else
            {
                var result = dbContext.Books.Find(id);
                return result;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            var dbSet = dbContext.Set<Book>();
            var result = dbSet.ToList();
            return result;
        }

        public void Remove(int id)
        {
            if (id <= 0)
            {
                return;
            }
            else
            {
                var dbSet = dbContext.Set<Book>();
                var result = dbSet.Find(id);
                dbSet.Remove(result);
            }
        }

        public void Update(Book item)
        {
            if (item == null || item.BookId <= 0)
            {
                return;
            }
            else
            {
                var book = Get(item.BookId);
                book.Title = item.Title;
                book.Description = item.Description;
                book.Author.FirstName = item.Author.FirstName;
                book.Author.LastName = item.Author.LastName;
                book.DateOfIssue = item.DateOfIssue;
                book.Genre = item.Genre;
                book.IsPaper = item.IsPaper;
                book.DeliveryOption = item.DeliveryOption;
                foreach (Language language in item.AvailableLanguages)
                {
                    if (!book.AvailableLanguages.Contains(language))
                    {
                        book.AvailableLanguages.Add(language);
                    }
                }
                var a = dbContext.Entry(book).State;
            }
        }
    }
}
