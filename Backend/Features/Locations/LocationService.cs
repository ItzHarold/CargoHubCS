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

    public class LocationService
    {

    }
}
