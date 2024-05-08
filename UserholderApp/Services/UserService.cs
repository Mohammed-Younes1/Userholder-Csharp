﻿using Microsoft.AspNetCore.Http.HttpResults;
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
            string passwordhash = BCrypt.Net.BCrypt.HashPassword(users.Password);
            var newUser = new Users
            {
                
                Name = users.Name,
                Email = users.Email,
                Password = passwordhash,  
                Phone = users.Phone,
                Website = users.Website
            };

            if(users.Email != null)
            {
                return false;
            }
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUsers(Users users)
        {
            if (!_context.Users.Any(u => u.Id == users.Id))
            {
                return false; // User does not exist
            }
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

        public async Task<ICollection<UsersDto>> GetUsers()
        {
            var users = await _context.Users.OrderBy(u => u.Id).ToListAsync();
            var usersDto = users.Select(u => new UsersDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Phone = u.Phone,
                Website = u.Website
            }).ToList();

            return usersDto;
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

        public async Task<bool> LoginUsers(userLoginDto users)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == users.Email);
            if (user == null)
            {
                // User with the provided email does not exist
                return false;
            }
            //if (!BCrypt.Net.BCrypt.Verify(users.Password, user.Password))
            //{
            //    return false;
            //}
            return true;
        }
    }
}
