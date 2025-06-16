using Microsoft.EntityFrameworkCore;
using RecrutamentoDiversidade.Data;
using RecrutamentoDiversidade.Models;
using RecrutamentoDiversidade.Repositories.Interfaces;

namespace RecrutamentoDiversidade.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly AppDbContext _context;

        public VagaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaga>> ListarTodasAsync(int page, int pageSize)
        {
            return await _context.Vagas
                .Include(v => v.Empresa)
                .Include(v => v.ProgramasDiversidade)
                .OrderByDescending(v => v.DataPublicacao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Vaga?> BuscarPorIdAsync(int id)
        {
            return await _context.Vagas
                .Include(v => v.Empresa)
                .Include(v => v.ProgramasDiversidade)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AdicionarAsync(Vaga vaga)
        {
            _context.Vagas.Add(vaga);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Vaga vaga)
        {
            _context.Vagas.Update(vaga);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var vaga = await BuscarPorIdAsync(id);
            if (vaga != null)
            {
                _context.Vagas.Remove(vaga);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarTotalAsync()
        {
            return await _context.Vagas.CountAsync();
        }
    }
}
