using E_ShopMicroservices.UserService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Domain.Services
{
    public interface IUserManager
    {
        AppUser GetUser(int Id);
        Task<AppUser> AddUser(AppUser user,string password);
        AppUser Login(string username,string password);
    }
}
