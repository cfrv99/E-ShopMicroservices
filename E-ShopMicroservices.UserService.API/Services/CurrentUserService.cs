using E_ShopMicroservices.Commons.Common.JwtCommon;
using E_ShopMicroservices.Commons.Common.Services;
using E_ShopMicroservices.UserService.API.Helpers;
using E_ShopMicroservices.UserService.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace E_ShopMicroservices.UserService.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var userId = GetHeaderValue(httpContextAccessor,"access_token");
            if (userId != null)
            {
                UserId = userId;
            }
        }
        public string UserId { get; set; }


        private string GetHeaderValue(IHttpContextAccessor httpContextAccessor, string headerKey)
        {
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Request.Headers.TryGetValue(headerKey, out StringValues headerValues))
            {
                return TokenReader.ReadToken(headerValues);
            }

            return string.Empty;
        }
        
    }
}
