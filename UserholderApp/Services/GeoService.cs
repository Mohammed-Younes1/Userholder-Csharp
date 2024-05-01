using UserholderApp.Interfaces;
using UserholderApp.Models;

namespace UserholderApp.Services
{
    public class GeoService : IGeo
    {
        private readonly UserholderDbContext _context;

        public GeoService(UserholderDbContext context)
        {
            _context = context;
        }

        public bool CreateGeo(Geo geo)
        {
            _context.Add(geo);
            return Save();
        }

        public bool DeleteGeo(Geo geo)
        {
            _context.Remove(geo);
            return Save();
        }

        public bool GeoExists(int id)
        {
            return _context.Geo.Any(g => g.Id == id);
        }

        public Geo GetGeoById(int id)
        {
            return _context.Geo.Where(g => g.Id == id).FirstOrDefault();
        }

        public ICollection<Geo> GetGeos()
        {
            return _context.Geo.OrderBy(g=>g.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGeo(Geo geo)
        {
            _context.Update(geo);
            return Save();
        }
    }
}
