using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forumbackend.Models
{
    [Table("entities")]
    public class PostModel
    {
        [Key]
        public int id { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public TopicModel topic { get; set; }
        public UserModel author { get; set; }
    }
}
