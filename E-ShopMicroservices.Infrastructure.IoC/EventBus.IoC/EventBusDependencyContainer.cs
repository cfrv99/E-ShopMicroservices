using E_ShopMicroservice.Infrastructure.Bus.Buses;
using E_ShopMicroservices.Domain.Core.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Infrastructure.IoC.EventBus.IoC
{
    public static class EventBusDependencyContainer
    {
        public static void EventBusRegisterService(this IServiceCollection service)
        {
            service.AddTransient<IEventBus, RabbitMqBus>();
        }
    }
}
