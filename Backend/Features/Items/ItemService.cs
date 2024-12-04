using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.Items
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        // Item? GetItemById(int id);
        void AddItem(Item item);
        // void UpdateItem(Item item);
        // void DeleteItem(int id);
    }

    public class ItemService : IItemService
    {
        private readonly CargoHubDbContext _context;

        public ItemService(CargoHubDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetAllItems() => _context.Items.ToList();

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}
