using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.Locations
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
        Location? GetLocationById(int id);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
    }

    public class LocationService : ILocationService
    {
        private readonly CargoHubDbContext _dbContext;
        public LocationService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Location> GetAllLocations()
        {
            if (_dbContext.Locations != null)
            {
                return _dbContext.Locations.ToList();
            }
            return new List<Location>();
        }
        public void AddLocation(Location location)
        {
            _dbContext.Locations?.Add(location);
            _dbContext.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _dbContext.Locations?.Update(location);
            _dbContext.SaveChanges();
        }
        public void DeleteLocation(int id)
        {
            var location = _dbContext.Locations?.FirstOrDefault(l => l.Id == id);
            if (location != null)
            {
                _dbContext.Locations?.Remove(location);
                _dbContext.SaveChanges();
            }
        }
        public Location? GetLocationById(int id)
        {
            return _dbContext.Locations?.FirstOrDefault(l => l.Id == id);
        }

    }

}
