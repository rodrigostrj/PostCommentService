using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.DTO.Command
{
    public class PostItemDTO
    {
        public int UserId { get; set; }
        public string Text { get; set; }
    }


}
