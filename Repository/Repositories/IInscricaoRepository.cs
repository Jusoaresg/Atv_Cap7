using Atv_Cap7WebAPI.Models;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IInscricaoRepository
    {
        Task<IEnumerable<Inscricao>> ListarTodasAsync();
        Task<Inscricao?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(InscricaoCreateDTO inscricao);
        Task RemoverAsync(int id);
    }
}
