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
            if(id <= 0)
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

        public void Update(Book book)
        {
            if(book == null || book.Id <= 0)
            {
                return;
            }
            else
            {
                Remove(book.Id);
                Add(book);
            }
        }
    }
}
