using E_ShopMicroservices.Commons.Common.Exceptions;
using E_ShopMicroservices.UserService.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Domain.Services
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<AppUser> AddUser(AppUser user,string password)
        {
            var userIsExist = await _userManager.FindByNameAsync(user.UserName);
            if (userIsExist != null)
            {
                throw new UserFriendlyException("User Already Exist");
            }
            var result = await _userManager.CreateAsync(user,password);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new UserFriendlyException("Have Any Exception");
            }
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
