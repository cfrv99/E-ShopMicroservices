using E_ShopMicroservices.UserService.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Services
{
    public interface IUserService
    {
        Task<UserIdentity> GetUser(string Id);
        Task<UserIdentity> AddUser(AppUser user, string password);
        Task<UserIdentity> Login(string username, string password);
    }
}
