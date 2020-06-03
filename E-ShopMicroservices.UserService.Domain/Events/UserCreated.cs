using E_ShopMicroservices.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Domain.Events
{
    public class UserCreated:Event
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public UserCreated(int userId,string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
