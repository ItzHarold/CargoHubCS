using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemLines
{
    public interface IItemLineService
    {
        IEnumerable<ItemLine> GetAllItemLines();
        ItemLine? GetItemLineById(int id);
        void AddItemLine(ItemLine itemLine);
        void UpdateItemLine(ItemLine itemLine);
        void DeleteItemLine(int id);
    }

    public class ItemLineService
    {

    }
}
