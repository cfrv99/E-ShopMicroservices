using E_ShopMicroservices.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservice.Microservices.ProductService.Domain.Events
{
    public class UserCreated : Event
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public UserCreated(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
