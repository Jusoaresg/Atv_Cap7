using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Helpers;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao?> BuscarPorCandidatoIdAsync(int candidatoId);
        Task AdicionarOuAtualizarAsync(Avaliacao avaliacao);
        Task RemoverAsync(int candidatoId);
        Task<IEnumerable<Avaliacao>> GetAvaliacoesAsync(PaginationParameters pagination);
    }
}
