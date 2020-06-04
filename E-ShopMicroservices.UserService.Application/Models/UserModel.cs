using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Application.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Access_Token { get; set; }
    }
}
