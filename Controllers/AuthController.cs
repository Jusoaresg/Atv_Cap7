namespace Atv_Cap7WebAPI.Controllers;

using Atv_Cap7WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLogin user)
    {
        return Ok("login");
    }
}
