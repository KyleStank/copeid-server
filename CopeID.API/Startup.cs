using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.API.Services;
using CopeID.Context;
using CopeID.Seeding;

namespace CopeID.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CopeIdDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("CopeID.Context")
                )
            );

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CopeID.API", Version = "v1" });
            });

            services.AddScoped<IPhotographService, PhotographService>();
            services.AddScoped<IGenusService, GenusService>();
            services.AddScoped<ISpecimenService, SpecimenService>();
            services.AddScoped<IContributorService, ContributorService>();
            services.AddScoped<IDefinitionService, DefinitionService>();
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<IFilterService, FilterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CopeIdDbContext context, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CopeID.API v1"));

                app.UseCors(policy => policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                );
            }
            else
            {
                // TODO: Remove when application is actually ready for production.
                app.UseCors(policy => policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                );
            }

            try
            {
                context.Database.Migrate();

                Seeder seeder = new Seeder();
                List<Task> tasks = new List<Task>
                {
                    seeder.Seed(context, env.IsDevelopment() ? "../CopeID.Seeding/Data/" : null)
                };
                Task.WhenAll(tasks).Wait();
            }
            catch (Exception exception)
            {
                EventId initData = new EventId(101, "Error while creating database");
                logger.LogCritical(initData, exception, initData.Name);
                throw new Exception(initData.Name, exception);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
