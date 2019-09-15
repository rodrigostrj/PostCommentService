using PostComment.Core.Domain;
using PostComment.Core.DTO.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.DTO
{
    public static class DtoMapper
    {
        public static PostItem ToDomain(this PostItemDTO postItemDTO)
        {
            return new PostItem { Text = postItemDTO.Text, UserId = postItemDTO.UserId };
        }
    }
}
