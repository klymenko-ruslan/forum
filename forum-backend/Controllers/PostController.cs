using System;
using forumbackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController: ControllerBase
    {
        [HttpPost]
        public Boolean AddPost(PostModel postModel)
        {
            return true;
        }
    }
}
