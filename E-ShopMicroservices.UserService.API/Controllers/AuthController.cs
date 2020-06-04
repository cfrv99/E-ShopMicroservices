using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_ShopMicroservices.UserService.Application.Models;
using E_ShopMicroservices.UserService.Application.Users.Commands;
using E_ShopMicroservices.UserService.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace E_ShopMicroservices.UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Add(AddUserCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(LoginUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("getUser/{userId}")]
        public async Task<ActionResult<UserModel>> GetUser([FromRoute]GetUserQuery query)
        {

            return await Mediator.Send(new GetUserQuery() { userId=query.userId });
        }
    }
}