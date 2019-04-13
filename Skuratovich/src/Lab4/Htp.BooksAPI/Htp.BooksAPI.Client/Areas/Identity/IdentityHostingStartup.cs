using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Htp.BooksAPI.Domain.Contracts.ViewModels;

[assembly: HostingStartup(typeof(Htp.BooksAPI.Client.Areas.Identity.IdentityHostingStartup))]
namespace Htp.BooksAPI.Client.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>();
            //});

            //builder.ConfigureServices((context, services) =>
            //{
            //    services.AddDefaultIdentity<UserViewModel>();

            //});
        }
    }
}