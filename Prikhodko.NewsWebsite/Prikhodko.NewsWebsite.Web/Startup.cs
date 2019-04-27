using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prikhodko.NewsWebsite.Web.Startup))]
namespace Prikhodko.NewsWebsite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
