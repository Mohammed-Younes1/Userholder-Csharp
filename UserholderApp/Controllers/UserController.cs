using Microsoft.AspNetCore.Mvc;
using UserholderApp.Dto;
using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUsers _users;

        public UserController(IUsers users )
        {
            _users = users;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
        public IActionResult GetUsers()
        {
            var users= _users.GetUsers();

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        public IActionResult GetUserById(int userId)
        {
            if (!_users.UserExists(userId))
                return NotFound();

            var user = _users.GetUserById(userId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(user);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateUsers([FromBody] UsersDto userCreate ) 
        {
           
            if(userCreate == null)
            {
                return BadRequest(ModelState);
            }
            //checking if user already exists
            var user=_users.GetUsers().Where(u => u.Email == userCreate.Email).FirstOrDefault();

            if(user !=null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }
            var isAdded = await _users.CreateUsers(userCreate);
            return Ok("Successfully created");

        }

    }
}
