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
        void UpdateItem(string uid, Item item);
        void DeleteItem(string uid);
    }

    public class ItemService : IItemService
    {
        private readonly CargoHubDbContext _dbContext;
        public ItemService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Item> GetAllItems()
        {
            if (_dbContext.Items != null)
            {
                return _dbContext.Items.ToList();
            }
            return new List<Item>();
        }

        public Item? GetItemById(string uid)
        {
            return _dbContext.Items?.FirstOrDefault(i => i.Uid == uid);
        }

        public void AddItem(Item item)
        {
            _dbContext.Items?.Add(item);
            _dbContext.SaveChanges();
        }

        public void UpdateItem(string uid, Item item)
        {
            _dbContext.Items?.Update(item);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(string uid)
        {
            var item = _dbContext.Items?.FirstOrDefault(i => i.Uid == uid);
            if (item != null)
            {
                _dbContext.Items?.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
