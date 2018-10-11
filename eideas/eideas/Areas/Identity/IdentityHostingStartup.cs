using System;
using eideas.Areas.Identity.Data;
using eideas.Data;
using eideas.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(eideas.Areas.Identity.IdentityHostingStartup))]
namespace eideas.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

                services.AddDefaultIdentity<EIdeasUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

                services.AddScoped<SignInManager<EIdeasUser>, SignInManager<EIdeasUser>>();
            });
        }
    }
}