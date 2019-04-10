using System;
using Htp.BooksAPI.Data.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.BooksAPI.Infrastructure
{
    /// <summary>
    /// Extension methods for setting up unit of work related services in an <see cref="IServiceCollection"/>.
    /// </summary>
    //public static class UnitOfWorkServiceCollectionExtensions
    //{
    //    public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
    //        //services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
    //        //// Following has a issue: IUnitOfWork cannot support multiple dbcontext/database, 
    //        //// that means cannot call AddUnitOfWork<TContext> multiple times.
    //        //// Solution: check IUnitOfWork whether or null
    //        //services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
    //        //services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();

    //        return services;
    //    }
    //}
}
