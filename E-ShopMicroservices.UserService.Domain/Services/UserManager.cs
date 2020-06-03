using E_ShopMicroservices.UserService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Domain.Services
{
    public class UserManager : IUserManager
    {
        public AppUser AddUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public AppUser GetUser(int Id)
        {
            throw new NotImplementedException();
        }

        public AppUser Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
