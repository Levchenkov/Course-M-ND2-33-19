using Autofac;
using Htp.News.Data.Contracts;
using Htp.News.Data.EntityFramework;
using Htp.News.Domain.Contracts;
using Htp.News.Domain.Services;

namespace Htp.News.Infrastructure
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            return builder;
        }

        public static ContainerBuilder AddDomainDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<PostService>().As<IPostService>();
            return builder;
        }
    }
}
