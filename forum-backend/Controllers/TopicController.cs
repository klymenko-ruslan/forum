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
        private TopicService topicService;

        public TopicController(TopicService topicService)
        {
            this.topicService = topicService;
        }

        [HttpPost]
        public bool PostTopic([FromBody] TopicDto topicDto)
        {
            return topicService.PostTopic(topicDto);
        }

        [HttpGet]
        public List<TopicModel> GetTopics()
        {
            return topicService.GetTopics();
        }

        [HttpDelete]
        [Route("{topicId}")]
        public bool DeleteTopic(int topicId)
        {
            return topicService.RemoveTopic(topicId);
        }
    }
}
