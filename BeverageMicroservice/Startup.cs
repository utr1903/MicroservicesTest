using System.IO;
using BeverageMicroservice.Data;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA;
using BeverageMicroservice.Services.PrimitiveService.BeverageServiceP;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;

namespace BeverageMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ReadConnectionString();
            
            services.AddDbContext<BeveragesContext>(options => options.UseNpgsql(Constants.ConnectionString));
            services.AddScoped<DbContext, BeveragesContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Beverage
            services.AddScoped<ITrackableRepository<Beverage>, TrackableRepository<Beverage>>();

            // Beverage
            services.AddScoped<IBeverageServiceP, BeverageServiceP>();

            // Beverage
            services.AddScoped<IBeverageServiceA, BeverageServiceA>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ReadConnectionString()
        {
            var dir = Directory.GetCurrentDirectory();
            using var sr = new StreamReader(dir + Path.DirectorySeparatorChar + "connectionstring.txt");
            Constants.ConnectionString = sr.ReadLine();
        }
    }
}
