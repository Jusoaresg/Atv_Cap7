using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Atv_Cap7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoRepository _avaliacaoRepository;

    public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
    {
        _avaliacaoRepository = avaliacaoRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var avaliacao = await _avaliacaoRepository.BuscarPorCandidatoIdAsync(id);
        if (avaliacao == null)
        {
            return NotFound();
        }
        return Ok(avaliacao);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AvaliacaoCreateDTO avaliacao)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _avaliacaoRepository.AdicionarOuAtualizarAsync(avaliacao);
        return CreatedAtAction(nameof(Get), new { id = avaliacao.Id }, avaliacao);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _avaliacaoRepository.RemoverAsync(id);
        return Ok(id);
    }
}
