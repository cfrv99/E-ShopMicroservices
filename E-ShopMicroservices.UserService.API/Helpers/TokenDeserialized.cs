using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.API.Helpers
{

    public class TokenDeserialized
    {
        public string nameid { get; set; }
        public string unique_name { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public int iat { get; set; }
    }

}
