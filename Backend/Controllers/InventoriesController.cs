using System.Collections.Generic;
using Backend.Features.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Inventories
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult GetAllInventories()
        {
            var inventory = _inventoryService.GetAllInventories();
            return Ok(inventory);
        }

        [HttpGet("{id}")]
        public IActionResult GetInventoryById(int id)
        {
            var inventory = _inventoryService.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        public IActionResult AddInventory(Inventory inventory)
        {
            _inventoryService.AddInventory(inventory);
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.Id }, inventory);
        }
    }
}
