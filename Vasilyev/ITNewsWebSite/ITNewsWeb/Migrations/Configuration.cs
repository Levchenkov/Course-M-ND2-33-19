namespace ITNewsWeb.Migrations
{
    using ITNewsWeb.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ITNewsWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITNewsWeb.Models.ApplicationDbContext context)
        {
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем 3 роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "writer" };
            var role3 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);


            //// создаем пользователей
            //var admin = new ApplicationUser { Email = "admin@admin.com", UserName = "Admin" };
            //if (!userManager.Users.ToList().Contains(admin))
            //{
            //    string password = "!QAZ1qaz";
            //    var result = userManager.Create(admin, password);
            //    // если создание пользователя прошло успешно
            //    if (result.Succeeded)
            //    {
            //        // добавляем для пользователя роль
            //        userManager.AddToRole(admin.Id, role1.Name);
            //        userManager.AddToRole(admin.Id, role2.Name);
            //        userManager.AddToRole(admin.Id, role3.Name);
            //    }
            //}

            base.Seed(context);
        }
    }
}
