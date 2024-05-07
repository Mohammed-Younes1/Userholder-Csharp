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
        public async Task<IActionResult> GetUsers()
        {
            var users= await _users.GetUsers();

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        public async Task<IActionResult> GetUserById(int userId)
        {
            if (!_users.UserExists(userId))
                return NotFound();

            var user = await _users.GetUserById(userId);

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
            var users = await _users.GetUsers();
            var user = users.FirstOrDefault(u => u.Email == userCreate.Email);

            if (user !=null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }
            var isAdded = await _users.CreateUsers(userCreate);
            return Ok("Successfully created");

        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUsers(int userId, [FromBody] UsersDto updateUser)
        {
            if (updateUser == null)
                return BadRequest(ModelState);

            //if (userId != updateUser.Id)
            //    return BadRequest(ModelState);

            //if (!userId.UserExists(userId))
            //    return NotFound();

            var findUser = await _users.GetUserById(userId);
            var updatedUser = await _users.UpdateUsers(findUser);

            return Ok("Successfully Updated");
        }


        [HttpDelete("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteUsers(int userId)
        {
            if (!_users.UserExists(userId))
                return NotFound();

            var findUser = await _users.GetUserById(userId);

            var deletePost = await _users.DeleteUsers(findUser);

            return Ok("Successfully Delete");
        }

    }
}
