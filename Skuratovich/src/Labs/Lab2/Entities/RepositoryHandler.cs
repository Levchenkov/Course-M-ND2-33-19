using System;
using Lab2.Entities.Models;

namespace Lab2.Entities
{
    public class RepositoryHandler
    {
        public object MyProperty { get; set; }

        //private readonly IList<Book> data;

        //TODO: watch sample
        //public DbSet<Owner> Owners { get; set; }
        //public DbSet<Account> Accounts { get; set; }

        public JsonFileHandler<Book> Books { get; set; }
    }
}
