using System;
using forumbackend.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace forumbackend.Config
{
    public class ChatContext : DbContext
    {
        public DbSet<UserModel> UserModel
        {
            get;
            set;
        }
        public DbSet<RoleModel> RoleModel
        {
            get;
            set;
        }
        public DbSet<TopicModel> TopicModel
        {
            get;
            set;
        }
        public DbSet<PostModel> PostModel
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=forum;User Id=sa;Password=testtest1!;");
        }
    }
}
