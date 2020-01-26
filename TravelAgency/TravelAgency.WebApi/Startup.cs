using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Module;

namespace TravelAgency.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private const string AllowAnyOriginPolicyName = "AllowAnyOrigin";
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy(
                    AllowAnyOriginPolicyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowCredentials().AllowAnyHeader();
                    });
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(AllowAnyOriginPolicyName));
            });

            services.AddTravelAgency(configuration);
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseCors(AllowAnyOriginPolicyName);

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute("default", "/");
            });

            applicationBuilder.UseAuthentication();
        }
    }
}
