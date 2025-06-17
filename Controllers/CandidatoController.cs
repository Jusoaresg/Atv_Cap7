namespace Atv_Cap7WebAPI.Controllers;

using Atv_Cap7WebAPI.Helpers;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CandidatoController : ControllerBase
{
    private ICandidatoRepository _candidatoRepository;

    public CandidatoController(ICandidatoRepository candidatoRepository)
    {
        _candidatoRepository = candidatoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCandidatos([FromQuery] PaginationParameters paginationParams)
    {
        var candidatos = await _candidatoRepository.GetCandidatosAsync(paginationParams);
        return Ok(candidatos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var candidato = await _candidatoRepository.BuscarPorIdAsync(id);
        if (candidato != null)
        {
            return BadRequest();
        }
        return Ok(candidato);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Candidato candidato)
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
}
