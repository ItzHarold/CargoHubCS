using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend.Features.Suppliers;

namespace Backend.Controllers.Suppliers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return new List<Supplier>();
        }
    }
}
