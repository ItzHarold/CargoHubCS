using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.Inventories
{
    public interface IInventoryService
    {
        IEnumerable<Inventory> GetAllInventories();
        Inventory? GetInventoryById(int id);
        void AddInventory(Inventory inventory);
        void UpdateInventory(Inventory inventory);
        void DeleteInventory(int id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly CargoHubDbContext _dbContext;

        public InventoryService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Inventory> GetAllInventories()
        {
            if (_dbContext.Inventories != null)
            {
                return _dbContext.Inventories.ToList();
            }
            return new List<Inventory>();
        }
        public Inventory? GetInventoryById(int id)
        {
            return _dbContext.Inventories?.Find(id);
        }

        public void AddInventory(Inventory inventory)
        {
            _dbContext.Inventories?.Add(inventory);
            _dbContext.SaveChanges();
        }

        public void UpdateInventory(Inventory inventory)
        {
            _dbContext.Inventories?.Update(inventory);
            _dbContext.SaveChanges();
        }

        public void DeleteInventory(int id)
        {
            var inventory = _dbContext.Inventories?.FirstOrDefault(c => c.Id == id);
            if (inventory != null)
            {
                _dbContext.Inventories?.Remove(inventory);
                _dbContext.SaveChanges();
            }
        }
    }
}
