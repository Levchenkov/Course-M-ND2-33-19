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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookContext db)
        {
            var book1 = new Book
            {
                Title = "The Master and Margarita",
                Description = "No description",
                Author = "Michael Bulgakov",
                Created = new DateTime(1992, 2, 24),
                Genre = "novel",
                IsPaper = true,
                DeliveryRequred = true,
            };
            var book2 = new Book
            {
                Title = "Asya",
                Description = "No description",
                Author = "Ivan Turgenev",
                Created = new DateTime(1966, 5, 27),
                Genre = "novel",
                IsPaper = true,
                DeliveryRequred = true,
            };
            db.SaveChanges();
            Language language1 = new Language { Name = "Russian" };
            Language language2 = new Language { Name = "Deutsch" };
            Language language3 = new Language { Name = "English" };
            Language language4 = new Language { Name = "Spanish" };

            db.Languages.AddRange(new List<Language> { language1, language2, language3, language4 });


            db.SaveChanges();

            book1.Languages.Add(language1);
            book1.Languages.Add(language2);
            book2.Languages.Add(language3);
            book2.Languages.Add(language4);
            db.Books.AddRange(new List<Book> { book1, book2 });
            db.SaveChanges();

            base.Seed(db);
        }
    }
}
