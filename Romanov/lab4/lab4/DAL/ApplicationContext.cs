using lab4.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab4.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public ApplicationContext() : base ("ApplicationConnection")
        {

        }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}