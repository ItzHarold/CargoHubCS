using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Items
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        Item? GetItemById(int id);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }

    public class ItemService
    {

    }
}
