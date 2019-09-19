using System;
using System.Net;
using System.Net.Http;
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
        public TokenHandler Login([FromBody] UserModel loginModel)
        {
            return loginService.Login(loginModel);
        }
    }
}
