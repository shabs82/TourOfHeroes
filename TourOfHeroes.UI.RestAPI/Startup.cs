using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TourOfHeroes.Core.ApplicationServices;
using TourOfHeroes.Core.ApplicationServices.Services;
using TourOfHeroes.Core.DomainServices;
using TourOfHeroes.Infrastructure.SQL.Data.Database;
using TourOfHeroes.Infrastructure.SQL.Data;
using TourOfHeroes.Infrastructure.SQL.Data.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TourOfHeroes.UI.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration , IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            if (Environment.IsDevelopment())
            {

                services.AddDbContext<PhotoDBContext>(opt =>
                {
                    opt.UseLoggerFactory(loggerFactory); //logs all sql queries.

                    opt.UseSqlite("Data Source=TourOfHeroes.db");
                });
            }

            if(Environment.IsProduction())
            {
                services.AddDbContext<PhotoDBContext>(opt =>
                {
                    opt.UseLoggerFactory(loggerFactory);
                    opt.UseSqlServer(
                        Configuration.GetConnectionString("defaultConnection")); 
                });

            }

            services.AddCors(options =>
                options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IPhotoService, PhotoService>();

            services.AddTransient<IDBInitialiser, DBInitialiser>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "TourOfHeroes ",
                        Description = "TourOfHeroesAPI",
                        Version = "v1"

                    });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.XMl";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });
            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                option.SerializerSettings.MaxDepth = 5;
            });
        }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    PhotoDBContext context = scope.ServiceProvider.GetService<PhotoDBContext>();
                    context.Database.EnsureDeleted(); // only in dev mode. never in prod mode or the whole database will be lost.
                    context.Database.EnsureCreated();
                    IDBInitialiser DbInit = scope.ServiceProvider.GetService<IDBInitialiser>();
                    DbInit.Seed(context);
                }

                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    PhotoDBContext context = scope.ServiceProvider.GetService<PhotoDBContext>();
                    context.Database.EnsureCreated();
                    IDBInitialiser dbInitializer = scope.ServiceProvider.GetService<IDBInitialiser>();
                    dbInitializer.Seed(context);
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Photo API");
                options.RoutePrefix = "";

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
        

        

