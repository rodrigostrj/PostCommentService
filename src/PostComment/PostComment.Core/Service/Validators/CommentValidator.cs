using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using PostComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Service.Validators
{
    public class CommentValidator : IValidateService<Comment>
    {
        private IPostItemRepository postItemRepository;

        public CommentValidator(IPostItemRepository postItemRepository)
        {
            this.postItemRepository = postItemRepository;
        }

        public IEnumerable<Error> Validate(Comment comment)
        {
            var errors = new List<Error>();

            if (this.postItemRepository.FindById(comment.PostId) == null)
            {
                errors.Add(new Error { Message = $"Unexistent PostId" });
            }

            if (string.IsNullOrEmpty(comment?.Text))
            {
                errors.Add(new Error { Message = $"Null {nameof(comment)} text" });
            }

            if (comment.PostId <= 0)
            {
                errors.Add(new Error { Message = "Invalid PostId" });
            }

            return errors;
        }
    }
}
