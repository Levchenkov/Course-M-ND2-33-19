using Autofac;
using Htp.Books.Domain.Contracts;
using Htp.Books.Domain.Services;

namespace Htp.Books.Infrastructure
{
    public class AppDomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();
        }
    }
}
