using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Domain.Entites
{
    public class Token
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireDate { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
