using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using PostComment.Core.Interfaces;
using PostComment.Core.Service.Validators;

namespace PostComment.Core.Service
{
    public class PostItemService : IPostItemService
    {
        private IPostItemRepository postItemRepository;
        private ICommentRepository commentRepository;
        private PostValidator postValidator;
        private CommentValidator commentValidator;

        public PostItemService(
            IPostItemRepository postItemRepository,
            ICommentRepository commentRepository,
            PostValidator postValidator,
            CommentValidator commentValidator)
        {
            this.postItemRepository = postItemRepository;
            this.commentRepository = commentRepository;
            this.postValidator = postValidator;
            this.commentValidator = commentValidator;
        }

        public async Task<IEnumerable<Error>> CreateComment(Comment comment)
        {
            comment.CreateDate = DateTime.Now;
            var errors = this.commentValidator.Validate(comment);
            this.commentRepository.Add(comment);
            return errors;
        }

        public async Task<IEnumerable<Error>> CreatePostItem(PostItem postItem)
        {
            postItem.CreateDate = DateTime.Now;
            var errors = this.postValidator.Validate(postItem);
            this.postItemRepository.Add(postItem);
            return errors;
        }

        public Task DeletePostItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostItem>> GetAllPostsItems()
        {
            return this.postItemRepository.List;
        }

        public Task<IEnumerable<Comment>> GetCommentsByPostItemId(int postId)
        {
            return this.commentRepository.FindByPostId(postId);
        }

        public async Task UpdatePostItem(PostItem postItem)
        {
            postItem.UpdateDate = DateTime.Now;
            this.postItemRepository.Update(postItem);
        }
    }
}
