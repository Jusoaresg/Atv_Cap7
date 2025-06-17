using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Atv_Cap7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaController(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var empresas = await _empresaRepository.BuscarPorIdAsync(id);
        if (empresas == null)
        {
            return NotFound();
        }
        return Ok(empresas);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var empresas = await _empresaRepository.ListarTodasAsync();
        return Ok(empresas);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmpresaCreateDTO empresa)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _empresaRepository.AdicionarAsync(empresa);
        return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _empresaRepository.RemoverAsync(id);
        return Ok(id);
    }
}
