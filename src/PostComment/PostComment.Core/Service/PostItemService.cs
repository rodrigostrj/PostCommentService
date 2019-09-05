using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PostComment.Core.Domain;

namespace PostComment.Core.Service
{
    public class PostItemService : IPostItemService
    {
        public Task CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task CreatePostItem(PostItem postItem)
        {
            throw new NotImplementedException();
        }

        public Task DeletePostItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostItem>> GetAllPostsItems()
        {
            return null;
        }

        public Task<IEnumerable<Comment>> GetCommentsByPostItemId(int postId)
        {
            return null;
        }

        public Task UpdatePostItem(PostItem postItem)
        {
            throw new NotImplementedException();
        }
    }
}
