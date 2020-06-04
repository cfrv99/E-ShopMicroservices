using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Services;
using E_ShopMicroservices.UserService.Domain.JwtTokenService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Users.Commands
{
    public class LoginUserCommand:IRequest<UserModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserModel>
    {
        private readonly IUserService userService;
        private readonly IJwtGenerator jwtGenerator;

        public LoginUserCommandHandler(IUserService userService,IJwtGenerator jwtGenerator)
        {
            this.userService = userService;
            this.jwtGenerator = jwtGenerator;
        }
        public async Task<UserModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.Login(request.UserName, request.Password);
            UserModel response = new UserModel
            {
                Id = user.Id,
                Name = user.UserName,
                Access_Token = jwtGenerator.CreateToken(user)
            };
            return response;

        }
    }
}
