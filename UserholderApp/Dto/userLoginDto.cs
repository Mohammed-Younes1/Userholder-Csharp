using System.ComponentModel.DataAnnotations;

namespace UserholderApp.Dto
{
    public class userLoginDto
    {

        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
