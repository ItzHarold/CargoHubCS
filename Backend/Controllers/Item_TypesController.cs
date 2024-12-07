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
    }
}
