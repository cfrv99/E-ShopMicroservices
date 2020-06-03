using E_ShopMicroservice.Microservices.ProductService.Domain.Entities;
using E_ShopMicroservices.Commons.Common.Domains.Interfaces;
using E_ShopMicroservices.Data.DAL.Repository;
using E_ShopMicroservices.Infrastructure.IoC.EventBus.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.EventBusRegisterService();
            services.AddTransient(typeof(IRepository<Product, int>), typeof(EfRepository<Product, int>));

        }
    }
}
