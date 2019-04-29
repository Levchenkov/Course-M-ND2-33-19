using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prikhodko.BookCatalogue.PL.App_Start.Startup))]
namespace Prikhodko.BookCatalogue.PL.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
