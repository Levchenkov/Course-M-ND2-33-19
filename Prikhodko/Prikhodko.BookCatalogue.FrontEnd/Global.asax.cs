using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Prikhodko.BookCatalogue.FrontEnd.App_Start;

namespace Prikhodko.BookCatalogue.FrontEnd
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.ConfigureContainer();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
