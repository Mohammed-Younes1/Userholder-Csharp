using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        [Column("user_id")]
        public int UsersId { get; set; } // Foreign Key
        public Users Users { get; set; }

    }
    }
