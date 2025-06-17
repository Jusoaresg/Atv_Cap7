using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;

namespace Atv_Cap7WebAPI.Repository
{
    public class ProgramaDiversidadeRepository : IProgramaDiversidadeRepository
    {
        private readonly AppDbContext _context;

        public ProgramaDiversidadeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramaDiversidade>> ListarTodosAsync()
        {
            return await _context.ProgramasDiversidade
                .Include(p => p.Empresas)
                .Include(p => p.Vagas)
                .ToListAsync();
        }

        public async Task<ProgramaDiversidade?> BuscarPorIdAsync(int id)
        {
            return await _context.ProgramasDiversidade
                .Include(p => p.Empresas)
                .Include(p => p.Vagas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(ProgramaDiversidade programa)
        {
            _context.ProgramasDiversidade.Add(programa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(ProgramaDiversidade programa)
        {
            _context.ProgramasDiversidade.Update(programa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var programa = await BuscarPorIdAsync(id);
            if (programa != null)
            {
                _context.ProgramasDiversidade.Remove(programa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
