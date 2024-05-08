using UserholderApp.Dto;
using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface ICompany
    {
        ICollection<Company> GetCompanies();
        Company GetCompanyById(int id);
        Task<bool> CreateCompany(CompanyDto companyDto, int userId);

        bool UpdateCompany (Company company);
        bool DeleteAddress(Address address);
        bool CompanyExists(int id);

        bool Save();

    }
}
