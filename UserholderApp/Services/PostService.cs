using Microsoft.Extensions.Hosting;
using UserholderApp.Dto;
using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Services
{
    public class PostService : IPosts
    {
        private readonly UserholderDbContext _context;

        public PostService(UserholderDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePost(PostsDto posts ,int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }
            var newPost = new Posts
            {

                Title = posts.Title,
                Body = posts.Body,
                UsersId = userId
            };

            await _context.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(Posts posts)
        {
            _context.Remove(posts);
            await _context.SaveChangesAsync();
            return true;
        }

        public Posts GetPostById(int id)
        {
            return _context.Posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Posts> GetPosts()
        {
           return _context.Posts.OrderBy(p => p.Id).ToList();
        }

        async Task<ICollection<Posts>> IPosts.GetPostsByUserId(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            return _context.Posts.Where(u=> u.Users.Id == userId).ToList();
        }

        public bool PostsExists(int id)
        {
            return _context.Posts.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdatePost(Posts posts)
        {
            _context.Update(posts);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
