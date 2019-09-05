using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostComment.Core.Domain;
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
        public async Task<IActionResult> PostItemAsync(PostItem postItem)
        {
            await this.postItemService.CreatePostItem(postItem);
            return StatusCode(201);
        }

        [HttpPost("{id}/Comment")]
        public async Task<IActionResult> Comment(Comment comment)
        {
            await this.postItemService.CreateComment(comment);
            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostItem(int id)
        {
            await this.postItemService.DeletePostItem(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostItem(PostItem postItem)
        {
            await this.postItemService.UpdatePostItem(postItem);
            return Ok();
        }

        [HttpGet("/{id}/comments")]
        public async Task<IActionResult> GetComments(int id)
        {
            var comments = await this.postItemService.GetCommentsByPostItemId(id);
            return Ok(comments);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsItems()
        {
            var postItem = await this.postItemService.GetAllPostsItems();
            return Ok(postItem);
        }
    }
}
