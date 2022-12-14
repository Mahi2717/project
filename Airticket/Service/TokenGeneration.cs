using Airticket.Models;
using Airticket.UserCred;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Airticket.AdminCred;

namespace Airticket.Service
{
    public class TokenGeneration : ITokenGeneration
    {
        private readonly IConfiguration _configuration;
        //Constructor
        public TokenGeneration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Login userCreds)
        {
            var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userCreds.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)



            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateToken(AdminLogin adminCreds)
        {
            var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,adminCreds.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)



            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    
    }


}
