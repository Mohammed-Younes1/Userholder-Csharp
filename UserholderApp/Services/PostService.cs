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

        public Posts GetPostById(int id)
        {
            return _context.Posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Posts> GetPosts()
        {
           return _context.Posts.OrderBy(p => p.Id).ToList();
        }

        public bool PostsExists(int id)
        {
            return _context.Posts.Any(p => p.Id == id);
        }
    }
}
