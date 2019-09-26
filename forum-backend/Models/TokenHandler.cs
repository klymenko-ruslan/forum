using System;
namespace forumbackend.Models
{
    public class TokenHandler
    {
        public string token {get; set; }
        public int userId { get; set; }
        public string role { get; set; }
        public string username { get; set; }
    }
}
