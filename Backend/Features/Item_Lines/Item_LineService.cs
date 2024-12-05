﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.ItemLines
{
    public interface IItemLineService
    {
        IEnumerable<ItemLine> GetAllItemLines();
        ItemLine? GetItemLineById(string  uid);
        void AddItemLine(ItemLine itemLine);
        //void UpdateItemLine(ItemLine itemLine);
        //void DeleteItemLine(int id);
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

        public ItemLine? GetItemLineById(string uid)
        {
            return Context.FirstOrDefault(x => x.uid == uid);
        }
    }
}
