using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IUsers
    {   
        ICollection<Users> GetUsers();
        

        //bool public UserExists();
    }
}
