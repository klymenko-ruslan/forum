using System;
using System.Data.Entity;
using forumbackend.Models;
using System.Data.SqlClient;
namespace forumbackend.Config
{
    public class ChatContext : DbContext
    {
        public DbSet<LoginModel> LoginModel
        {
            get;
            set;
        }

        public ChatContext() : base("name = ChatContext")
        {
        }
    }
}
