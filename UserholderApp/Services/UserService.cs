﻿using System.Linq;
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
            _context.Remove(users);
            return Save();
        }

        public Users GetUserById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<Users> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public async Task<bool>UpdateUsers(Users users)
        {
            _context.Update(users);
            return Save();
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