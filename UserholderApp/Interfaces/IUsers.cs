using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IUsers
    {   
        ICollection<Users> GetUsers();
        Users GetUserById(int id);
        bool  UserExists(int id);
    }
}
