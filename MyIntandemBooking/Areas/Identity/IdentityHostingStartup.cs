using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Models;

[assembly: HostingStartup(typeof(MyIntandemBooking.Areas.Identity.IdentityHostingStartup))]
namespace MyIntandemBooking.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
                //services.AddDbContext<MyInTandemBookingContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("MyIntandemBookingContextConnection")));

                //services.AddDefaultIdentity<MyInTandemBookingUser>()
                //    .AddEntityFrameworkStores<MyInTandemBookingContext>();
            //});
        }
    }
}