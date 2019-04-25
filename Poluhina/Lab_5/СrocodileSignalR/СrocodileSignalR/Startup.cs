using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(СrocodileSignalR.Startup))]

namespace СrocodileSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
