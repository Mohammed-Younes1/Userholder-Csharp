using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Services
{
    public class AddressService : IAddress
    {
        private readonly UserholderDbContext _context;

        public AddressService(UserholderDbContext context) 
        {
            _context = context;
        }

        public bool AddressExists(int id)
        {
            return _context.Address.Any(a => a.Id == id); 
        }

        public bool CreateAddress(Address address)
        {
            _context.Add(address);
            return Save();
        }

        public bool DeleteAddress(Address address)
        {
            _context.Remove(address);
            return Save();
        }

        public Address GetAddressById(int id)
        {
            return _context.Address.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Address> GetAddresses()
        {
            return _context.Address.OrderBy(a => a.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAddress(Address address)
        {
            _context.Update(address);
            return Save();
        }
    }
}
