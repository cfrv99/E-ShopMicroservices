using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_ShopMicroservice.Infrastructure.Bus.Buses;
using E_ShopMicroservice.Microservices.ProductService.Domain.EventHandlers;
using E_ShopMicroservice.Microservices.ProductService.Domain.Events;
using E_ShopMicroservices.Data.DAL.Context;
using E_ShopMicroservices.Domain.Core.Bus;
using E_ShopMicroservices.Infrastructure.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace E_ShopMicroservice.Microservices.ProductService.API
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
            //RegisterService(services);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));//,config=>config.MigrationsAssembly("E-ShopMicroservice.Microservices.ProductService.Infrastructure")));
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Product Microservice", Version = "v1" });
            });
            services.AddTransient<IEventBus, RabbitMqBus>();
        }


        private void RegisterService(IServiceCollection services)
        {
            DependencyContainer.RegisterService(services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Microservice V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<UserCreated, UserCreatedEventHandler>();
        }
    }
}
