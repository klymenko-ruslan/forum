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

        private EncryptionService encryptionService;

        public LoginService(EncryptionService encryptionService)
        {
            this.encryptionService = encryptionService;
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
                    tokenHandler.token = encryptionService.generateToken(user.id.ToString());
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
