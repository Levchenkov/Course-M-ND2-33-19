using BookEditing.DAL.EF;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookEditing.DAL.Repositories
{
    public class DataBookRepository : IDataRepository<Book>
    {
        private BookContext db;
        public DataBookRepository(BookContext db)
        {
            this.db = db;
        }
        public IEnumerable<Book> GetList()
        {
            var books = db.Books.ToList();

            return books;
        }
        public void Add(Book book)
        {
            db.Books.Add(book);
            db.Entry(book).State = EntityState.Added;
        }
        public void Change(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
        public void Remove(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
        public Book Get(int id)
        {
            var book = db.Books.Where(x => x.Id == id).FirstOrDefault();
            return book;
        }
    }
}