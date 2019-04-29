using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BookEditing.Models.Roles
{
    class RoleManagerProvider : RoleManager<Role>
    {
        public RoleManagerProvider(RoleStore<Role> store)
                    : base(store)
        { }
        public static RoleManagerProvider Create(IdentityFactoryOptions<RoleManagerProvider> options,
                                                IOwinContext context)
        {
            return new RoleManagerProvider(new
                    RoleStore<Role>(context.Get<UserContext>()));
        }
    }
}