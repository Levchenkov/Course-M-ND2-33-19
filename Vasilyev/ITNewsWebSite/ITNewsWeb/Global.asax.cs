using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ITNewsWeb.App_Start;
using ITNewsWeb.Migrations;
using ITNewsWeb.Models;

namespace ITNewsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Инициализация БД для создания ролей
            //Database.SetInitializer<ApplicationDbContext>(new Configuration());

            ModelBinders.Binders.Add(typeof(double), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new DecimalModelBinder());

            AreaRegistration.RegisterAllAreas();

            AutofacConfig.ConfigureContainer();
            AutomapConfig.Configure();

            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            return valueProviderResult == null ? base.BindModel(controllerContext, bindingContext) : double.Parse(valueProviderResult.AttemptedValue, CultureInfo.InvariantCulture);
        }
    }
}
