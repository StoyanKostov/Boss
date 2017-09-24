using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.Services;
using Microsoft.Extensions.Configuration;
using WebApplication.Models;
using AutoMapper;
using WebApplication.ViewModels;

namespace WebApplication
{
    public class Startup
    {
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddScoped<IAppRepository, AppRepository>();
            services.AddTransient<AppSeed>();
            services.AddScoped<IMailService, DebugMailService>();
            services.AddDbContext<ApplicationContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AppSeed seeder)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                seeder.SeedData().Wait();
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }

            Mapper.Initialize(config =>
            {
                config.CreateMap<UserViewModel, User>().ReverseMap();
            });

            app.UseStaticFiles();
            app.UseMvc(configureRoutes =>
            {
                configureRoutes.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "index" }
                );
            });
        }
    }
}
