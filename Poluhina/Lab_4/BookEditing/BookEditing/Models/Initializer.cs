using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using BookEditing.Models.Roles;
using Microsoft.AspNet.Identity;

namespace BookEditing.Models
{
    public class Initializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var userManager = new UserManagerProvider(new UserStore<User>(context));

            var roleManager = new RoleManagerProvider(new RoleStore<Role>(context));

            var role1 = new Role { Name = "admin"};
            var role2 = new Role { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new User { Email = "poluhina@gmail.com", UserName = "Poluhina"};
            string password = "2502666z";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}