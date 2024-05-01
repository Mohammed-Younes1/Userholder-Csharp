using UserholderApp.Models;

namespace UserholderApp.Interfaces
{
    public interface IGeo
    {
        ICollection<Geo> GetGeos();
        Geo GetGeoById(int Id);
        bool CreateGeo(Geo geo);
        bool UpdateGeo(Geo geo);
        bool DeleteGeo(Geo geo);
        bool GeoExists(int Id);
        bool Save();

    }
}
