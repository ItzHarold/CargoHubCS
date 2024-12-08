using System.Collections.Generic;
using Backend.Features.Shipments;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Shipments
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public IEnumerable<Shipment> GetAllShipments()
        {
            return _shipmentService.GetAllShipments();
        }
    }

}
