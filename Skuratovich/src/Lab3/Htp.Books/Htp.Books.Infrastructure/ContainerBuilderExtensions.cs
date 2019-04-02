using Autofac;
using Htp.Books.Data.EntityFramework;
using Htp.Books.Domain.Contracts;
using Htp.Books.Domain.Services;

namespace Htp.Books.Infrastructure
{
    //TODO: delete class later

    //public static class ContainerBuilderExtensions
    //{


    //    public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
    //    {
    //    //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
    //        builder.RegisterType<ApplicationDbContext>().AsSelf();
    //    //    builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
    //        return builder;
    //    }

    //    public static ContainerBuilder AddDomainDependencies(this ContainerBuilder builder)
    //    {
    //        builder.RegisterType<BookService>().As<IBookService>();
    //        return builder;
    //    }
    //}
}
