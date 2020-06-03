using E_ShopMicroservices.UserService.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Infrastructure.IoC.UserService.IoC
{
    public static class UserServiceDependencyContainer
    {
        public static void UserServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();
        }
    }
}
