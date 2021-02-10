using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.Areas.Identity.Data;
using WebMVC.Data;

[assembly: HostingStartup(typeof(WebMVC.Areas.Identity.IdentityHostingStartup))]
namespace WebMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<A247AuthContext>(options =>
                    options.UseSqlite(DAL.ConnectionStrings.DB_CONN_STRING));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;

                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireNonAlphanumeric = false;

                        options.User.RequireUniqueEmail = true;
                    })
                    .AddEntityFrameworkStores<A247AuthContext>();
            });
        }
    }
}