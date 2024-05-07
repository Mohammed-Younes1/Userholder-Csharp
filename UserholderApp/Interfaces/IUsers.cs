﻿using UserholderApp.Dto;
using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IUsers
    {   
        Task <ICollection<Users>> GetUsers();
        Task<Users> GetUserById(int id);
        Task<bool> CreateUsers(UsersDto users);
        Task<bool> UpdateUsers(Users users);
        Task<bool> DeleteUsers(Users users);
        bool  UserExists(int id);
        bool Save();

    }
}
