using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Python.Runtime;

using Serilog;

using wasp.WebApi.Data;
using wasp.WebApi.Exceptions;
using wasp.WebApi.Services.Configuration;
using wasp.WebApi.Services.DatabaseAccess;
using wasp.WebApi.Services.DataDefinition;
using wasp.WebApi.Services.Environment;
using wasp.WebApi.Services.PrimaryKey;
using wasp.WebApi.Services.PythonEngine;
using wasp.WebApi.Services.StaticServiceProvider;

namespace wasp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        private IntPtr threadState;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMemoryCache();
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder => builder
                        .WithOrigins(
                            "http://localhost:4200",
                            "http://127.0.0.1:4200")
                        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("WaspSqlServerConnectionString")));
            
            services.Configure<PythonSettings>(_configuration.GetSection("PythonSettings"));

            threadState = services.AddPython(_configuration, new EnvironmentDiscovery());
            
            services.AddControllers();

            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IDataDefinitionService, SqlServerDataDefinitionService>();
            services.AddTransient<IPrimaryKeyService, PrimaryKeyService>();
            services.AddTransient<IEnvironmentDiscovery, EnvironmentDiscovery>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IServiceProviderProxy, HttpContextServiceProviderProxy>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IHostApplicationLifetime applicationLifetime, IServiceProvider sp)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            loggerFactory.AddSerilog();
            
            app.UseRouting();
            app.UseCors("cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            IServiceProviderProxy? serviceProviderProxy = sp.GetService<IServiceProviderProxy>();
            if (serviceProviderProxy is null)
                throw new ServiceNotFoundException<IServiceProviderProxy>();
            
            ServiceLocator.Initialize(serviceProviderProxy);

            applicationLifetime.ApplicationStopping.Register(OnShutdown);
        }

        public void OnShutdown()
        {
            PythonEngine.EndAllowThreads(threadState);
            PythonEngine.Shutdown();
        }
    }
}
