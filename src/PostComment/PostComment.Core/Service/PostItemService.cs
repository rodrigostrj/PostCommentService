using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PostComment.Core.Domain;
using PostComment.Core.Interfaces;

namespace PostComment.Core.Service
{
    public class PostItemService : IPostItemService
    {
        private IUnitOfWork unitOfWork;

        public PostItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

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

        public async Task<IEnumerable<PostItem>> GetAllPostsItems()
        {
            return this.unitOfWork.PostItemRepository.GetAll();
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
