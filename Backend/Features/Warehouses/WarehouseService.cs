using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Warehouses
{
    public interface IWarehouseService
    {
        IEnumerable<Warehouse> GetAllWarehouses();
        Warehouse? GetWarehouseById(int id);
        void AddWarehouse(Warehouse warehouse);
        void UpdateWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int id);
    }

    public class WarehouseService : IWarehouseService
    {
        private readonly CargoHubDbContext _dbContext;
        public WarehouseService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Warehouse> GetAllWarehouses()
        {
            if (_dbContext.Warehouses != null)
            {
                return _dbContext.Warehouses.ToList();
            }
            return new List<Warehouse>();
        }

        public Warehouse? GetWarehouseById(int id)
        {
            return _dbContext.Warehouses?.Find(id);
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            _dbContext.Warehouses?.Add(warehouse);
            _dbContext.SaveChanges();
        }


        public void UpdateWarehouse(Warehouse warehouse)
        {
            _dbContext.Warehouses?.Update(warehouse);
            _dbContext.SaveChanges();
        }

        public void DeleteWarehouse(int id)
        {
            var warehouse = _dbContext.Warehouses?.Find(id);
            if (warehouse != null)
            {
                _dbContext.Warehouses?.Remove(warehouse);
                _dbContext.SaveChanges();
            }
        }
    }
}
