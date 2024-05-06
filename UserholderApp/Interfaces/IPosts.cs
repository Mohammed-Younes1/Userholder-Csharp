using UserholderApp.Dto;
using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IPosts
    {
        Task<ICollection<Posts>> GetPosts();
        Task<Posts> GetPostById(int id);
        //Task<bool> CreatePost(PostsDto posts);
        Task<bool> CreatePost(PostsDto postsDto, int userId);
        Task<bool> UpdatePost(PostsDto posts);
        Task<bool> DeletePost(Posts posts);
        Task<bool> DeleteOnePostByOwner(int userId, int postId);

        Task<ICollection<object>> GetPostsByUserId(int id);
        bool PostsExists(int id);
        Task<bool> Save();

    }
}
