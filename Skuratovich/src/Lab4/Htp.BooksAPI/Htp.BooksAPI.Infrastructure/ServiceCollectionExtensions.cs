using System.IO;
using AutoMapper;
using Htp.BooksAPI.Data.Contracts;
using Htp.BooksAPI.Data.Contracts.Entities;
using Htp.BooksAPI.Data.EntityFramework;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Services;
using Htp.BooksAPI.Infrastructure.MappingProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.BooksAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(connectionString));

            string wanted_path = Path.GetDirectoryName(Directory.GetCurrentDirectory());

            services.AddDbContext<ApplicationDbContext>(options => options
                //.UseLazyLoadingProxies()
                .UseSqlite($"Filename={wanted_path}/{connectionString}"))
                .AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            //services.AddDefaultIdentity<AppUser>()
                ////.AddDefaultUI(UIFramework.Bootstrap4)
                //.AddDefaultUI()
                //.AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AppDomainModule(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }
    }
}