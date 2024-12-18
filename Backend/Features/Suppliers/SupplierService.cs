using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Backend.Infrastructure.Database;

namespace Backend.Features.Suppliers
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier? GetSupplierById(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly CargoHubDbContext _dbContext;

        public SupplierService(CargoHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSupplier(Supplier supplier)
        {
            _dbContext.Suppliers?.Add(supplier);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            if (_dbContext.Suppliers != null)
            {
                return _dbContext.Suppliers.ToList();
            }
            return new List<Supplier>();
        }

        public Supplier? GetSupplierById(int id)
        {
            return _dbContext.Suppliers?.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (_dbContext.Suppliers != null)
            {
                var existingSupplier = _dbContext.Suppliers
                    .FirstOrDefault(s => s.Id == supplier.Id);

                if (existingSupplier != null)
                {
                    _dbContext.Entry(existingSupplier).CurrentValues.SetValues(supplier);
                }
            }
        }

        public void DeleteSupplier(int id)
        {
            if (_dbContext.Suppliers != null)
            {
                var supplier = _dbContext.Suppliers.FirstOrDefault(s => s.Id == id);
                if (supplier != null)
                {
                    _dbContext.Suppliers.Remove(supplier);
                    _dbContext.SaveChanges();
                }
            }
        }

    }
}
