using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Application.Models
{
    public class AccessTokenModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
