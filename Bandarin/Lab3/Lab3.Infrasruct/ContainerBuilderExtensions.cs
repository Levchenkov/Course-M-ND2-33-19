using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Lab3.DAL.Contracts;
using Lab3.DAL.EntityFrame;
using Lab3.BLL.Contracts;
using Lab3.BLL.Services;
using Lab3.DAL.Contracts.Entities;

namespace Lab3.Infrasruct
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDataDependencies(this ContainerBuilder builder)
        {

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<BookContext>().AsSelf().InstancePerLifetimeScope();
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
