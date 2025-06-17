using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Models.DTOs;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IVagaRepository
    {
        Task<IEnumerable<Vaga>> ListarTodasAsync(int page, int pageSize);
        Task<Vaga?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(VagaCreateDTO vaga);
        Task AtualizarAsync(Vaga vaga);
        Task RemoverAsync(int id);
        Task<int> ContarTotalAsync(int id);
    }
}
