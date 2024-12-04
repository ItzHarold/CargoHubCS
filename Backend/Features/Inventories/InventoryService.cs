using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Inventories
{
    public interface IInventoryService
    {
        IEnumerable<Inventory> GetAllInventories();
        Inventory? GetInventoryById(int id);
        // void AddInventory(Inventory inventory);
        // void UpdateInventory(Inventory inventory);
        // void DeleteInventory(int id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly List<Inventory> _inventories = new();

        public IEnumerable<Inventory> GetAllInventories()
        {
            return _inventories;
        }
        public Inventory? GetInventoryById(int id)
        {
            return _inventories.FirstOrDefault(c => c.Id == id);
        }
    }
}
