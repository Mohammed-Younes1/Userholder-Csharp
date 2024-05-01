using System.ComponentModel.DataAnnotations.Schema;

namespace UserholderApp.Dto
{
    public class GeoDto
    {
        public int Id { get; set; }
        [Column("Lat")]
        public decimal Latitude { get; set; }
        [Column("Lng")]
        public decimal Longitude { get; set; }

        public void SetLatitudeAndLongitude(float latitude, float longitude)
        {
            Latitude = Convert.ToDecimal(latitude);
            Longitude = Convert.ToDecimal(longitude);
        }
    }
}
