using E_ShopMicroservices.UserService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Domain.Services
{
    public interface IUserManager
    {
        AppUser GetUser(int Id);
        AppUser AddUser(AppUser user);
        AppUser Login(string username,string password);
    }
}
