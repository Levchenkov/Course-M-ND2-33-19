using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Htp.BooksAPI.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.BooksAPI.Infrastructure
{
    public static class ApiCollectionExtensions
    {
        public static void AppApiServicies(this IServiceCollection services)
        {
            //services.AddScoped<IToken, JwtToken>();

            services.AddSingleton<IToken, JwtToken>();

            //AddScoped<IToken, JwtToken>();
            services.AddScoped<IBookService, ApiBookService>();
        }

        public static void AddCustomProvider(this IServiceCollection services)
        {
            services.AddDefaultIdentity<UserViewModel>()
                .AddDefaultUI(UIFramework.Bootstrap4);

            // Add identity types
            services.AddIdentityCore<UserViewModel>()
                .AddDefaultTokenProviders();

            // Identity Services
            services.AddTransient<IUserStore<UserViewModel>, CustomUserStore>();
        }
    }
}
