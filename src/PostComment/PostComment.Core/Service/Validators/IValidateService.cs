using PostComment.Core.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Service.Validators
{
    public interface IValidateService<T>
    {
        IEnumerable<Error> Validate(T entity);
    }
}
