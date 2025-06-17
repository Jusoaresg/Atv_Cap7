using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Atv_Cap7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InscricaoController : ControllerBase
{
    private readonly IInscricaoRepository _inscricaoRepository;

    public InscricaoController(IInscricaoRepository inscricaoRepository)
    {
        _inscricaoRepository = inscricaoRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var inscricao = await _inscricaoRepository.BuscarPorIdAsync(id);
        if (inscricao == null)
        {
            return NotFound();
        }
        return Ok(inscricao);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var inscricaos = await _inscricaoRepository.ListarTodasAsync();
        return Ok(inscricaos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InscricaoCreateDTO inscricao)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _inscricaoRepository.AdicionarAsync(inscricao);
        return CreatedAtAction(nameof(Get), new { id = inscricao.Id }, inscricao);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _inscricaoRepository.RemoverAsync(id);
        return Ok(id);
    }
}
