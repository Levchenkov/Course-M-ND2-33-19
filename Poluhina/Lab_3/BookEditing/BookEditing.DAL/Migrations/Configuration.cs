using BookEditing.DAL.EF;
using BookEditing.DAL.Entities;
using System.Data.Entity.Migrations;

namespace BookEditing.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookEditing.DAL.EF.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookContext db)
        {
            var lang1 = new Language { Name = "Russian" };
            var lang2 = new Language { Name = "Deutsch" };
            var lang3 = new Language { Name = "English" };
            var lang4 = new Language { Name = "Spanish" };

            db.Languages.Add(lang1);
            db.Languages.Add(lang2);
            db.Languages.Add(lang3);
            db.Languages.Add(lang4);
            base.Seed(db);
        }
    }
}
