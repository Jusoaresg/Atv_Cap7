using Atv_Cap7WebAPI.Helpers;
using Atv_Cap7WebAPI.Models;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IProgramaDiversidadeRepository
    {
        Task<IEnumerable<ProgramaDiversidade>> ListarTodosAsync();
        Task<ProgramaDiversidade?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(ProgramaDiversidade programa);
        Task AtualizarAsync(ProgramaDiversidade programa);
        Task RemoverAsync(int id);
        Task<IEnumerable<ProgramaDiversidade>> GetProgramasAsync(PaginationParameters pagination);
    }
}
