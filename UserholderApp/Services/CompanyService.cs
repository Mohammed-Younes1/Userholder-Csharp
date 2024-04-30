using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Services
{
    public class CompanyService : ICompany
    {
        private readonly UserholderDbContext _context;

        public CompanyService(UserholderDbContext context)
        {
            _context = context;
        }

        public bool CompanyExists(int id)
        {
            return _context.Company.Any(c => c.Id == id);
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Company.OrderBy(c => c.Id).ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Company.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
