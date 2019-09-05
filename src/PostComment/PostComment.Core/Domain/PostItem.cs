using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Domain
{
    public class PostItem : TextItem
    {
        public Guid UserId { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
