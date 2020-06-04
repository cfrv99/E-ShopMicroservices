using E_ShopMicroservice.Microservices.ProductService.Domain.Events;
using E_ShopMicroservices.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopMicroservice.Microservices.ProductService.Domain.EventHandlers
{
    public class UserCreatedEventHandler : IEventHandler<UserCreated>
    {
        public Task Handle(UserCreated @event)
        {
            throw new NotImplementedException();
        }
    }
}
