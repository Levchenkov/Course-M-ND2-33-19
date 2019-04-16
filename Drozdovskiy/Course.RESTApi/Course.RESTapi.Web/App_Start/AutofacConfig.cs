using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Course.RESTapi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
namespace Course.RESTapi.Web.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.AddDataDependencies();
            builder.AddDomainDependencies();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}