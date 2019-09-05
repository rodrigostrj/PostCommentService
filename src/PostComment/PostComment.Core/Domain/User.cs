using PostComment.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Domain
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
