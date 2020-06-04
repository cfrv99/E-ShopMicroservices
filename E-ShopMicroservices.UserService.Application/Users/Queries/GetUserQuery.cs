using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Users.Queries
{
    public class GetUserQuery:IRequest<UserModel>
    {
        public string userId { get; set; }
    }

    public class GetUserCommandHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IUserService userService;

        public GetUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUser(request.userId);
            return new UserModel
            {
                Id=user.Id,
                Name = user.UserName
            };
        }
    }
}
