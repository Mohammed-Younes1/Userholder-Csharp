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
    }
}
