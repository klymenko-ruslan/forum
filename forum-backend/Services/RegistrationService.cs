using System;
using System.Linq;
using forumbackend.Config;
using forumbackend.Models;

namespace forumbackend.Services
{
    public class RegistrationService
    {

        private EncryptionService encryptionService = new EncryptionService();

        public bool Register(UserModel loginModel)
        {
            if(loginModel.username.Length == 0 || loginModel.password.Length == 0)
            {
                return false;
            }
            try {
                using (var context = new ChatContext())
                {
                    RoleModel role = context.RoleModel.SingleOrDefault(currentRole => currentRole.name == Role.user.ToString());
                    loginModel.role = role;
                    loginModel.password = encryptionService.MD5Hash(loginModel.password);
                    context.UserModel.Add(loginModel);
                    context.SaveChanges();
                    return true;
                }
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}
