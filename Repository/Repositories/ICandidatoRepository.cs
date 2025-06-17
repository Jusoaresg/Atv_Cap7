using Atv_Cap7WebAPI.Models;
<<<<<<< HEAD
using Atv_Cap7WebAPI.Models.DTOs;
=======
using Atv_Cap7WebAPI.Helpers;
>>>>>>> 6779efc27d30e93ff56141f8cc4bace050181440

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
