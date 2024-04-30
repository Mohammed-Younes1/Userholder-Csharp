using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IGeo
    {
        ICollection<Geo> GetGeos();
        Geo GetGeoById(int Id);
        bool GeoExists(int Id);
    }
}
