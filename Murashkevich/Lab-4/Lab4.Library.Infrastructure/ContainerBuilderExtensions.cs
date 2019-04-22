using Autofac;
using Lab4.Library.Data.Contracts;
using Lab4.Library.Data.EntityFramework;
using Lab4.Library.Domain.Contracts;
using Lab4.Library.Domain.Services;

namespace Lab4.Library.Infrastructure
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
