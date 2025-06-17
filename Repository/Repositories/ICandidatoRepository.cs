using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Helpers;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidato>> ListarTodosAsync();
        Task<Candidato?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(CandidatoCreateDTO candidato);
        Task AtualizarAsync(Candidato candidato);
        Task RemoverAsync(int id);
        Task<IEnumerable<Candidato>> GetCandidatosAsync(PaginationParameters pagination);
    }
}
