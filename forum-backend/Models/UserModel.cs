using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forumbackend.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public virtual RoleModel role { get; set; }
    }
}
