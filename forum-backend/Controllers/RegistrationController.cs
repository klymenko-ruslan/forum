using System;
using forumbackend.Models;
using forumbackend.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [Route("register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationService registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpPost]
        public bool Register(UserModel userModel)
        {
            return registrationService.Register(userModel);
        }
    }
}
