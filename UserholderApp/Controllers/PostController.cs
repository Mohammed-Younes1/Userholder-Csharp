﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserholderApp.Dto;
using UserholderApp.Interfaces;
using UserholderApp.Models;
using UserholderApp.Services;

namespace UserholderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPosts _posts;

        public PostController(IPosts posts)
        {
            _posts = posts;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Posts>))]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _posts.GetPosts();

            if (!ModelState.IsValid)
                return BadRequest();
                
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task <IActionResult> GetPostById(int postId)
        {
            if (!_posts.PostsExists(postId))
            {
                return NotFound();
            }

            var post = await _posts.GetPostById(postId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(post);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreatePost([FromBody] PostsDto postCreate, [FromQuery] int userId)
        {

            if (postCreate == null)
            {
                return BadRequest(ModelState);
            }

            // Check if the post with the given ID already exists
            var post = _posts.PostsExists(postCreate.Id);
            if (post)
            {
                ModelState.AddModelError("", "Post already exists");
                return StatusCode(422, ModelState);
            }

            // Call the CreatePost method in the service, passing both the post and user ID
            var isAdded = await _posts.CreatePost(postCreate, userId);
            return Ok("Successfully created");
        }



        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] PostsDto updatePosts)
        {
            if (updatePosts == null)
                return BadRequest(ModelState);

            if (postId != updatePosts.Id)
                return BadRequest(ModelState);

            if (!_posts.PostsExists(postId))
                return NotFound();

            var isUpdated = await _posts.UpdatePost(updatePosts);
            if (!isUpdated)
                return StatusCode(500); // or any appropriate error response

            return NoContent(); // 204 No Content response
        }



        [HttpDelete("{postId}")]
        public async Task<ActionResult>DeletePost(int postId)
        {
            if(!_posts.PostsExists(postId))
                return NotFound();

            var findPost= await _posts.GetPostById(postId);

            var deletePost = await _posts.DeletePost(findPost);

            return Ok("Successfully Delete");
        }


        //[HttpGet("user/{userId}/posts")]
        [HttpGet("{userId}/posts")]

        public async Task<IActionResult> GetPostsByUserId(int userId)
        {
            var posts = await _posts.GetPostsByUserId(userId);

            if (posts == null)
            {
                return NotFound(); 
            }

            return Ok(posts); // Return the posts associated with the user
        }

        [HttpDelete("{userId}/posts/{postId}")]
        public async Task<IActionResult> DeleteOnePostByOwner(int userId, int postId)
        {
            var isDeleted = await _posts.DeleteOnePostByOwner(userId, postId);
            return Ok("Successfully Delete");
        }
    }
}
