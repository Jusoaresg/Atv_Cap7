using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Repositories.Interfaces
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidato>> ListarTodosAsync();
        Task<Candidato?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Candidato candidato);
        Task AtualizarAsync(Candidato candidato);
        Task RemoverAsync(int id);
    }
}
