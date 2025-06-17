namespace Atv_Cap7WebAPI.Controllers;

using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VagaController : ControllerBase
{
    private readonly IVagaRepository _vagaRepository;
    public VagaController(IVagaRepository vagaRepository)
    {
        _vagaRepository = vagaRepository;
    }

    [HttpGet("{page}")]
    public async Task<IActionResult> List(int page)
    {
        var vagas = await _vagaRepository.ListarTodasAsync(page, 10);
        return Ok(vagas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var vaga = await _vagaRepository.BuscarPorIdAsync(id);
        if (vaga == null)
        {
            return BadRequest();
        }
        return Ok(vaga);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VagaCreateDTO vaga)
    {
        await _vagaRepository.AdicionarAsync(vaga);
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Get), new { id = vaga.Id }, vaga);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Vaga vaga)
    {
        await _vagaRepository.AtualizarAsync(vaga);
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return Ok(vaga);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _vagaRepository.RemoverAsync(id);
        return Ok(id);
    }

    [HttpGet("vagas/{vagaId}/inscricoes")]
    public async Task<IActionResult> GetInscricoes(int vagaId)
    {
        var inscricoes = await _vagaRepository.ContarTotalAsync(vagaId);
        return Ok(inscricoes);
    }
}
