using Atv_Cap7WebAPI.Models;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> ListarTodasAsync();
        Task<Empresa?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Empresa empresa);
        Task AtualizarAsync(Empresa empresa);
        Task RemoverAsync(int id);
    }
}
