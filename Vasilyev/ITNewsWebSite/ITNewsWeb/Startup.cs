using Microsoft.Owin;
using Owin;
using System.Threading;

[assembly: OwinStartupAttribute(typeof(ITNewsWeb.Startup))]
namespace ITNewsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            var nfInfo = new System.Globalization.CultureInfo("en-US", false)
            {
                NumberFormat =
                {
                    NumberDecimalSeparator = "."
                }
            };
            Thread.CurrentThread.CurrentCulture = nfInfo;
            Thread.CurrentThread.CurrentUICulture = nfInfo;
        }
    }
}
