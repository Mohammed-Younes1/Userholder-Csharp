using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IPosts
    {
        ICollection<Posts> GetPosts();
        Posts GetPostById(int id);
        bool CreatePost(Posts posts);
        bool UpdatePost(Posts posts);
        bool DeletePost(Posts posts);
        bool PostsExists(int id);
        bool Save();

    }
}
