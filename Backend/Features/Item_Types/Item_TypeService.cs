using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemTypes
{
    public interface IItemTypeService
    {
        IEnumerable<ItemType> GetAllItemTypes();
        //ItemType? GetItemTypeById(int id);
        void AddItemType(ItemType itemType);
        //void UpdateItemType(ItemType itemType);
        void DeleteItemType(int id);
    }

    public class ItemTypeService : IItemTypeService
    {
        public List<ItemType> Context { get; set; } = [];

        public IEnumerable<ItemType> GetAllItemTypes()
        {
            return Context;
        }

        public void AddItemType(ItemType itemType)
        {
            Context.Add(itemType);
        }

        public void DeleteItemType(int id)
        {
            int index = Context.FindIndex(i => i.Id == id);
            if (index >= 0)
            {
                Context.RemoveAt(index);
            }
        }
    }
}
