using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Examen.Config;
using Examen.Contexto;
using Examen.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Examen
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
            services.AddDbContext<ExamenContext>(o => { 
                o.UseSqlServer(Configuration.GetSection("ConnectionStrings")["BdSql"]); 
            });            

            services.InyectaDependencias();
            services.Configure<ConnectionStringsConfig>(Configuration.GetSection("ConnectionStrings"));

            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors(options =>
            {

                options.AddPolicy("PublicApi", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

                options.AddPolicy("Internas", b =>
                {
                    b.WithOrigins("http://localhost:4200").WithMethods(new string[] { "Get", "Post", "Put" }).AllowAnyHeader();
                });

            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.GestionExcepciones(logger);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("PublicApi");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
