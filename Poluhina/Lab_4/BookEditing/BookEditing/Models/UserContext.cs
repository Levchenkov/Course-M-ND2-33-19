using BookEditing.Models.Roles;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookEditing.Models
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext() : base("UserDb") { }

        public static UserContext Create()
        {
            return new UserContext();
        }
    }
}