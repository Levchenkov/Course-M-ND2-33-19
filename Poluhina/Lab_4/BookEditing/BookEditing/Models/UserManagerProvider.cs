using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

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
            var db = context.Get<UserContext>();
            var manager = new UserManagerProvider(new UserStore<User>(db));
            return manager;
        }
    }
}
