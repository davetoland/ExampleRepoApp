using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ExampleRepoApp.Api.Middleware;
using ExampleRepoApp.BusinessLogic.Interfaces;
using ExampleRepoApp.BusinessLogic.Services;
using ExampleRepoApp.DataLayer;
using ExampleRepoApp.DataLayer.Interfaces;
using ExampleRepoApp.DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ExampleRepoApp.Api
{
    [SuppressMessage("ReSharper", "CA1822")]
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<Startup>>());
            services.AddLogging();
            
            services.AddDbContext<ExampleRepoDbContext>(options => options
                //.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("Default"), x =>
                    x.MigrationsAssembly("ExampleRepoApp.DataLayer"))
                    #if DEBUG
                    .LogTo(x => Debug.WriteLine(x))
                    #endif
                );
            
            services.AddAutoMapper(config =>
                config.AddMaps(typeof(BusinessLogic.AutoMapperProfile)));

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerAddressRepository, OwnerAddressRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IVehicleService, VehicleService>();
            
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExampleRepoApp.Api", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleRepoApp.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseUnhandledExceptionHandler();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}