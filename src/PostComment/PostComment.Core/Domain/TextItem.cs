using PostComment.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Domain
{
    public abstract class TextItem : BaseEntity
    {
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
