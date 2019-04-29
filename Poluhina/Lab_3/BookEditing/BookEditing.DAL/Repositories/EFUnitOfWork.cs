using BookEditing.DAL.EF;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using System;

namespace BookEditing.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BookContext db;
        private DataBookRepository bookRepository;

        public EFUnitOfWork()
        {
            db = new BookContext();
        }
        public IDataRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new DataBookRepository(db);
                return bookRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
