using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Shipments
{
    public interface IShipmentService
    {
        IEnumerable<Shipment> GetAllShipments();
        Shipment? GetShipmentById(int id);
        // void AddShipment(Shipment shipment);
        // void UpdateShipment(Shipment shipment);
        // void DeleteShipment(int id);
    }

    public class ShipmentService: IShipmentService
    {
        private readonly List<Shipment> _shipments = new();

        public IEnumerable<Shipment> GetAllShipments()
        {
            return _shipments;
        }
        public Shipment? GetShipmentById(int id)
        {
            return _shipments.FirstOrDefault(s => s.Id == id);
        }
    }
}
