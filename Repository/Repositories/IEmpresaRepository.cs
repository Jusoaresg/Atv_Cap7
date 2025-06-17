using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Helpers;
using Atv_Cap7WebAPI.Models;

namespace Atv_Cap7WebAPI.Repository.Repositories
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> ListarTodasAsync();
        Task<Empresa?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(EmpresaCreateDTO empresa);
        Task AtualizarAsync(Empresa empresa);
        Task RemoverAsync(int id);
        Task<IEnumerable<Empresa>> GetEmpresasAsync(PaginationParameters pagination);
    }
}
