using System.IO;
using AutoMapper;
using FluentValidation;
using Htp.Validation.Data.Contracts;
using Htp.Validation.Data.EntityFramework;
using Htp.Validation.Domain.Contracts;
using Htp.Validation.Domain.Contracts.Comands;
using Htp.Validation.Domain.Contracts.Validators;
using Htp.Validation.Domain.Services;
using Htp.Validation.Infrastructure.MappingProfiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.Validation.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            string wanted_path = Path.GetDirectoryName(Directory.GetCurrentDirectory());

            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlite($"Filename={wanted_path}/{connectionString}"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PaymentMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AppDomainModule(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }

        public static void AddCustomFluentValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreatePaymentRequest>, CreatePaymentRequestValidator>();

            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonValidator>());
        }

        public static void AddUrlHelper(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = implementationFactory.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);

            });
        }
    }
}
