namespace UserholderApp.Models
{
    public class Geo
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Address Address { get; set; }
    }
}
