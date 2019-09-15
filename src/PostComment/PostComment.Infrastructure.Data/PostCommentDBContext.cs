using Microsoft.EntityFrameworkCore;
using PostComment.Core.Domain;

namespace PostComment.Infrastructure.Data
{
    public class PostCommentDBContext : DbContext
    {
        public PostCommentDBContext(DbContextOptions<PostCommentDBContext> options)
        : base(options)
        {
            this.Database.EnsureCreated(); // Just for test
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}