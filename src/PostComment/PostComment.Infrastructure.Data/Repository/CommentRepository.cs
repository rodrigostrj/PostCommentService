using PostComment.Core.Domain;
using PostComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostComment.Infrastructure.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private PostCommentDBContext postCommentDBContext;

        public CommentRepository(PostCommentDBContext postCommentDBContext)
        {
            this.postCommentDBContext = postCommentDBContext;
        }

        public IEnumerable<Comment> List => throw new NotImplementedException();

        public void Add(Comment comment)
        {
            this.postCommentDBContext
                .Comments
                .Add(comment);

            this.postCommentDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Comment FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> FindByPostId(int postId)
        {
            return this.postCommentDBContext
                 .Comments.Where(x => x.PostId == postId)
                 .ToList();
        }

        public void Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
