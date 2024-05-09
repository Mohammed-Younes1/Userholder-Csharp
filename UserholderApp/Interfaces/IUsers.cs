using UserholderApp.Dto;
using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IUsers
    {   
        Task <ICollection<UsersDto>> GetUsers();
        Task<Users> GetUserById(int id);
        Task<bool> CreateUsers(UsersDto users);
        //Task<bool> LoginUsers(userLoginDto users);
        Task<string> LoginUsers(userLoginDto users);
        Task<bool> UpdateUsers(Users users);
        Task<bool> DeleteUsers(Users users);
        public string CreateToken(userLoginDto users);
        bool  UserExists(int id);
        bool Save();

    }
}
