using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
        private readonly List<Supplier> _suppliers = new();

        public void AddSupplier(Supplier supplier)
        {
            _suppliers.Add(supplier);
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _suppliers;
        }

        public Supplier? GetSupplierById(int id)
        {
            return _suppliers.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var existingSupplier = _suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            if (existingSupplier == null)
            {
                return;
            }

            existingSupplier.Code = supplier.Code;
            existingSupplier.Name = supplier.Name;
            existingSupplier.Address = supplier.Address;
            existingSupplier.AddressExtra = supplier.AddressExtra;
            existingSupplier.City = supplier.City;
            existingSupplier.ZipCode = supplier.ZipCode;
            existingSupplier.Province = supplier.Province;
            existingSupplier.Country = supplier.Country;
            existingSupplier.ContactName = supplier.ContactName;
            existingSupplier.PhoneNumber = supplier.PhoneNumber;
            existingSupplier.Reference = supplier.Reference;
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                _suppliers.Remove(supplier);
            }
        }

    }
}
