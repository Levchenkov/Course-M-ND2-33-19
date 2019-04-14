using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEditing.Models.Roles
{
    public class Role: IdentityRole
    {
        public Role()
        {

        }
        public string Description { get; set; }
    }
   
}