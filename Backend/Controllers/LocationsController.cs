using System.Collections.Generic;
using Backend.Features.Locations;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Locations
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IEnumerable<Location> GetAllLocations()
        {
            return _locationService.GetAllLocations();
        }

        [HttpGet("{id}")]
        public Location? GetLocationById(int id)
        {
            return _locationService.GetLocationById(id);
        }

        [HttpPut]
        public void UpdateLocation([FromBody] Location location)
        {
            _locationService.UpdateLocation(location);
        }

        [HttpPost]
        public void AddLocation([FromBody] Location location)
        {
            _locationService.AddLocation(location);
        }

        [HttpDelete("{id}")]
        public void DeleteLocation(int id)
        {
            _locationService.DeleteLocation(id);
        }
    }
}
