using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Repositories.Interfaces
{
    public interface IVagaRepository
    {
        Task<IEnumerable<Vaga>> ListarTodasAsync(int page, int pageSize);
        Task<Vaga?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Vaga vaga);
        Task AtualizarAsync(Vaga vaga);
        Task RemoverAsync(int id);
        Task<int> ContarTotalAsync();
    }
}
