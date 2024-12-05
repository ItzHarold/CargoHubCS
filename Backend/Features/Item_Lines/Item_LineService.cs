using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemLines
{
    public interface IItemLineService
    {
        IEnumerable<ItemLine> GetAllItemLines();
        ItemLine? GetItemLineById(string  uid);
        void AddItemLine(ItemLine itemLine);
        void UpdateItemLine(string uid, ItemLine itemLine);
        void DeleteItemLine(string uid);
    }

    public class ItemLineService : IItemLineService
    {
        public List<ItemLine> Context { get; set; } = [];

        public IEnumerable<ItemLine> GetAllItemLines()
        {
            return Context;
        }

        public void AddItemLine(ItemLine itemLine)
        {
            Context.Add(itemLine);
        }

        public void UpdateItemLine(string uid, ItemLine itemLine)
        {
            int index = Context.FindIndex(x => x.uid == uid);
            Context[index] = itemLine;
        }

        public void DeleteItemLine(string uid)
        {
            int index = Context.FindIndex(x => x.uid == uid);
            Context.RemoveAt(index);
        }

        public ItemLine? GetItemLineById(string uid)
        {
            return Context.FirstOrDefault(x => x.uid == uid);
        }
    }
}
