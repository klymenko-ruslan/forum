using System;
namespace forumbackend.Models
{
    public class PostDto
    {
        public int postId { get; set; }
        public string message { get; set; }
        public int topicid { get; set; }
        public int authorid { get; set; }
        public Int32 replytoid { get; set; }
    }
}
