using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Suppliers
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
        // Supplier? GetSupplierById(int id);
        void AddSupplier(Supplier supplier);
        // void UpdateSupplier(Supplier supplier);
        // void DeleteSupplier(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly List<Supplier> _suppliers = new();

        public void AddSupplier(Supplier supplier)
        {
            _suppliers.Add(supplier);
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _suppliers;
        }

    }
}
