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

        public bool CreatePost(Posts posts)
        {
            _context.Add(posts);
            return Save();
        }

        public bool DeletePost(Posts posts)
        {
            _context.Remove(posts);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePost(Posts posts)
        {
            _context.Update(posts);
            return Save();
        }
    }
}
