using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;
using Atv_Cap7WebAPI.Helpers;

namespace Atv_Cap7WebAPI.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> ListarTodasAsync()
        {
            return await _context.Empresas
                .Include(e => e.Vagas)
                .Include(e => e.ProgramasDiversidade)
                .ToListAsync();
        }

        public async Task<Empresa?> BuscarPorIdAsync(int id)
        {
            return await _context.Empresas
                .Include(e => e.Vagas)
                .Include(e => e.ProgramasDiversidade)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AdicionarAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var empresa = await BuscarPorIdAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Empresa>> GetEmpresasAsync(PaginationParameters pagination)
        {
            return await _context.Empresas
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
    }
}

