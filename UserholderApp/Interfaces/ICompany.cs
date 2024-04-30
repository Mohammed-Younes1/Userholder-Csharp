using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface ICompany
    {
        ICollection<Company> GetCompanies();
        Company GetCompanyById(int id);
        bool CompanyExists(int id);
    }
}
