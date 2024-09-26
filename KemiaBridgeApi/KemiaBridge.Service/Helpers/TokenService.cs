using KemiaBridge.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KemiaBridge.Service.Helpers
{
    public class TokenService
    {
        public static object GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret());
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", user.UserId.ToString()),
                    new Claim("userEmail", user.Email),
                    new Claim("userName", user.Name),
                    new Claim("userType", user.Type.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(168),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);

            return new
            {
                token = tokenHandler.WriteToken(token),
            };
        }
    }
}
