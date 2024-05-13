using Microsoft.EntityFrameworkCore;
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

        public async Task<Posts> GetPostById(int id)
        {
            return await _context.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();

        }

        public async Task<ICollection<Posts>> GetPosts()
        {
           return await _context.Posts.OrderBy(p => p.Id).ToListAsync();
        }

        async Task<ICollection<object>> IPosts.GetPostsByUserId(int userId)
        {
            var posts = await _context.Posts
        .Where(p => p.UsersId == userId)
        .Select(p => new { p.Id, p.Title, p.Body })
        .ToListAsync();

            return posts.Cast<object>().ToList();
        }

        public bool PostsExists(int id)
        {
            return _context.Posts.Any(p => p.Id == id);
        }

        public async Task <bool> Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdatePost(PostsDto posts)
        {
            var existingPost = await _context.Posts.FindAsync(posts.Id);
            if (existingPost == null)
            {
                return false;
            }
            existingPost.Title = posts.Title;
            existingPost.Body = posts.Body;
            existingPost.UsersId = posts.UsersId; 

            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<bool> DeleteOnePostByOwner(int userId, int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return false; // Post not found
            }

            if(post.UsersId != userId) {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
