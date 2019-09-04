using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostComment.Core.Domain;

namespace PostComment.Api.Controllers
{
    [Route("api/PostItem")]
    public class PostItemController : ControllerBase
    {
        public PostItemController()
        {

        }

        [HttpPost("PostItem")]
        public IActionResult PostItem(PostItem postItem)
        {
            throw new NotImplementedException();
        }

        [HttpPost("PostItem/{id}/Comment")]
        public IActionResult Comment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
