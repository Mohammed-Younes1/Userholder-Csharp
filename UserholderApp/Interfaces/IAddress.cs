using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IAddress
    {
        ICollection<Address> GetAddresses();
        Address GetAddressById(int id);

        bool CreateAddress(Address address);
        bool UpdateAddress(Address address);
        bool DeleteAddress(Address address);
        bool AddressExists(int id);
        bool Save();

    }
}
