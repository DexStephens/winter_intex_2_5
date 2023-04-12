using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
<<<<<<< HEAD
using winter_intex_2_5.Data;
=======
using winter_intex_2_5.Models;
>>>>>>> c2bf18ce757bc07045bf2c8f79c013a294111189

[assembly: HostingStartup(typeof(winter_intex_2_5.Areas.Identity.IdentityHostingStartup))]
namespace winter_intex_2_5.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}