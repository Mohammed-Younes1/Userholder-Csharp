using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public int GeoId { get; set; } // Represents the ID of the associated Geo object
        public Geo Geo { get; set; } 
    }
}
