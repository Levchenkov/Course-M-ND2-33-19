using Autofac;
using Http.News.Data.Contracts;
using Http.News.Data.EntityFramework;
using Http.News.Domain.Services;

namespace Http.News.Infrastructure
{
    public static class ContainerBuilderExtantions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //builder.RegisterType<NewsDbContext>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(NewsRepository)).As(typeof(INewsRepository)).InstancePerLifetimeScope();

            // registering all things needed for building data context
            builder.RegisterInstance(new NewsDbContext()).AsSelf().SingleInstance();
            // Register the repository
            builder.RegisterType<NewsRepository>()
                .AsImplementedInterfaces()
                .WithParameter((pi, c) => pi.ParameterType == typeof(NewsDbContext),
                    (pi, c) => c.Resolve<NewsDbContext>())
                .SingleInstance();
            return builder;
        }

        public static ContainerBuilder AddDomainDependencies(this ContainerBuilder builder)
        {
            // registering all application instances
            builder.RegisterType<NewsService>()
                .AsImplementedInterfaces();
            // registering all services
            //builder.RegisterType<ItemService>().As<IItemService>().InstancePerLifetimeScope();
            //builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            return builder;
        }
    }
}