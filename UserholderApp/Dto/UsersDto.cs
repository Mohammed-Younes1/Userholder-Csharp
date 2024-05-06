using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Dto
{
    public class UsersDto
    {
        internal string CompanyName;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }


    }
}
