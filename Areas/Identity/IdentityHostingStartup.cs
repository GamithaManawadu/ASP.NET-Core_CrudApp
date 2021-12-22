using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTemp1.Areas.Identity.Data;
using TestTemp1.Data;

[assembly: HostingStartup(typeof(TestTemp1.Areas.Identity.IdentityHostingStartup))]
namespace TestTemp1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestTemp1Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<TestTemp1User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TestTemp1Context>();
            });
        }
    }
}