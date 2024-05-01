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
        public IActionResult GetPosts()
        {
            var posts = _posts.GetPosts();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(Posts))]
        public IActionResult GetPostById(int postId)
        {
            if (!_posts.PostsExists(postId))
            {
                return NotFound();
            }

            var post = _posts.GetPostById(postId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(post);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePosts([FromBody] PostsDto postCreate)
        {

            if (postCreate == null)
            {
                return BadRequest(ModelState);
            }

            //checking if user already exists
            var post = _posts.GetPosts().Where(u => u.Id == postCreate.Id).FirstOrDefault();

            if (post != null)
            {
                ModelState.AddModelError("", "Post already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newPosts = new Posts
            {
                //Id = postCreate.Id,
                Title = postCreate.Title,
                Body = postCreate.Body,
               
            };
            if (!_posts.CreatePost(newPosts))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpPut("{postId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePost(int postId, [FromBody] PostsDto updatePosts)
        {
            if (updatePosts == null)
                return BadRequest(ModelState);

            if (postId != updatePosts.Id)
                return BadRequest(ModelState);

            if (!_posts.PostsExists(postId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            var newPosts = new Posts
            {
                //Id = postCreate.Id,
                Title = updatePosts.Title,
                Body = updatePosts.Body,

            };

            if (!_posts.UpdatePost(newPosts))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
