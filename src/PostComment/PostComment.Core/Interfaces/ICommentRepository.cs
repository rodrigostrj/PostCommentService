using PostComment.Core.Domain;
using PostComment.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostComment.Core.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> List { get; }
        void Add(Comment comment);
        void Delete(int id);
        void Update(Comment comment);
        Comment FindById(int Id);
        Task<IEnumerable<Comment>> FindByPostId(int postId);
    }
}
