using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using PostComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Service.Validators
{
    public class PostValidator : IValidateService<PostItem>
    {
        private IUserRepository userRepository;

        public PostValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<Error> Validate(PostItem postItem)
        {
            var errors = new List<Error>();

            if (this.userRepository.FindById(postItem.UserId) == null)
            {
                errors.Add(new Error { Message = $"Unexistent UserId" });
            }

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
