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
            supplier.CreatedAt = DateTime.Now;
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
            supplier.UpdatedAt = DateTime.Now;
            _dbContext.Suppliers?.Update(supplier);
            _dbContext.SaveChanges();
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
