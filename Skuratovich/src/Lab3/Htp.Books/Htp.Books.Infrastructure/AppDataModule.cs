using Autofac;
using AutoMapper.Configuration;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.EntityFramework;
using Htp.Books.Common.Contracts;
using Htp.Books.Common.Implementation;
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

            //var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(ConnectionString);

            //var dbContextOptions = new DbContextOptions<ApplicationDbContext>();

            //var dbContextOptions = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;

            //builder.RegisterType<ApplicationDbContext>()

            ////.AsSelf()
            //.As<ApplicationDbContext>()
            //.WithParameter("options", dbContextOptionsBuilder.Options)
            //.InstancePerLifetimeScope();

            //builder.RegisterType<DbContextOptionsBuilder<ApplicationDbContext>>()
                //.AsSelf()
                //.InstancePerLifetimeScope();


            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            //// Register Entity Framework
            //var dbContextOptionsBuilder = new DbContextOptionsBuilder<SalesDbContext>().UseSqlServer("MyConnectionString");

            //builder.RegisterType<SalesDbContext>()
            //.WithParameter("options", dbContextOptionsBuilder.Options)
            //.InstancePerLifetimeScope();


            //builder.Register<ApplicationDbContext>(c =>
            //{
            //    var config = c.Resolve<IConfiguration>();
            //    var opt = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    opt.UseSqlServer(config.GetSection("ConnectionStrings:MyConnection:ConnectionString").Value);

            //    //return new MyContext(opt.Options);
            //});

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(JsonHistoryLogHandler<>))
                .As(typeof(IHistoryLogHandler<>))
                .InstancePerLifetimeScope();
        }
    }
}
