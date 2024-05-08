using Microsoft.AspNetCore.Mvc;
using UserholderApp.Models;

namespace UserholderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public Users users= new Users();


    }
}
