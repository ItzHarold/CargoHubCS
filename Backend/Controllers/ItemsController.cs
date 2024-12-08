using Backend.Features.Items;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Items
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemsController(IItemService service)
        {
            _service = service;
        }

        [HttpPost(Name = "AddItem")]
        public IActionResult AddItem([FromBody] Item item)
        {
            _service.AddItem(item);
            return Ok();
        }

        [HttpGet("{uid}", Name = "GetItemById")]
        public IActionResult GetItemById(string uid)
        {
            var item = _service.GetItemById(uid);
            return item is not null ? Ok(item) : NotFound();
        }

        [HttpGet(Name = "GetAllItems")]
        public IActionResult GetAllItems()
        {
            return Ok(_service.GetAllItems());
        }

        [HttpDelete("{uid}", Name = "DeleteItem")]
        public IActionResult DeleteItem(string uid)
        {
            _service.DeleteItem(uid);
            return NoContent();
        }
    }
}
