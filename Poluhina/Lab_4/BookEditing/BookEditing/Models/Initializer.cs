using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookEditing.Models.Roles;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace BookEditing.Models
{
    public class Initializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var userManager = new UserManagerProvider(new UserStore<User>(context));

            var roleManager = new RoleManagerProvider(new RoleStore<Role>(context));

         
            // создаем две роли
            var role1 = new Role { Name = "admin"};
            var role2 = new Role { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new User { Email = "poluhina@gmail.com", UserName = "Poluhina"};
            string password = "2502666z";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}