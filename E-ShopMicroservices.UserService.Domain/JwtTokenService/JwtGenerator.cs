using E_ShopMicroservices.UserService.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_ShopMicroservices.UserService.Domain.JwtTokenService
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<UserIdentity> userManager;

        public JwtGenerator(IConfiguration config,UserManager<UserIdentity> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Salam necesen TokenJWT"));
            this.userManager = userManager;
        }

        public string CreateToken(UserIdentity user)
        {
            var claims = GetClaims(user);

            // generate signing credentials
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

        }

        public List<Claim> GetClaims(UserIdentity user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            var getUserRoles = userManager.GetRolesAsync(user).Result;
            if (getUserRoles != null)
            {
                foreach (var role in getUserRoles)
                {
                    Claim claim = new Claim(ClaimTypes.Role, role);
                    claims.Add(claim);
                }
            }
            return claims;
        }
    }
}
