using E_ShopMicroservices.Commons.Common.Exceptions;
using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Services;
using E_ShopMicroservices.UserService.Data.Context;
using E_ShopMicroservices.UserService.Domain.Entites;
using E_ShopMicroservices.UserService.Domain.JwtTokenService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Users.Commands
{
    public class LoginUserCommand : IRequest<UserModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserModel>
    {
        private readonly IUserService userService;
        private readonly IJwtGenerator jwtGenerator;
        private readonly UserAppDbContext context;

        public LoginUserCommandHandler(IUserService userService, IJwtGenerator jwtGenerator, UserAppDbContext context)
        {
            this.userService = userService;
            this.jwtGenerator = jwtGenerator;
            this.context = context;
        }
        public async Task<UserModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.Login(request.UserName, request.Password);
            

            var userToken = context.Tokens.FirstOrDefault(i => i.AppUserId == user.Id);
            if (userToken == null)
            {
                Token token = new Token
                {
                    AppUserId = user.Id,
                    ExpireDate = DateTime.Now.AddDays(100),
                    RefreshToken = jwtGenerator.GenerateRefreshToken()
                };

                context.Tokens.Add(token);

            }
            else
            {
                userToken.RefreshToken = jwtGenerator.GenerateRefreshToken();
                userToken.ExpireDate = DateTime.Now.AddDays(100);
                context.Tokens.Update(userToken);
            }

            int result = await context.SaveChangesAsync();

            if (result <= 0)
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Problem was been saving");
            }
            UserModel response = new UserModel
            {
                Id = user.Id,
                Name = user.UserName,
                Access_Token = jwtGenerator.CreateToken(user),
                RefreshToken = userToken.RefreshToken
            };
            return response;

        }
    }
}
