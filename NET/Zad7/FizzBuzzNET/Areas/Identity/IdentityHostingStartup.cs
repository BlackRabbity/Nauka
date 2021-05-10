using System;
using FizzBuzzNET.Areas.Identity.Data;
using FizzBuzzNET.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FizzBuzzNET.Areas.Identity.IdentityHostingStartup))]
namespace FizzBuzzNET.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FizzBuzzDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FizzBuzzDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FizzBuzzDbContext>();
            });
        }
    }
}