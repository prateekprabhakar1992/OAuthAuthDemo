using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class TestController : ControllerBase
{
    [HttpGet("data")]
    public IActionResult GetData()
    {
        return Ok(new { Message = "Hello, world!" });
    }
}