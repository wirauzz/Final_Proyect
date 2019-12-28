using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurante_Proyecto.Data;
using Restaurante_Proyecto.Data.Repository;
using Restaurante_Proyecto.Services;

namespace Restaurante_Proyecto
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => {
                    options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader();
                });
            });

            //Add EntityFramework support for SqlServer
            services.AddEntityFrameworkSqlServer();
            services.AddAutoMapper(typeof(Startup));


            //Add Application DbContext
            services.AddDbContext<Restaurante_ProyectoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RestaurantsApiDatabase")));
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IFoodMapRepository, FoodMapRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCors(options =>
            {
                options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
