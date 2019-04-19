using Microsoft.AspNet.Identity.EntityFramework;

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