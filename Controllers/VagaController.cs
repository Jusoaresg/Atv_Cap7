namespace Atv_Cap7WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VagaController : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<IActionResult> Get()
    {
        return Ok("Get");
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return Ok("Create");
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        return Ok("List");
    }
}
