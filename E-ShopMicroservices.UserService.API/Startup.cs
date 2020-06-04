using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using E_ShopMicroservices.Infrastructure.IoC;
using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Services;
using E_ShopMicroservices.UserService.Application.Users.Commands;
using E_ShopMicroservices.UserService.Data.Context;
using E_ShopMicroservices.UserService.Domain.Entites;
using E_ShopMicroservices.UserService.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace E_ShopMicroservices.UserService.API
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
            RegisterService(services);
            services.AddIdentity<UserIdentity, Role>().AddEntityFrameworkStores<UserAppDbContext>()
                .AddDefaultTokenProviders();
            services.AddDbContext<UserAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "User Microservice", Version = "v1" });
            });
            services.AddControllers();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Salam necesen TokenJWT"));
            JwtInstaller(services, key);

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }




        private void JwtInstaller(IServiceCollection services,SymmetricSecurityKey key)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
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
        }
    }
}
