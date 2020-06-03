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
        }
    }
}
