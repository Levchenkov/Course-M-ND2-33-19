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
            var students = new List<Book>
            {
            new Book{
                BookID = 0,
                Author = "Romanov",
                Created = DateTime.Now,
                Description ="Test Entity Description",
                Genre =Genre.Fantastic,
                Title ="Entity test title",
                IsPaper = true,
                DeliveryRequired = false,
                Languages = new string[]{"English","Russian"}
            },
            };

            students.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
            
        }
    }
}