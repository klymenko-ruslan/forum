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
        PostService postService;

        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        public Boolean AddPost([FromBody]PostDto postModel)
        {
            return postService.AddPost(postModel);
        }

        [HttpPut]
        public Boolean UpdatePost([FromBody]PostDto postModel)
        {
            return postService.UpdatePost(postModel);
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
