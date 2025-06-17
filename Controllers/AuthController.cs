namespace Atv_Cap7WebAPI.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Atv_Cap7WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLogin user)
    {
        if (user.Nome == "admin" && user.Senha == "admin")
        {
            var token = GenerateJwt(user.Nome);
            return Ok(new { token });
        }
        return Unauthorized();
    }


    private string GenerateJwt(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SUPER_SECRETO_E_NINGUEM_VAI_DESCOBRIR"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: "123@gmail.com", audience: "123@gmail.com", claims: claims, expires: DateTime.Now.AddMinutes(1), signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

