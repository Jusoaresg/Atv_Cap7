using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Repositories.Interfaces
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
