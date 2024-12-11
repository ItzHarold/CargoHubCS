using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

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

    public class ItemGroupService : IItemGroupService
    {
        private readonly CargoHubDbContext _dbContext;

        public ItemGroupService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ItemGroup> GetAllItemGroups()
        {
            if (_dbContext.ItemGroups != null)
            {
                return _dbContext.ItemGroups.ToList();
            }
            return new List<ItemGroup>();
        }

        public ItemGroup? GetItemGroupById(int id)
        {
            return _dbContext.ItemGroups?.Find(id);
        }

        public void AddItemGroup(ItemGroup itemGroup)
        {
            _dbContext.ItemGroups?.Add(itemGroup);
            _dbContext.SaveChanges();
        }

        public void UpdateItemGroup(ItemGroup itemGroup)
        {
            _dbContext.ItemGroups?.Update(itemGroup);
            _dbContext.SaveChanges();
        }

        public void DeleteItemGroup(int id)
        {
            var itemGroup = _dbContext.Inventories?.FirstOrDefault(c => c.Id == id);
            if (itemGroup != null)
            {
                _dbContext.Inventories?.Remove(itemGroup);
                _dbContext.SaveChanges();
            }
        }

    }
}
