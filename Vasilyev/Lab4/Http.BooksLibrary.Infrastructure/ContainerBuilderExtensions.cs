using Autofac;
using Http.BooksLibrary.Data.Contracts;
using Http.BooksLibrary.Data.EntityFramework;
using Http.BooksLibrary.Domain.Contracts;
using Http.BooksLibrary.Domain.Services;

namespace Http.BooksLibrary.Infrastructure
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
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            return builder;
        }
    }
}