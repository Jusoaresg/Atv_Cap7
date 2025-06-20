namespace Atv_Cap7WebAPI.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using global::Atv_Cap7WebAPI.Models.DTOs;
using global::Atv_Cap7WebAPI.Models;
using global::Atv_Cap7WebAPI.Repository.Repositories;
using global::Atv_Cap7WebAPI.Helpers;

[ApiController]
[Route("api/[controller]")]
public class CandidatoController : ControllerBase
{
    private readonly ICandidatoRepository _candidatoRepository;

    public CandidatoController(ICandidatoRepository candidatoRepository)
    {
        _candidatoRepository = candidatoRepository;
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetCandidatos([FromQuery] PaginationParameters paginationParams)
    {
        var candidatos = await _candidatoRepository.GetCandidatosAsync(paginationParams);
        return Ok(candidatos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var candidato = await _candidatoRepository.BuscarPorIdAsync(id);
        if (candidato == null)
        {
            return BadRequest();
        }
        return Ok(candidato);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CandidatoCreateDTO candidato)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _candidatoRepository.AdicionarAsync(candidato);
        return CreatedAtAction(nameof(Get), new { id = candidato.Id }, candidato);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var candidatos = await _candidatoRepository.ListarTodosAsync();
        return Ok(candidatos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _candidatoRepository.RemoverAsync(id);
        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Candidato candidato)
    {
        await _candidatoRepository.AtualizarAsync(candidato);
        return Ok(candidato);
    }

}
