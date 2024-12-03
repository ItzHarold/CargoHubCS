using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
        private readonly List<Warehouse> _warehouses = new();

        public IEnumerable<Warehouse> GetAllWarehouses()
        {
            return _warehouses;
        }

        public Warehouse? GetWarehouseById(int id)
        {
            return _warehouses.FirstOrDefault(x => x.Id == id);
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            _warehouses.Add(warehouse);
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            var existingWarehouse = _warehouses.FirstOrDefault(x => x.Id == warehouse.Id);
            if (existingWarehouse == null)
            {
                return;
            }

            existingWarehouse.Id = warehouse.Id;
            existingWarehouse.Code = warehouse.Code;
            existingWarehouse.Name = warehouse.Name;
            existingWarehouse.Address = warehouse.Address;
            existingWarehouse.Zip = warehouse.Zip;
            existingWarehouse.City = warehouse.City;
            existingWarehouse.Province = warehouse.Province;
            existingWarehouse.Country = warehouse.Country;
            existingWarehouse.Contacts = warehouse.Contacts;
        }

        public void DeleteWarehouse(int id)
        {
            var warehouse = _warehouses.FirstOrDefault(x => x.Id == id);
            if (warehouse == null)
            {
                return;
            }

            _warehouses.Remove(warehouse);
        }
    }
}
