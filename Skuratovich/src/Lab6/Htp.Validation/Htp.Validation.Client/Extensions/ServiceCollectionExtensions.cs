using AutoMapper;
using FluentValidation;
using Htp.Validation.Client.Comands;
using Htp.Validation.Client.Services;
using Htp.Validation.Client.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Htp.Validation.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddClientService(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PaymentMappingProfile());
            });

            services.AddTransient<IValidator<CreatePaymentRequest>, CreatePaymentRequestValidator>();

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
