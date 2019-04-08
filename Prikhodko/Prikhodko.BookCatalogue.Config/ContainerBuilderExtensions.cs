using Autofac;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
using Prikhodko.BookCatalogue.Service;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using Prikhodko.BookCatalogue.Data.EF;

namespace Prikhodko.BookCatalogue.Config
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EFBookRepository>().As<IRepository<Book>>();
            builder.RegisterType<EFLanguageRepository>().As<IRepository<Language>>();
            
            //DependencyResolver.SetResolver(new UnityDependencyResolver(builder));
            return builder;
        }

        public static ContainerBuilder AddServiceDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<LanguageService>().As<ILanguageService>();
            return builder;
        }
    }
}
