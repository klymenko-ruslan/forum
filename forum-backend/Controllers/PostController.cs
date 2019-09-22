using System;
using System.Collections.Generic;
using forumbackend.Models;
using forumbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController: ControllerBase
    {
        PostService postService = new PostService();

        [HttpPost]
        public Boolean AddPost([FromBody]PostDto postModel)
        {
            return postService.AddPost(postModel);
        }

        [HttpGet]
        [Route("{topicId}")]
        public List<PostModel> GetPosts(int topicId)
        {
            return postService.GetPosts(topicId);
        }

        [HttpDelete]
        [Route("{postId}")]
        public Boolean DeletePost(int postId)
        {
            return postService.RemovePost(postId);
        }
    }
}
