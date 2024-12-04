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
        public IActionResult GetAllClients()
        {
            var locations = _locationService.GetAllLocations();
            return Ok(locations);
        }
    }
}
