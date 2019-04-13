using System;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Htp.BooksAPI.Api.Extensions
{
    public static class BookCatalogSwaggerServiceCollectionExtensions
    {
        public static void AddBookCatalogSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Book Catalog API",
                    Description = "A simple Book Catalog ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Anton Skuratovich",
                        Email = string.Empty,
                        Url = string.Empty
                    },
                    License = new License
                    {
                        Name = "Apache 2.0",
                        Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                    }
                });
            });
        }
    }
}
