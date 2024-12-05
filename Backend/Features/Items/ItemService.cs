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
        public List<Item> Context { get; set; } = [];

        public IEnumerable<Item> GetAllItems() => Context;

        public void AddItem(Item item)
        {
            Context.Add(item);
        }
    }
}
