using E_ShopMicroservices.Commons.Common.Exceptions;
using E_ShopMicroservices.UserService.Data.Context;
using E_ShopMicroservices.UserService.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly UserAppDbContext context;

        public UserService(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager,UserAppDbContext context)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.context = context;
        }
        public async Task<UserIdentity> AddUser(AppUser user, string password)
        {
            var userIsExist = await _userManager.FindByNameAsync(user.UserName);
            if (userIsExist != null)
            {
                throw new UserFriendlyException("User Already Exist");
            }
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new UserFriendlyException("Have Any Exception");
            }
            //return new AppUser();
        }

        public async Task<UserIdentity> GetUser(string Id)
        {
            if (Id == null)
            {
                throw new ValidationException("Id is null");
            }
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                throw new UserFriendlyException("User not found");
            }
            return user;
        }

        public async Task<UserIdentity> Login(string username, string password)
        {
            bool isExist = await context.Users.AnyAsync(i => i.UserName == username);
            if (isExist)
            {
                var user = await _userManager.FindByNameAsync(username);
                var result = _signInManager.PasswordSignInAsync(user, password, false, false).Result;
                if (result.Succeeded)
                {
                    return user;
                }
                else
                {
                    throw new UserFriendlyException("Username or Password wrong");
                }
            }
            else
            {
                throw new UserFriendlyException("Username have not in database");
            }
        }
    }
}
