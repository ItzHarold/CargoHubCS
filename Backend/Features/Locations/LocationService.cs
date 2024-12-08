using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
        private readonly List<Location> _locations = new();
        public IEnumerable<Location> GetAllLocations()
        {
            return _locations;
        }
        public void AddLocation(Location location)
        {
            _locations.Add(location);
        }

        public void UpdateLocation(Location location)
        {
           var existingLocation = _locations.FirstOrDefault(l => l.Id == location.Id);
            if (existingLocation == null)
            {
                return;
            }

            existingLocation.Id = location.Id;
            existingLocation.WarehouseId = location.WarehouseId;
            existingLocation.Code = location.Code;
            existingLocation.Name = location.Name;
        }
        public void DeleteLocation(int id)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return;
            }

            _locations.Remove(location);
        }
        public Location? GetLocationById(int id)
        {
            return _locations.FirstOrDefault(l => l.Id == id);
        }

    }

}
