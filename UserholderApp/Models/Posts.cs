using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int UsersId { get; set; } 
        public Users Users { get; set; }

    }
    }
