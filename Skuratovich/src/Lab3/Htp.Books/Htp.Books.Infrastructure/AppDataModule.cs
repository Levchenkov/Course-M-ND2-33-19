using Autofac;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Htp.Books.Infrastructure
{
    public class AppDataModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<ApplicationDbContext>()
            //.AsSelf()
            //.InstancePerLifetimeScope();

            // SQL
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(ConnectionString).Options;
            // Local
            //var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(ConnectionString).Options;

            builder.RegisterType<ApplicationDbContext>()
                .As<ApplicationDbContext>()
                .WithParameter("dbContextOptions", dbContextOptions)
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerLifetimeScope();

            //builder.RegisterType<BookRepository>()
                //.As<IBookRepository>()
                //.InstancePerLifetimeScope();
        }
    }
}

