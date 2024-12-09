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

        [HttpGet("{id}")]
        public Shipment? GetShipmentById(int id)
        {
            return _shipmentService.GetShipmentById(id);
        }

        [HttpPost]
        public void AddShipment([FromBody] Shipment shipment)
        {
            _shipmentService.AddShipment(shipment);
        }
        [HttpPut]
        public void UpdateShipment([FromBody] Shipment shipment)
        {
            _shipmentService.UpdateShipment(shipment);
        }
        [HttpDelete("{id}")]
        public void DeleteShipment(int id)
        {
            _shipmentService.DeleteShipment(id);
        }
    }

}
