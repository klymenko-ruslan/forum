using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forumbackend.Models
{
    [Table("roles")]
    public class RoleModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
