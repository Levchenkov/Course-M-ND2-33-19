using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.DAL
{
    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var books = new List<Book>
            {
                new Book{BookID = 0, Author = "Romanov",  Created = DateTime.Now, Description = "Test Entity Description 0", Genre = Genre.Fantastic, Title = "Entity test title 0", IsPaper = true, DeliveryRequired = false, Languages = new string[]{"English","Russian"}},
                new Book{BookID = 1, Author = "Stepanov",  Created = DateTime.Now, Description = "Test Entity Description 1", Genre = Genre.Fantastic, Title = "Entity test title 1", IsPaper = true, DeliveryRequired = false, Languages = new string[]{"English","Russian"}},
                new Book{BookID = 2, Author = "Ivanov",  Created = DateTime.Now, Description = "Test Entity Description 2", Genre = Genre.Fantastic, Title = "Entity test title 2", IsPaper = true, DeliveryRequired = false, Languages = new string[]{"English","Russian"}},
                new Book{BookID = 3, Author = "Pavlov",  Created = DateTime.Now, Description = "Test Entity Description 3", Genre = Genre.Fantastic, Title = "Entity test title 3", IsPaper = true, DeliveryRequired = false, Languages = new string[]{"English","Russian"}},
            };

            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();

        }
    }
}