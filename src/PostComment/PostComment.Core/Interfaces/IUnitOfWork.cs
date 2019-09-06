using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<PostItem> PostItemRepository { get; }
        IRepository<Comment> CommentRepository { get; }

        void Commit();
    }
}
