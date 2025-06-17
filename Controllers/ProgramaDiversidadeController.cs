using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Atv_Cap7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgramaDiversidadeController : ControllerBase
{

    IProgramaDiversidadeRepository _programaDiversidadeRepository;
    public ProgramaDiversidadeController(IProgramaDiversidadeRepository programaDiversidadeRepository)
    {
        _programaDiversidadeRepository = programaDiversidadeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        await _programaDiversidadeRepository.ListarTodosAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var programaDiversidade = await _programaDiversidadeRepository.BuscarPorIdAsync(id);
        if (programaDiversidade == null)
        {
            return NotFound();
        }
        return Ok(programaDiversidade);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProgramaDiversidade programaDiversidade)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _programaDiversidadeRepository.AdicionarAsync(programaDiversidade);
        return CreatedAtAction(nameof(Get), new { id = programaDiversidade.Id }, programaDiversidade);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProgramaDiversidade programaDiversidade)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _programaDiversidadeRepository.AtualizarAsync(programaDiversidade);
        return Ok(programaDiversidade);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _programaDiversidadeRepository.RemoverAsync(id);
        return Ok(id);
    }
}
