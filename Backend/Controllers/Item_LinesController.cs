using System.Collections.Generic;
using Backend.Features.ItemLines;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.ItemLines
{
    [ApiController]
    [Route("api/item_lines")]
    public class ItemLinesController : ControllerBase
    {
        private IItemLineService _service { get; set; }

        public ItemLinesController(IItemLineService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetItemLines()
        {
            return Ok(_service.GetAllItemLines());
        }

        [HttpPost]
        public IActionResult AddItemLine([FromBody] ItemLine itemLine)
        {
            _service.AddItemLine(itemLine);
            return Ok();
        }
    }
}
