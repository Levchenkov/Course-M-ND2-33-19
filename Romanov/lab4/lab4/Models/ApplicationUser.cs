using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Book> Books { get; set; }
        public ApplicationUser()
        {

        }
    }
}