using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace UserholderApp.Models
{
    [Table("posts")]

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Column("address_id")] // Specify the column name in the database
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }

        [Column("company_id")] // Specify the column name in the database
        public int? CompanyId { get; set; }

        public Company? Company { get; set; }
        public ICollection<Posts> Posts { get; set; }

    }
}

