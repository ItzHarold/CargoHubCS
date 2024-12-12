using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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
        private readonly CargoHubDbContext _dbContext;

        public ShipmentService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Shipment> GetAllShipments()
        {
            if (_dbContext.Shipments != null)
            {
                return _dbContext.Shipments.ToList();
            }
            return new List<Shipment>();
        }
        public Shipment? GetShipmentById(int id)
        {
            return _dbContext.Shipments?.FirstOrDefault(s => s.Id == id);
        }
        public void AddShipment(Shipment shipment)
        {
            _dbContext.Shipments?.Add(shipment);
            _dbContext.SaveChanges();
        }
        public void UpdateShipment(Shipment shipment)
        {
            if (_dbContext.Shipments != null)
            {
                var existingShipment = _dbContext.Shipments
                    .FirstOrDefault(s => s.Id == shipment.Id);

                if (existingShipment != null)
                {
                    // Update shipment properties
                    _dbContext.Entry(existingShipment).CurrentValues.SetValues(shipment);

                    // Validate and add new items
                    foreach (var itemUuid in shipment.Items)
                    {
                        var existingItem = _dbContext.Items?.FirstOrDefault(i => i.Uid == itemUuid);
                        if (existingItem == null)
                        {
                            throw new InvalidOperationException($"Item with UUID {itemUuid} does not exist.");
                        }
                        if (!existingShipment.Items.Contains(itemUuid))
                        {
                            existingShipment.Items.Add(itemUuid);
                        }
                    }

                    // Remove items that are no longer in the shipment
                    var itemsToRemove = existingShipment.Items.Where(i => !shipment.Items.Contains(i)).ToList();
                    foreach (var itemToRemove in itemsToRemove)
                    {
                        existingShipment.Items.Remove(itemToRemove);
                    }

                    _dbContext.SaveChanges();
                }
            }
        }
        public void DeleteShipment(int id)
        {
            if (_dbContext.Shipments != null)
            {
                var shipment = _dbContext.Shipments
                    .FirstOrDefault(s => s.Id == id);

                if (shipment != null)
                {
                    _dbContext.Shipments?.Remove(shipment);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
