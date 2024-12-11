using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Shipments
{
    public interface IShipmentService
    {
        IEnumerable<Shipment> GetAllShipments();
        Shipment? GetShipmentById(int id);
        void AddShipment(Shipment shipment);
        void UpdateShipment(Shipment shipment);
        void DeleteShipment(int id);
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
        public void AddShipment(Shipment shipment)
        {
            _shipments.Add(shipment);
        }
        public void UpdateShipment(Shipment shipment)
        {
            var existingShipment = _shipments.FirstOrDefault(s => s.Id == shipment.Id);
            if (existingShipment == null)
            {
                return;
            }

            existingShipment.Id = shipment.Id;
            existingShipment.OrderId = shipment.OrderId;
            existingShipment.SourceId = shipment.SourceId;
            existingShipment.OrderDate = shipment.OrderDate;
            existingShipment.RequestDate = shipment.RequestDate;
            existingShipment.ShipmentDate = shipment.ShipmentDate;
            existingShipment.ShipmentType = shipment.ShipmentType;
            existingShipment.ShipmentStatus = shipment.ShipmentStatus;
            existingShipment.Notes = shipment.Notes;
            existingShipment.CarrierCode = shipment.CarrierCode;
            existingShipment.CarrierDescription = shipment.CarrierDescription;
            existingShipment.ServiceCode = shipment.ServiceCode;
            existingShipment.PaymentType = shipment.PaymentType;
            existingShipment.TransferMode = shipment.TransferMode;
            existingShipment.TotalPackageCount = shipment.TotalPackageCount;
            existingShipment.TotalPackageWeight = shipment.TotalPackageWeight;
            existingShipment.Items = shipment.Items;

        }
        public void DeleteShipment(int id)
        {
            var shipment = _shipments.FirstOrDefault(s => s.Id == id);
            if (shipment == null)
            {
                return;
            }

            _shipments.Remove(shipment);
        }
    }
}
