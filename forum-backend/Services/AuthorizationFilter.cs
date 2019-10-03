using System;
using forumbackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace forumbackend.Services
{
    public class AuthorizationFilter : IResourceFilter
    {

        private EncryptionService encryptionService;
        private UserService userService;

        public AuthorizationFilter(EncryptionService encryptionService,
                                   UserService userService)
        {
            this.encryptionService = encryptionService;
            this.userService = userService;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];
            var userIdString = encryptionService.getUserIdFromToken(token);
            Console.WriteLine(userIdString);
            var userId = Int32.Parse(encryptionService.getUserIdFromToken(token));
            UserModel userModel = userService.GetUserById(userId);
            if(!userModel.role.name.Equals(Role.admin.ToString()))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }
    }
}
