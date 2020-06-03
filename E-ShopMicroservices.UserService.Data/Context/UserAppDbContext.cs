using E_ShopMicroservices.UserService.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.UserService.Data.Context
{
    public class UserAppDbContext : IdentityDbContext<UserIdentity,Role,string>
    {
        public UserAppDbContext(DbContextOptions<UserAppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
