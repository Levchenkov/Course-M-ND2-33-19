using Microsoft.AspNet.Identity.EntityFramework;

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