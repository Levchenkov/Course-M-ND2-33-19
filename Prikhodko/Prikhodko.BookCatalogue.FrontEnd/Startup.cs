using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prikhodko.BookCatalogue.FrontEnd.Startup))]
namespace Prikhodko.BookCatalogue.FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
