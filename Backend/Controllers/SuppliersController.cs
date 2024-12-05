using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend.Features.Suppliers;

namespace Backend.Controllers.Suppliers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _supplierService.GetAllSuppliers();
        }

        [HttpPost]
        public IActionResult AddSupplier([FromBody]Supplier supplier)
        {
            _supplierService.AddSupplier(supplier);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            var supplier = _supplierService.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody]Supplier supplier)
        {
            var existingSupplier = _supplierService.GetSupplierById(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }
            supplier.Id = id;
            _supplierService.UpdateSupplier(supplier);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            _supplierService.DeleteSupplier(id);
            return Ok();
        }
    }
}
