using PostComment.Core.Domain;
using PostComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace PostComment.Infrastructure.Data
{
    public class UnitOfWork : PostCommentDBContext, IUnitOfWork
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<PostItem> _postItemRepository;
        private readonly IRepository<Comment> _commentRepository;

        public DbSet<User> Users { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public IRepository<User> UserRepository => this._userRepository;

        public IRepository<PostItem> PostItemRepository => this._postItemRepository;

        public IRepository<Comment> CommentRepository => this._commentRepository;

        public UnitOfWork()
        {
            this._userRepository = new Repository<User>(Users);
            this._postItemRepository = new Repository<PostItem>(PostItems);
            this._commentRepository = new Repository<Comment>(Comments);
        }


        public void Commit()
        {
            this.SaveChanges();
        }


    }
}
