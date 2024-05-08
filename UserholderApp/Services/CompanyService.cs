using UserholderApp.Dto;
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


        public async Task<bool> CreateCompany(CompanyDto company, int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            var newCompany = new Company
            {
                Name = company.Name,
                CatchPhrase = company.CatchPhrase,
                Bs = company.Bs,
                //UsersId = userId
            };
            await _context.AddAsync(newCompany);
            await _context.SaveChangesAsync();
            return true;
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
