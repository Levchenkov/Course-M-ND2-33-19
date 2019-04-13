using BookEditing.DAL.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;

namespace BookEditing.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }


        public BookContext() : base("BookContext") { }

    }
}