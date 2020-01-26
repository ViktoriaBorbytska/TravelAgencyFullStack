using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.DatabaseAccess;
using TravelAgency.DatabaseAccess.Entities.Identity;
using TravelAgency.DatabaseAccess.Interfaces;

namespace TravelAgency.Module
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IConfiguration Configuration { get; }
        public static void AddTravelAgency(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IApplicationDBContext, ApplicationDBContext>();

            serviceCollection
                .AddIdentity<User, IdentityRole<int>>(options => { options.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<ApplicationDBContext>();

            serviceCollection.AddDbContext<ApplicationDBContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            });
        }
    }
   
}