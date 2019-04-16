using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Course.Client.Startup))]
namespace Course.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
