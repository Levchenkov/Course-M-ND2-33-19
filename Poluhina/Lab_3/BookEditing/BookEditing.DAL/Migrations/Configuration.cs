namespace BookEditing.DAL.Migrations
{
    using BookEditing.DAL.EF;
    using BookEditing.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookEditing.DAL.EF.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookContext db)
        {
            base.Seed(db);
        }
    }
}
