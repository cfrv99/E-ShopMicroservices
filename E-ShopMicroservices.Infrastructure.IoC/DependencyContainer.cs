using E_ShopMicroservice.Microservices.ProductService.Domain.Entities;
using E_ShopMicroservices.Commons.Common.Domains.Interfaces;
using E_ShopMicroservices.Data.DAL.Repository;
using E_ShopMicroservices.Infrastructure.IoC.EventBus.IoC;
using E_ShopMicroservices.Infrastructure.IoC.UserService.IoC;
using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Services;
using E_ShopMicroservices.UserService.Application.Users.Commands;
using E_ShopMicroservices.UserService.Application.Users.Queries;
using E_ShopMicroservices.UserService.Domain.Entites;
using E_ShopMicroservices.UserService.Domain.JwtTokenService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.EventBusRegisterService();
            services.UserServiceRegister();
            services.AddTransient<IRequestHandler<AddUserCommand, UserDTO>, AddUserCommandHandler>();
            services.AddTransient<IRequestHandler<LoginUserCommand, UserModel>, LoginUserCommandHandler>();
            services.AddTransient<IRequestHandler<GetUserQuery, UserModel>, GetUserCommandHandler>();
            services.AddTransient<IUserService, E_ShopMicroservices.UserService.Application.Services.UserService>();
            services.AddTransient<IJwtGenerator, JwtGenerator>();
            //services.AddTransient(typeof(UserManager<>));
            //services.AddTransient(typeof(SignInManager<>));
            //services.AddTransient(typeof(IRepository<Product, int>), typeof(EfRepository<Product, int>));

        }
    }
}
