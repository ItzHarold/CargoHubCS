using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [ProducesResponseType(statusCode: 200)]
    [HttpGet(Name = "HealthCheck")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
}