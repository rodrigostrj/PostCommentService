using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Service.Validators
{
    public class CommentValidator : IValidateService<Comment>
    {
        public IEnumerable<Error> Validate(Comment comment)
        {
            var errors = new List<Error>();

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
