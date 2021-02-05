using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppMVC.Areas.Identity.Data;
using WebAppMVC.Data;

[assembly: HostingStartup(typeof(WebAppMVC.Areas.Identity.IdentityHostingStartup))]
namespace WebAppMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("SqlLiteAuthDbConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;

                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireNonAlphanumeric = false;

                        options.User.RequireUniqueEmail = true;
                    })
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}