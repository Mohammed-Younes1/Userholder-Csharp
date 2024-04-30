using System.Linq;
using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Services
{
    public class UserService : IUsers
    {
        private readonly UserholderDbContext _context;

        public UserService(UserholderDbContext context)
        {
            _context = context;
        }

        public Users GetUserById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<Users> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
