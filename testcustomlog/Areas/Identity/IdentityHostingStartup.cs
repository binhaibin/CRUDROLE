using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testcustomlog.Areas.Identity.Data;
using testcustomlog.Models;

[assembly: HostingStartup(typeof(testcustomlog.Areas.Identity.IdentityHostingStartup))]
namespace testcustomlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<testcustomlogContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("testcustomlogContextConnection")));

                services.AddIdentity<WebApp1User, IdentityRole>()
                    .AddEntityFrameworkStores<testcustomlogContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
            });
        }
    }
}