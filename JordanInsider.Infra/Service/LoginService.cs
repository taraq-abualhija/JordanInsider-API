using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public string GenearteToken(User user) // return token value 
        {
            try
            {
                var identity = loginRepository.GenerateToken(user); // return roleid and username if they match

                if (identity == null)
                {

                    return null;
                }
                else
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloooJordannnnIiinsiderrr@34567"));//Encode header + payload of token 
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>
                {
                    new Claim("UserId", identity.Userid.ToString()),
                   new Claim("RoleId", identity.Roleid.ToString()),
                };

                    var tokeOptions = new JwtSecurityToken(
                                        claims: claims,
                                         expires: DateTime.Now.AddHours(24),
                                         signingCredentials: signinCredentials
                            );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return tokenString;

                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());

            }

            return null;
    }
    }

}