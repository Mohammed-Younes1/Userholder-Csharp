using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Models
{
    public class Geo
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Address Address { get; set; }

        public void SetLatitudeAndLongitude(float latitude, float longitude)
        {
            Latitude = Convert.ToDecimal(latitude);
            Longitude = Convert.ToDecimal(longitude);
        }
    }
}
