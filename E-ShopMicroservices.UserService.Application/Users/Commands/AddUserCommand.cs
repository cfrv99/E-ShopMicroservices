using E_ShopMicroservices.Domain.Core.Bus;
using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Services;
using E_ShopMicroservices.UserService.Domain.Entites;
using E_ShopMicroservices.UserService.Domain.Events;
using E_ShopMicroservices.UserService.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Users.Commands
{
    public class AddUserCommand : IRequest<UserDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
    }
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDTO>
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IEventBus eventBus;
        private readonly IUserService userService;

        public AddUserCommandHandler(IServiceProvider serviceProvider,IEventBus eventBus,IUserService userService)
        {
            this.serviceProvider = serviceProvider;
            this.eventBus = eventBus;
            this.userService = userService;
        }
        public async Task<UserDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {           
            AppUser appUser = new AppUser
            {
                UserName = request.UserName,
            };
            
            var user = await userService.AddUser(appUser, request.Password);
            eventBus.Publish<UserCreated>(new UserCreated(user.Id, user.UserName));
            return new UserDTO
            {
                Id=user.Id,
                UserName=user.UserName
            };
        }
    }
}
