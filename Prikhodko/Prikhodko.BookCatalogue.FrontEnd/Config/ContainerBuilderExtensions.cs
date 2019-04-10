using Autofac;
using Prikhodko.BookCatalogue.FrontEnd.Services.Contracts;
using Prikhodko.BookCatalogue.FrontEnd.Services;

namespace Prikhodko.BookCatalogue.FrontEnd.Config
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddServiceDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<FrontEndBookService>().As<IFrontEndBookService>();
            builder.RegisterType<FrontEndLanguageService>().As<IFrontEndLanguageService>();
            return builder;
        }
    }
}
