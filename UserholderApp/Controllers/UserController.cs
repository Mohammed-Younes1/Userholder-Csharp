using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public async Task<IActionResult> GetUsers()
        {
            var users= await _users.GetUsers();

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(users);
        }

        [HttpGet("{userId}") ,Authorize]
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
        [AllowAnonymous]
        public async Task<ActionResult> CreateUsers([FromBody] UsersDto userCreate ) 
        {
           //string passwordhash=BCrypt.Net.BCrypt.HashPassword(userCreate.Password);

            if(userCreate == null)
            {
                return BadRequest(ModelState);
            }
            //checking if user already exists
            var users = await _users.GetUsers();
            var user = users.FirstOrDefault(u => u.Email == userCreate.Email);

            if (user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }
            await _users.CreateUsers(userCreate);
            return Ok("Successfully created");

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginUsers([FromBody] userLoginDto loginUser)
        {

            if (loginUser == null)
            {
                return BadRequest(ModelState);
            }
            //checking if user already exists
            var gettingUsers = await _users.GetUsers();
            var user = gettingUsers.FirstOrDefault(u => u.Email == loginUser.Email);
            //var user = gettingUsers.FirstOrDefault(u => u.Id == loginUser.Id);


            if (user == null)
            {
                ModelState.AddModelError("", "User Not found ");
                return StatusCode(422, ModelState);
            }

            if (!BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
            {
                // Password doesn't match
                return BadRequest(" wrong password");
            }
            var token = await _users.LoginUsers(loginUser);


            return Ok(new { message = "Successfully Logged in", token });

        }


        [HttpPut("{userId}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateUsers(int userId, [FromBody] UsersDto updateUser)
        {
            var tokenUserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (tokenUserId == null || userId != int.Parse(tokenUserId))
            {
                // Unauthorized to update user with different ID
                return Unauthorized();
            }

            var findUser = await _users.GetUserById(userId);
            var updatedUser = await _users.UpdateUsers(findUser);

            return Ok("Successfully Updated");
        }


        [HttpDelete("{userId}"), Authorize]
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
