using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts;
using Htp.BooksAPI.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Htp.BooksAPI.Data.EntityFramework
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        //private readonly ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //this.dbContext = dbContext;
        }

        public new IEnumerable<Book> GetAll()
        {
            var result = DbContext.Books
                .AsNoTracking()
                .Include(x => x.CreatedBy)
                .Include(x => x.UpdatedBy);
            return result;

            //DbContext.Set<Book>().ToList();
            //return DbContext.Set<Book>().ToList();
        }

        public async Task<Book> GetAsync(int id)
        {
            var book = await DbContext.Books.SingleAsync(x => x.Id == id);

            await DbContext.Entry(book)
                .Reference(b => b.CreatedBy)
                .LoadAsync();

            await DbContext.Entry(book)
                .Reference(b => b.UpdatedBy)
                .LoadAsync();

            return book;
        }
    }
}
