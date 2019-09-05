using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostComment.Core.Service
{
    public interface IPostItemService
    {
        Task CreatePostItem(PostItem postItem);
        Task CreateComment(Comment comment);
        Task DeletePostItem(int id);
        Task UpdatePostItem(PostItem postItem);
        Task<IEnumerable<Comment>> GetCommentsByPostItemId(int postId);
        Task<IEnumerable<PostItem>> GetAllPostsItems();
    }
}
