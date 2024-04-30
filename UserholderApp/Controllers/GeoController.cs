using Microsoft.AspNetCore.Mvc;
using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : Controller
    {
        private readonly IGeo _geo;

        public GeoController(IGeo geo)
        {
            _geo = geo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Geo>))]
        public IActionResult GetGeos()
        {
            var geos = _geo.GetGeos();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(geos);
        }

        [HttpGet("{geoId}")]
        [ProducesResponseType(200, Type = typeof(Geo))]
        public IActionResult GetGeoById(int geoId)
        {
            if (!_geo.GeoExists(geoId))
            {
                return NotFound();
            }

            var geo = _geo.GetGeoById(geoId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(geo);

        }
    }
}
