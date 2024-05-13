using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Dto
{
    public class UsersDto
    {
        //internal string CompanyName;
        public int Id { get; set; }

        public string? Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }


    }
}
