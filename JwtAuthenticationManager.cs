using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GEMS_Cloud
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        public readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string Username, string Password)
        {
            using (var context=new MyDbContext())
            {
                if (!context.User.Any(u => u.Username == Username && u.Password == Password))
                {
                    return null;
                }
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokendescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}
