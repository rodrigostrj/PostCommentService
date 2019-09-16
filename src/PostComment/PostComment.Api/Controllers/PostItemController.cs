using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostComment.Core.Domain;
using PostComment.Core.Domain.Errors;
using PostComment.Core.DTO;
using PostComment.Core.DTO.Command;
using PostComment.Core.Service;

namespace PostComment.Api.Controllers
{
    [Route("api/PostItem")]
    public class PostItemController : ControllerBase
    {
        private IPostItemService postItemService;

        public PostItemController(IPostItemService postItemService)
        {
            this.postItemService = postItemService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Error>))]
        public async Task<IActionResult> PostItemAsync(PostItemDTO postItem)
        {
            var result = await this.postItemService.CreatePostItem(postItem.ToDomain());

            if (result.Count() > 0)
            {
                return StatusCode(400, result);
            }

            return StatusCode(201);
        }

        [HttpPost("{id}/Comment")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Error>))]
        public async Task<IActionResult> Comment(CommentDTO comment, int id)
        {
            var _comment = comment.ToDomain();
            _comment.PostId = id;
            var result = await this.postItemService.CreateComment(_comment);

            if (result.Count() > 0)
            {
                return StatusCode(400, result);
            }

            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostItem(int id)
        {
            await this.postItemService.DeletePostItem(id);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Error>))]
        public async Task<IActionResult> UpdatePostItem(PostItem postItem)
        {
            await this.postItemService.UpdatePostItem(postItem);
            return Ok();
        }

        [HttpGet("/{id}/comments")]
        [ProducesResponseType(200, Type = typeof(IList<Comment>))]
        public async Task<IActionResult> GetComments(int id)
        {
            var comments = await this.postItemService.GetCommentsByPostItemId(id);
            return Ok(comments);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<PostItem>))]
        public async Task<IActionResult> GetAllPostsItems()
        {
            var postItem = await this.postItemService.GetAllPostsItems();
            return Ok(postItem);
        }
    }
}
