using Autofac;
using Lab4.BLL.Contract;
using Lab4.BLL.Services;
using Lab4.Lib;
using Lab4.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Infrastructure
{
    public static class ContainerBuilderExtansions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {
            
            builder.RegisterType<BookAppContext>().AsSelf().InstancePerLifetimeScope();
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
