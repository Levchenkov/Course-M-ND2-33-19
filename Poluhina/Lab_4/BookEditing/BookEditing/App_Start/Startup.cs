﻿using BookEditing.Models;
using BookEditing.Models.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(BookEditing.App_Start.Startup))]

namespace BookEditing.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<UserContext>(UserContext.Create);
            app.CreatePerOwinContext<UserManagerProvider>(UserManagerProvider.Create);

            app.CreatePerOwinContext<RoleManagerProvider>(RoleManagerProvider.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}
