using FoodDelivery.Data;
using FoodDelivery.Data.Repository;
using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Services;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace FoodDelivery
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
            services.AddDbContext<FoodDeliveryDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodDelivery", Version = "v1" });
            });

            services.AddScoped<IMenuItemCategoryRepository, MenuItemCategoryRepository>();
            services.AddScoped<IMenuItemCategoryService, MenuItemCategoryService>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IFoodOrderRepository, FoodOrderRepository>();
            services.AddScoped<IFoodOrderService, FoodOrderService>();
            services.AddScoped<IOrderMenuItemRepository, OrderMenuItemRepository>();
            services.AddScoped<IOrderMenuItemService, OrderMenuItemService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("./v1/swagger.json", "FoodDelivery v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<FoodDeliveryDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
