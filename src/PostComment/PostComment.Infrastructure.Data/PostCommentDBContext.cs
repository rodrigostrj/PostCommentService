using Microsoft.EntityFrameworkCore;
using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PostComment.Infrastructure.Data
{
    public class PostCommentDBContext : DbContext
    {
        public PostCommentDBContext(DbContextOptions<PostCommentDBContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}