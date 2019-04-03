using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Htp.Books.Data.EntityFramework
{
    public class BookRepository : Repository<int, Book>, IBookRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            var book = dbContext.Books.Find(id);

            dbContext.Entry(book)
                .Collection(b => b.BookLanguages)
                .Load();



            //var book1 = dbContext.Books.SingleAsync(b => b.Id == id).I
            //Include(x => x.Genre);

            throw new NotImplementedException();


        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Test(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
