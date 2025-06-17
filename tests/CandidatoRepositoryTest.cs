namespace Atv_Cap7WebAPI.Tests;

using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Repository.Repositories;
using Xunit;

public class CandidatoRepositoryTest
{
    private readonly ICandidatoRepository _candidatoRepository;

    public CandidatoRepositoryTest(ICandidatoRepository candidatoRepository)
    {
        _candidatoRepository = candidatoRepository;
    }

    [Fact]
    public async Task ShouldInsertCandidate()
    {
        var candidato = new CandidatoCreateDTO
        {
            Id = 1,
            Nome = "João",
            Email = "joao@email.com",
        };

        await _candidatoRepository.AdicionarAsync(candidato);

        var resultCandidato = await _candidatoRepository.BuscarPorIdAsync(candidato.Id);
        Assert.NotNull(resultCandidato);
        Assert.Equal(candidato.Nome, resultCandidato.Nome);
        Assert.Equal(candidato.Email, resultCandidato.Email);

        await _candidatoRepository.RemoverAsync(candidato.Id);
    }

    [Fact]
    public async Task ShouldUpdateCandidate()
    {
        var candidato = new CandidatoCreateDTO
        {
            Id = 1,
            Nome = "João",
            Email = "joao@email.com",
        };

        await _candidatoRepository.AdicionarAsync(candidato);

        var candidatoUpdated = new Candidato
        {
            Id = candidato.Id,
            Nome = "João Pedro",
            Email = "joaoPedro@email.com",
        };

        await _candidatoRepository.AtualizarAsync(candidatoUpdated);

        var resultCandidato = await _candidatoRepository.BuscarPorIdAsync(candidato.Id);
        Assert.NotNull(resultCandidato);
        Assert.Equal(candidatoUpdated.Nome, resultCandidato.Nome);
        Assert.Equal(candidatoUpdated.Email, resultCandidato.Email);

        await _candidatoRepository.RemoverAsync(candidato.Id);
    }

    [Fact]
    public async Task ShouldDeleteCandidate()
    {
        var candidato = new CandidatoCreateDTO
        {
            Id = 1,
            Nome = "João",
            Email = "joao@email.com",
        };

        await _candidatoRepository.AdicionarAsync(candidato);
        await _candidatoRepository.RemoverAsync(candidato.Id);
        var resultCandidato = await _candidatoRepository.BuscarPorIdAsync(candidato.Id);

        Assert.Null(resultCandidato);
    }
}
