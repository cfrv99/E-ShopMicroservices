using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Data.Context;
using E_ShopMicroservices.UserService.Domain.Entites;
using E_ShopMicroservices.UserService.Domain.JwtTokenService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.Application.Users.Commands
{
    public class RevokeRequestCommand:IRequest<AccessTokenModel>
    {
        public string RefreshToken { get; set; }
    }

    public class RevokeRequestCommandHandler : IRequestHandler<RevokeRequestCommand, AccessTokenModel>
    {
        private readonly UserAppDbContext userAppDbContext;
        private readonly IJwtGenerator jwtGenerator;

        public RevokeRequestCommandHandler(UserAppDbContext userAppDbContext,IJwtGenerator jwtGenerator)
        {
            this.userAppDbContext = userAppDbContext;
            this.jwtGenerator = jwtGenerator;
        }
        public async Task<AccessTokenModel> Handle(RevokeRequestCommand request, CancellationToken cancellationToken)
        {
            var userToken = await userAppDbContext.Tokens.Include(i => i.AppUser)
                .Where(i => i.RefreshToken == request.RefreshToken).FirstOrDefaultAsync();

            UserIdentity user = userToken.AppUser;

            return new AccessTokenModel
            {
                AccessToken = jwtGenerator.CreateToken(user),
                ExpDate = DateTime.Now.AddMinutes(100)
            };
        }
    }
}
