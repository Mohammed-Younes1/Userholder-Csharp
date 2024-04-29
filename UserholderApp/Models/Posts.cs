namespace UserholderApp.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int UserId { get; set; } //FK posts
        public string Title { get; set; }
        public string Body { get; set; }
        public Users Users { get; set; }

    }
    }
