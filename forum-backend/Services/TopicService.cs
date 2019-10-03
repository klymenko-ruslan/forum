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
                TopicModel topicModel = new TopicModel();
                topicModel.name = topicDto.name;
                topicModel.author = context.UserModel.First(user => user.id == topicDto.authorid);
                context.TopicModel.Add(topicModel);
                context.SaveChanges();
                return true;
            }
        }

        public bool RemoveTopic(int topicId)
        {
            using (var context = new ChatContext())
            {
                List<PostModel> postModel = context.PostModel.Where(post => post.topic.id == topicId).ToList();
                foreach(PostModel model in postModel)
                {
                    context.PostModel.Remove(model);
                }
                TopicModel topicModel = context.TopicModel.First(topic => topic.id == topicId);
                context.TopicModel.Remove(topicModel);
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
