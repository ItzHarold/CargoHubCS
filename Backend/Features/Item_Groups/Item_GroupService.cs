using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemGroups
{
    public interface IItemGroupService
    {
        IEnumerable<ItemGroup> GetAllItemGroups();
        ItemGroup? GetItemGroupById(int id);
        void AddItemGroup(ItemGroup itemGroup);
        void UpdateItemGroup(ItemGroup itemGroup);
        void DeleteItemGroup(int id);
    }

    public class ItemGroupService
    {

    }
}
