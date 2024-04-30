using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IPosts
    {
        ICollection<Posts> GetPosts();
        Posts GetPostById(int id);
        bool PostsExists(int id);
    }
}
