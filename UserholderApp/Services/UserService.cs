using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;
using UserholderApp.Dto;
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

        public async Task<bool> CreateUsers(UsersDto users)
        {
            var newUser = new Users
            {
                Name = users.Name,
                Email = users.Email,
                Phone = users.Phone,
                Website = users.Website
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUsers(Users users)
        {
            var userPosts = _context.Posts.Where(p => p.UsersId == users.Id);


            _context.Posts.RemoveRange(userPosts); // Remove all posts associated with the user
            _context.Users.Remove(users); // Remove the user itself

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Users>> GetUsers()
        {
            return await _context.Users.OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<bool>UpdateUsers(Users users)
        {
            _context.Update(users);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
