using System;
using forumbackend.Models;
using forumbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [Route("register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationService registrationService = new RegistrationService();

        [HttpPost]
        public void Register(UserModel userModel)
        {
            registrationService.Register(userModel);
        }
    }
}
