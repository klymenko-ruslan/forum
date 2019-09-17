using System;
using System.Collections.Generic;
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

        [HttpGet]
        public List<PostModel> GetPosts(int topicId)
        {
            Console.WriteLine("!!!!!" + topicId);
            return null;
        }
    }
}
