using System;
using System.Collections.Generic;
using System.Linq;
using forumbackend.Config;
using forumbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace forumbackend.Services
{
    public class PostService
    {

        public bool AddPost(PostDto postDto)
        {
            using (var context = new ChatContext())
            {
                PostModel postModel = new PostModel();
                postModel.timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                postModel.author = context.UserModel.First(user => user.id == postDto.authorid);
                postModel.topic = context.TopicModel.First(topic => topic.id == postDto.topicid);
                if (postDto.replytoid != 0)
                {
                    postModel.replyto = context.PostModel.First(post => post.id == postDto.replytoid);
                //    postModel.message = "'" + postModel.replyto.message + "'<br />" + postDto.message;
                }
               // else
              //  {
                    postModel.message = postDto.message;
               // }
                context.PostModel.Add(postModel);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdatePost(PostDto postDto)
        {
            using (var context = new ChatContext())
            {
                PostModel postModel = context.PostModel.First(post => post.id == postDto.postId);
                postModel.message = postDto.message;
                context.SaveChanges();
                return true;
            }
        }

        public List<PostModel> GetPosts(int topicId)
        {
            using (var context = new ChatContext())
            {
                return context.PostModel
                .Include(post => post.author)
                .Include(post => post.topic)
                .Where(post => post.topic.id == topicId)
                .ToList();
            }
        }

        public bool RemovePost(int postId)
        {
            using (var context = new ChatContext())
            {
                PostModel postModel = context.PostModel.First(post => post.id == postId);
                context.PostModel.Remove(postModel);
                context.SaveChanges();
                return true;
            }
        }
    }
}
