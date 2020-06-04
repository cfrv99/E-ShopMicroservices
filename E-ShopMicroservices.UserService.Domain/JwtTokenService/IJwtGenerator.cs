using E_ShopMicroservices.UserService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Domain.JwtTokenService
{
    public interface IJwtGenerator
    {
        string CreateToken(UserIdentity user);
        string GenerateRefreshToken();
    }
}
