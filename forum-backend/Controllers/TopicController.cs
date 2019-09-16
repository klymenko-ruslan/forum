using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using forumbackend.Models;
using forumbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace forumbackend.Controllers
{
    [Route("topic")]
    [ApiController]
    public class TopicController
    {
        private TopicService topicService = new TopicService();

        [HttpPost]
        public String PostTopic(TopicModel topicModel)
        {
            topicService.PostTopic(topicModel);
            return "";
        }

        [HttpGet]
        public List<TopicModel> GetTopics()
        {
            Console.WriteLine(topicService.GetTopics()[0].author.id +  "!!!!!");
            return topicService.GetTopics();
        }
    }
}
