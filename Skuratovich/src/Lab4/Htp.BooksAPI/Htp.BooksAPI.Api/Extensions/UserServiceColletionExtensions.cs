using System;
using System.Text;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Htp.BooksAPI.Api.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Htp.BooksAPI.Api.Services;

namespace Htp.BooksAPI.Api.Extensions
{
    public static class UserServiceColletionExtensions
    {
        public static void AddUserService(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            // configure strongly typed settings objects

            services.Configure<AppSettings>(configurationSection);

            // configure jwt authentication
            var appSettings = configurationSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

        }
    }
}
