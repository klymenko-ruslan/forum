using System;
using System.Collections.Generic;
using System.Linq;
using forumbackend.Config;
using forumbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace forumbackend.Services
{
    public class TopicService
    {
        public bool PostTopic(TopicDto topicDto)
        {
            using (var context = new ChatContext())
            {
                Console.WriteLine("!!" + topicDto.name);
                TopicModel topicModel = new TopicModel();
                topicModel.name = topicDto.name;
                topicModel.author = context.UserModel.First(user => user.id == topicDto.authorid);
                context.TopicModel.Add(topicModel);
                context.SaveChanges();
                return true;
            }
        }

        public List<TopicModel> GetTopics()
        {
            using (var context = new ChatContext())
            {
                return context.TopicModel.Include(topic => topic.author).ToList();
            }
        }
    }
}
