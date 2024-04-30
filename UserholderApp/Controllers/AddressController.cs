using Microsoft.AspNetCore.Mvc;
using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddress _address;

        public AddressController(IAddress address)
        {
            _address = address;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
        public IActionResult GetAddress()
        {
            var address = _address.GetAddresses();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(address);
        }


        [HttpGet("{addressId}")]
        [ProducesResponseType(200, Type=typeof(Address))]
        public IActionResult GetAddressById(int addressId)
        {
            if(!_address.AddressExists(addressId))
            {
                return NotFound();
            }

            var address = _address.GetAddressById(addressId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(address);
        }
    }
}
