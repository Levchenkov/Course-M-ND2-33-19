using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using System.Web.Mvc;
using Htp.Library.Infrastructure;

namespace Htp.Library.Web.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.AddDataDependencies();
            builder.AddDomainDependencies();

            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //var csl = new AutofacServiceLocator(container);
            //ServiceLocator.SetLocatorProvider(() => csl);
        }
    }
}