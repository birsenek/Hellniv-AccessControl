using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Helniv_AccessControl.Services
{
    public class AuthenticationService
    {
        public AuthenticatedResponse GenerateAuthenticationToken(User user)
        {
            string name = "name";
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superScreteKey@123"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                {
                    new Claim(name, user.Login),
                    new Claim(ClaimTypes.Role, "Manager")
                };
            var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7111",
                    audience: "https://localhost:7111",
                    claims: claims,
                    expires: DateTime.Now.AddHours(4),
                    signingCredentials: signinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthenticatedResponse { Token = tokenString };
        }
    }
}
