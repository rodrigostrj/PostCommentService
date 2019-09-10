using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostComment.Core.Service
{
    public interface IPostItemService
    {
        Task<IEnumerable<Error>> CreatePostItem(PostItem postItem);
        Task<IEnumerable<Error>> CreateComment(Comment comment);
        Task DeletePostItem(int id);
        Task UpdatePostItem(PostItem postItem);
        Task<IEnumerable<Comment>> GetCommentsByPostItemId(int postId);
        Task<IEnumerable<PostItem>> GetAllPostsItems();
    }
}
