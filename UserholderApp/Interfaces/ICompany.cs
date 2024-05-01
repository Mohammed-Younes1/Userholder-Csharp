using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface ICompany
    {
        ICollection<Company> GetCompanies();
        Company GetCompanyById(int id);
        bool CreateCompany (Company company);
        bool UpdateCompany (Company company);
        bool DeleteAddress(Address address);
        bool CompanyExists(int id);
        bool Save();

    }
}
