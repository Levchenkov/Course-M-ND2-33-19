using System;
using Lab2.Contracts;
using Lab2.Entities;
using Lab2.Entities.Models;
using Lab2.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Lab2.WEB.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureFileHandler(this IServiceCollection services)
        {
            services.AddScoped<JsonFileHandler>();
        }


        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
