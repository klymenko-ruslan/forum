using System;
using System.Collections.Generic;
using forumbackend.Config;
using forumbackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace forumbackend.Services
{
    public class UserService
    {
        public List<UserModel> GetUsers()
        {
            using (var context = new ChatContext())
            {
                return context.UserModel
                .Include(user => user.role).ToList();
            }
        }

        public UserModel GetUserById(int userId)
        {
            using (var context = new ChatContext())
            {
                return context.UserModel.Include(user => user.role).First(user => user.id == userId);
            }
        }

        public bool RemoveUser(int userId)
        {
            using (var context = new ChatContext())
            {
                List<TopicModel> topics = context.TopicModel.Include(topic => topic.author).Where(topic => topic.author.id == userId).ToList();
                foreach(TopicModel topic in topics)
                {
                    List<PostModel> posts = context.PostModel.Include(post => post.topic).Where(post => post.topic.id == topic.id).ToList();
                    foreach(PostModel post in posts)
                    {
                        context.PostModel.Remove(post);
                    }
                    context.TopicModel.Remove(topic);
                }
                List<PostModel> postModels = context.PostModel.Include(post => post.author).Where(post => post.author.id == userId).ToList();
                foreach(PostModel postModel in postModels)
                {
                    context.PostModel.Remove(postModel);
                }
                UserModel userModel = context.UserModel.First(user => user.id == userId);
                context.UserModel.Remove(userModel);
                context.SaveChanges();
                return true;
            }
        }
    }
}