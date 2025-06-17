using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Models.DTOs;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao?> BuscarPorCandidatoIdAsync(int candidatoId);
        Task AdicionarOuAtualizarAsync(AvaliacaoCreateDTO avaliacao);
        Task RemoverAsync(int candidatoId);
    }
}
