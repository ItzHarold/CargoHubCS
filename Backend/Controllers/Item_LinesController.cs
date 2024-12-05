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

        [HttpGet("{uid}")]
        public IActionResult GetItemLineById(string uid)
        {
            var line = _service.GetItemLineById(uid);
            return line is not null ? Ok(line) : NotFound();
        }

        [HttpPost]
        public IActionResult AddItemLine([FromBody] ItemLine itemLine)
        {
            _service.AddItemLine(itemLine);
            return Ok();
        }

        [HttpDelete("{uid}")]
        public IActionResult DeleteItemLine(string uid)
        {
            _service.DeleteItemLine(uid);
            return NoContent();
        }

        [HttpPut("{uid}")]
        public IActionResult UpdateItemLine(string uid, [FromBody] ItemLine itemLine)
        {
            _service.UpdateItemLine(uid, itemLine);
            return NoContent();
        }
    }
}
