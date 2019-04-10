using System;
using Htp.BooksAPI.Data.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.BooksAPI.Data.EntityFramework
{
    /// <summary>
    /// Extension methods for setting up unit of work related services in an <see cref="IServiceCollection"/>.
    /// </summary>
    //public static class UnitOfWorkServiceCollectionExtensions
    //{
    //    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    //    { 
    //        //services.AddScoped<IRepositoryFactory, UnitOfWork>();
    //        services.AddScoped<IUnitOfWork, UnitOfWork>();

    //        return services;
    //    }

    //    public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
    //        where TEntity : class
    //        where TRepository : class, IRepository<TEntity>
    //    {
    //        services.AddScoped<IRepository<TEntity>, TRepository>();

    //        return services;
    //    }
    //}
}
