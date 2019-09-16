using PostComment.Core.Domain;
using PostComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Infrastructure.Data.Repository
{
    public class PostItemRepository : IPostItemRepository
    {
        private PostCommentDBContext postCommentDBContext;

        public PostItemRepository(PostCommentDBContext postCommentDBContext)
        {
            this.postCommentDBContext = postCommentDBContext;
        }

        public IEnumerable<PostItem> List
        {
            get
            {
                return this.postCommentDBContext.PostItems;
            }
        }

        public void Add(PostItem postItem)
        {
            this.postCommentDBContext
                .PostItems
                .Add(postItem);

            this.postCommentDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PostItem FindById(int id)
        {
            return this.postCommentDBContext
                .Find<PostItem>(id);
        }

        public void Update(PostItem postItem)
        {
            throw new NotImplementedException();
        }
    }
}
