using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.ItemLines
{
    public interface IItemLineService
    {
        IEnumerable<ItemLine> GetAllItemLines();
        ItemLine? GetItemLineById(int id);
        void AddItemLine(ItemLine itemLine);
        void UpdateItemLine(int id, ItemLine itemLine);
        void DeleteItemLine(int id);
    }

    public class ItemLineService : IItemLineService
    {
        private readonly CargoHubDbContext _dbContext;
        public ItemLineService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ItemLine> GetAllItemLines()
        {
            if (_dbContext.ItemLines != null)
            {
                return _dbContext.ItemLines.ToList();
            }
            return new List<ItemLine>();
        }

        public void AddItemLine(ItemLine itemLine)
        {
            _dbContext.ItemLines?.Add(itemLine);
            _dbContext.SaveChanges();
        }

        public void UpdateItemLine(int id, ItemLine itemLine)
        {
            _dbContext.ItemLines?.Update(itemLine);
            _dbContext.SaveChanges();
        }

        public void DeleteItemLine(int id)
        {
            var itemLine = _dbContext.Inventories?.FirstOrDefault(c => c.Id == id);
            if (itemLine != null)
            {
                _dbContext.Inventories?.Remove(itemLine);
                _dbContext.SaveChanges();
            }
        }

        public ItemLine? GetItemLineById(int id)
        {
            return _dbContext.ItemLines?.Find(id);
        }
    }
}
