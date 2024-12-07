using System.Collections.Generic;
using Backend.Features.ItemTypes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.ItemTypes
{
    [ApiController]
    [Route("api/item_types")]
    public class ItemTypesController : ControllerBase
    {
        private IItemTypeService _itemTypeService;

        public ItemTypesController(IItemTypeService itemTypeService)
        {
            _itemTypeService = itemTypeService;
        }

        [HttpGet]
        public IActionResult GetAllItemTypes()
        {
            return Ok(_itemTypeService.GetAllItemTypes());
        }

        [HttpPost]
        public IActionResult AddItemType([FromBody] ItemType itemType)
        {
            _itemTypeService.AddItemType(itemType);
            return Ok(itemType);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItemType(int id)
        {
            _itemTypeService.DeleteItemType(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateItemType(int id, [FromBody] ItemType itemType)
        {
            _itemTypeService.UpdateItemType(id, itemType);
            return NoContent();
        }
    }
}
