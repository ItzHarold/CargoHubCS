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
    }
}
