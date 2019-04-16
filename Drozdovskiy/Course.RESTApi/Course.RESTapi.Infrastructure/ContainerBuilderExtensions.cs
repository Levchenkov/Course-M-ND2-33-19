using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Course.RESTapi.Data.Contracts;
using Course.RESTapi.Data.EntityFramework;
using Course.RESTapi.Domain.Contracts;
using Course.RESTapi.Domain.Services;

namespace Course.RESTapi.Infrastructure
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            return builder;
        }

        public static ContainerBuilder AddDomainDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
