using BookEditing.DAL.Entities;
using System.Data.Entity;

namespace BookEditing.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookContext() : base("BookContext") { }
    }
}