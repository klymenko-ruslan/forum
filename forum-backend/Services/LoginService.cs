using System;
using forumbackend.Config;
using forumbackend.Models;

namespace forumbackend.Services
{
    public class LoginService
    {
        public LoginService()
        {
        }

        public bool Login(LoginModel loginModel)
        {
            using (var context = new ChatContext())
            {
                context.LoginModel.Add(loginModel);
                context.SaveChanges();
            }
            return true;
        }
    }
}
