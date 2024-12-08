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

        [HttpGet("{id:int}")]
        public IActionResult GetItemLineById(int id)
        {
            var line = _service.GetItemLineById(id);
            return line is not null ? Ok(line) : NotFound();
        }

        [HttpPost]
        public IActionResult AddItemLine([FromBody] ItemLine itemLine)
        {
            _service.AddItemLine(itemLine);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItemLine(int id)
        {
            _service.DeleteItemLine(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateItemLine(int id, [FromBody] ItemLine itemLine)
        {
            _service.UpdateItemLine(id, itemLine);
            return NoContent();
        }
    }
}
