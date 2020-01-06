using System;
using GUI_Eksamen_BiAvlereWeb.Data;
using GUI_Eksamen_BiAvlereWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GUI_Eksamen_BiAvlereWeb.Areas.Identity.IdentityHostingStartup))]
namespace GUI_Eksamen_BiAvlereWeb.Areas.Identity
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