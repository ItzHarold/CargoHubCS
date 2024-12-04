using System.Collections.Generic;
using Backend.Features.ItemGroups;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.ItemGroupsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemGroupsController : ControllerBase
    {
        private readonly IItemGroupService _itemGroupService;

        public ItemGroupsController(IItemGroupService itemGroupService)
        {
            _itemGroupService = itemGroupService;
        }

        [HttpGet]
        public IActionResult GetAllItemGroups()
        {
            var itemGroups = _itemGroupService.GetAllItemGroups();
            return Ok(itemGroups);
        }
    }
}
