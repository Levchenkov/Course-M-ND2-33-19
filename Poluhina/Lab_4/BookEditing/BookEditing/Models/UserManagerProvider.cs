using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEditing.Models
{
    public class UserManagerProvider: UserManager<User>
    {
        public UserManagerProvider(IUserStore<User> store)
           : base(store)
        {
        }
        public static UserManagerProvider Create(IdentityFactoryOptions<UserManagerProvider> options,
                                           IOwinContext context)
        {
            UserContext db = context.Get<UserContext>();
            UserManagerProvider manager = new UserManagerProvider(new UserStore<User>(db));
            return manager;
        }
    }
}
