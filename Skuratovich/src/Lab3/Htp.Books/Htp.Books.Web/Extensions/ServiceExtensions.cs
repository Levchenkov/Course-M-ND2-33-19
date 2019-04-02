using System;
using Autofac;
using Htp.Books.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.Books.Web.Extensions
{
    public static class ServiceExtensions
    {
        // TODO: How to get Configuration?
        //public static IServiceProvider ContainerBuilder(this IServiceCollection services)
        //{
        //    // https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html
        //    // Add Autofac
        //    var containerBuilder = new ContainerBuilder();

        //    //containerBuilder.RegisterModule<AppDataModule>();
        //    //containerBuilder.RegisterType<AppDataModule>().WithParameter("ConnectionString", Configuration.GetConnectionString("BookDatabase"));
        //    containerBuilder.RegisterModule(new AppDataModule() { ConnectionString = Configuration.GetConnectionString("BookDatabase") });
        //    containerBuilder.RegisterModule<AppDomainModule>();
        //    containerBuilder.RegisterModule<AutoMapperModule>();

        //    containerBuilder.Populate(services);
        //    var container = containerBuilder.Build();
        //    return new AutofacServiceProvider(container);
        //}
    }
}
