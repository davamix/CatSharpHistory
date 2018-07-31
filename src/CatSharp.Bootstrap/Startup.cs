using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using CatSharp.Services;
using CatSharp.Data;


namespace CatSharp.Bootstrap
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true;
                options.RespectBrowserAcceptHeader = true;
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFormatterMappings()
                .AddJsonFormatters();

            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin());
            });

            // Configure connection string
            services.AddDbContext<CatSharpContext>(options=>
                options.UseSqlite(Configuration.GetConnectionString("CatSharpDatabase")));


            // Configure depency injection
            services.AddTransient<ICatService, CatService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}
