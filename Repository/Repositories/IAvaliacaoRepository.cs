using Atv_Cap7WebAPI.Models;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao?> BuscarPorCandidatoIdAsync(int candidatoId);
        Task AdicionarOuAtualizarAsync(Avaliacao avaliacao);
        Task RemoverAsync(int candidatoId);
    }
}
