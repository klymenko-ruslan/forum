using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using forumbackend.Config;
using forumbackend.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace forumbackend.Services
{
    public class LoginService
    {

        private EncryptionService encryptionService = new EncryptionService();

        public string generateToken(string useId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("it's the most secure secret!");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, useId)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public TokenHandler Login(UserModel userModel)
        {
            using (var context = new ChatContext())
            {
                string encryptedPassword = encryptionService.MD5Hash(userModel.password);
                UserModel user = 
                context.UserModel
                    .Include(currentUser => currentUser.role).SingleOrDefault(currentUser => currentUser.username.Equals(userModel.username));
                if (user != null && encryptedPassword.Equals(user.password))
                {
                    TokenHandler tokenHandler = new TokenHandler();
                    tokenHandler.token = generateToken(user.id.ToString());
                    tokenHandler.role = user.role.name;
                    tokenHandler.userId = user.id;
                    tokenHandler.username = user.username;
                    return tokenHandler;
                }
                return null;
            }
        }
    }
}
