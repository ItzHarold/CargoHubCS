﻿using System.Collections.Generic;
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

        }

        public void UpdateLocation(Location location)
        {

        }
        public void DeleteLocation(int id)
        {

        }
        public Location? GetLocationById(int id)
        {
            return null;
        }

    }

}
