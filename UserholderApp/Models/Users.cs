using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace UserholderApp.Models
{

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }//adding password
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<Posts> Posts { get; set; }

    }
}

