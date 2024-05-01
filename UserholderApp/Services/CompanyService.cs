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

        public bool CreateCompany(Company company)
        {
            _context.Add(company);
            return Save();
        }

        public bool DeleteAddress(Address address)
        {
            _context.Remove(address);
            return Save();
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Company.OrderBy(c => c.Id).ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Company.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCompany(Company company)
        {
            _context.Update(company);
            return Save();
        }
    }
}
