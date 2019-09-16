using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forumbackend.Models
{
    [Table("topics")]
    public class TopicModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public virtual UserModel author { get; set; }
    }
}
