using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemTypes
{
    public interface IItemTypeService
    {
        IEnumerable<ItemType> GetAllItemTypes();
        ItemType? GetItemTypeById(int id);
        void AddItemType(ItemType itemType);
        void UpdateItemType(ItemType itemType);
        void DeleteItemType(int id);
    }

    public class ItemTypeService
    {

    }
}
