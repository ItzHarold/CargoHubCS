using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.Items
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        Item? GetItemById(string uid);
        void AddItem(Item item);
        // void UpdateItem(Item item);
        void DeleteItem(string uid);
    }

    public class ItemService : IItemService
    {
        public List<Item> Context { get; set; } = [];

        public IEnumerable<Item> GetAllItems() => Context;

        public Item? GetItemById(string uid)
        {
            return Context.FirstOrDefault(item => item.Uid == uid);
        }

        public void AddItem(Item item)
        {
            Context.Add(item);
        }

        public void DeleteItem(string uid)
        {
            foreach (var item in Context.Where(item => item.Uid == uid))
            {
                Context.Remove(item);
                break;
            }
        }
    }
}
