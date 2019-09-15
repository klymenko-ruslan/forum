using System;
using forumbackend.Models;
using forumbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private LoginService loginService = new LoginService();

        [HttpPost]
        public void Login([FromBody] LoginModel loginModel)
        {
            loginService.Login(loginModel);
            Console.WriteLine(loginModel.username);
            Console.WriteLine(loginModel.password);
        }
    }
}
