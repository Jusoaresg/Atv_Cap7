using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Repositories.Interfaces
{
    public interface IProgramaDiversidadeRepository
    {
        Task<IEnumerable<ProgramaDiversidade>> ListarTodosAsync();
        Task<ProgramaDiversidade?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(ProgramaDiversidade programa);
        Task AtualizarAsync(ProgramaDiversidade programa);
        Task RemoverAsync(int id);
    }
}
