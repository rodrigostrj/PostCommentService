using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Domain
{
    public class Comment : TextItem
    {
        public int PostId { get; set; }
    }
}
