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

        [HttpGet("{id:int}")]
        public IActionResult GetItemTypeById(int id)
        {
            var itemType = _itemTypeService.GetItemTypeById(id);
            return itemType is not null ? Ok(itemType) : NotFound();
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
