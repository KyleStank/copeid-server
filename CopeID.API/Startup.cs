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

using CopeID.API.Configurations;
using CopeID.API.Services.AzureStorage;
using CopeID.API.Services.Contributors;
using CopeID.API.Services.Definitions;
using CopeID.API.Services.Files;
using CopeID.API.Services.Filters;
using CopeID.API.Services.Genuses;
using CopeID.API.Services.Photographs;
using CopeID.API.Services.References;
using CopeID.API.Services.Specimens;
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
            services.AddOptions()
                .Configure<DocumentStorageConfig>(Configuration.GetSection("DocumentStorage"));

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

            services.AddScoped<IAzureStorageService, AzureStorageService>();
            services.AddScoped<IContributorService, ContributorService>();
            services.AddScoped<IDefinitionService, DefinitionService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<IFilterModelService, FilterModelService>();
            services.AddScoped<IFilterModelPropertyService, FilterModelPropertyService>();
            services.AddScoped<IFilterSectionService, FilterSectionService>();
            services.AddScoped<IFilterSectionPartService, FilterSectionPartService>();
            services.AddScoped<IFilterSectionPartOptionService, FilterSectionPartOptionService>();
            services.AddScoped<IGenusService, GenusService>();
            services.AddScoped<IPhotographService, PhotographService>();
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<ISpecimenService, SpecimenService>();
            services.AddScoped<ISpecimenFilterService, SpecimenFilterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            CopeIdDbContext context,
            ILogger<Startup> logger,
            IAzureStorageService azureStorageService
        )
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

            // Initialize database.
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
                EventId dbInitEvent = new EventId(101, "Error while creating database");
                logger.LogCritical(dbInitEvent, exception, dbInitEvent.Name);
                throw new Exception(dbInitEvent.Name, exception);
            }

            // Initialize Azure file storage.
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
                azureStorageService.Initialize(connectionString);
            }
            catch (Exception exception)
            {
                EventId azureStorageEvent = new EventId(102, "Error while initializing Azure Storage");
                logger.LogCritical(azureStorageEvent, exception, azureStorageEvent.Name);
                throw new Exception(azureStorageEvent.Name, exception);
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
