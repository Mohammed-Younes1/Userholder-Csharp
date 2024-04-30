using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IAddress
    {
        ICollection<Address> GetAddresses();
        Address GetAddressById(int id);
        bool AddressExists(int id);

    }
}
