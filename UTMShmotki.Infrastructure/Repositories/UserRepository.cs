﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;
using UTMShmotki.Infrastructure.Contexts;

namespace UTMShmotki.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IConfiguration _configuration;
        private readonly StoreDbContext _storeDbContext;
        public UserRepository(IConfiguration configuration, StoreDbContext storeDbContext)
        {
            _configuration = configuration;
            _storeDbContext = storeDbContext;
        }

        public string GetToken(UserInfo userInfo)
        {
            if(userInfo != null)
            {
                var user = _storeDbContext.Users.Where(u => u.UserName.Equals(userInfo.UserName) && 
                    u.Password.Equals(userInfo.Password)).SingleOrDefault();

                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email),
                        new Claim("Password", user.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }

            return null;
        }
    }
}