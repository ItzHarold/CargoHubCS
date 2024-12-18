using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.ItemTypes
{
    public interface IItemTypeService
    {
        IEnumerable<ItemType> GetAllItemTypes();
        ItemType? GetItemTypeById(int id);
        void AddItemType(ItemType itemType);
        void UpdateItemType(int id, ItemType itemType);
        void DeleteItemType(int id);
    }

    public class ItemTypeService : IItemTypeService
    {
        private readonly CargoHubDbContext _dbContext;
        public ItemTypeService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ItemType> GetAllItemTypes()
        {
            if (_dbContext.ItemTypes != null)
            {
                return _dbContext.ItemTypes.ToList();
            }
            return new List<ItemType>();
        }

        public ItemType? GetItemTypeById(int id)
        {
            return _dbContext.ItemTypes?.Find(id);
        }

        public void AddItemType(ItemType itemType)
        {
            itemType.CreatedAt = DateTime.Now;
            _dbContext.ItemTypes?.Add(itemType);
            _dbContext.SaveChanges();
        }

        public void UpdateItemType(int id, ItemType itemType)
        {
            itemType.UpdatedAt = DateTime.Now;
            _dbContext.ItemTypes?.Update(itemType);
            _dbContext.SaveChanges();
        }

        public void DeleteItemType(int id)
        {
            var itemType = _dbContext.ItemTypes?.FirstOrDefault(c => c.Id == id);
            if (itemType != null)
            {
                _dbContext.ItemTypes?.Remove(itemType);
                _dbContext.SaveChanges();
            }
        }
    }
}
