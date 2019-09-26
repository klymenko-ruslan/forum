using System;
using System.Collections.Generic;
using forumbackend.Models;
using forumbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController
    {

        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        public List<UserModel> GetUsers()
        {
            return userService.GetUsers();
        }

        [Route("{userId}")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public Boolean RemoveUser(int userId)
        {
            return userService.RemoveUser(userId);
        }
    }
}
