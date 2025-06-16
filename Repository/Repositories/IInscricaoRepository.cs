using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Repositories.Interfaces
{
    public interface IInscricaoRepository
    {
        Task<IEnumerable<Inscricao>> ListarTodasAsync();
        Task<Inscricao?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Inscricao inscricao);
        Task RemoverAsync(int id);
    }
}
