using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemGroups
{
    public interface IItemGroupService
    {
        IEnumerable<ItemGroup> GetAllItemGroups();
        ItemGroup? GetItemGroupById(int id);
        // void AddItemGroup(ItemGroup itemGroup);
        // void UpdateItemGroup(ItemGroup itemGroup);
        // void DeleteItemGroup(int id);
    }

    public class ItemGroupService : IItemGroupService
    {
        private readonly List<ItemGroup> _itemGroups = new();

        public IEnumerable<ItemGroup> GetAllItemGroups()
        {
            return _itemGroups;
        }

        public ItemGroup? GetItemGroupById(int id)
        {
            return _itemGroups.FirstOrDefault(c => c.Id == id);
        }



    }
}
