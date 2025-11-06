using Code.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Code.Common
{
    public static class Usermethods
    {
        
        public static Usermodel AuthenticateUser(Usermodel login)
        {
            Usermodel user = null;

            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            if (login.Username.ToLower() == "manideep" && login.Password == "manideep@123")
            {
                user = new Usermodel { Status = "Success", Username = login.Username, EmailAddress = login.EmailAddress, DateofJoining = login.DateofJoining };
            }
            else
            {
                user = new Usermodel { Status = "Login Failed", Username = login.Username, EmailAddress = login.EmailAddress, DateofJoining = login.DateofJoining };
            }
            return user;
        }
        public static string GenerateJSONWebToken(Usermodel userInfo,string key,string Audience,string Issuer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, "mandeep@gmail.com"),
                new Claim(JwtRegisteredClaimNames.Name, userInfo.Username),
                new Claim("DateOfJoing", userInfo.DateofJoining.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud,Audience),
                new Claim(JwtRegisteredClaimNames.Iss, Issuer)
            };

            var token = new JwtSecurityToken(Issuer,
                Issuer,
                claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);
            // string returnedtoken = new JwtSecurityTokenHandler().WriteToken(token);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
