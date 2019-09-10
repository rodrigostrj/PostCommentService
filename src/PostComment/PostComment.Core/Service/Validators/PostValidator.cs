using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Service.Validators
{
    public class PostValidator : IValidateService<PostItem>
    {
        public IEnumerable<Error> Validate(PostItem postItem)
        {
            var errors = new List<Error>();

            if (string.IsNullOrEmpty(postItem?.Text))
            {
                errors.Add(new Error { Message = $"Null postItem text" });
            }

            if (postItem.UserId <= 0)
            {
                errors.Add(new Error { Message = "Invalid UserId" });
            }

            return errors;
        }
    }
}
