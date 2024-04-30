using Microsoft.AspNetCore.Mvc;
using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Company>))]
        public IActionResult GetCompanies()
        {
            var companies = _company.GetCompanies();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(companies);
        }

        [HttpGet("{companyId}")]
        [ProducesResponseType(200, Type =typeof(Company))]
        public IActionResult GetComapnyById(int companyId) 
        {
            if(!_company.CompanyExists(companyId))
            {
                return NotFound();
            }

            var company= _company.GetCompanyById(companyId);

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(company);

        }
    }
}
