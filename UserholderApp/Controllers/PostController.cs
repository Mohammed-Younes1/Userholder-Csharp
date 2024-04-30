using Microsoft.AspNetCore.Mvc;
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
    }
}
