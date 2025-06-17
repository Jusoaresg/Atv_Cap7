using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;

namespace Atv_Cap7WebAPI.Repository
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly AppDbContext _context;

        public CandidatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidato>> ListarTodosAsync()
        {
            return await _context.Candidatos
                .Include(c => c.Avaliacao)
                .Include(c => c.Inscricoes)
                .ToListAsync();
        }

        public async Task<Candidato?> BuscarPorIdAsync(int id)
        {
            return await _context.Candidatos
                .Include(c => c.Avaliacao)
                .Include(c => c.Inscricoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AdicionarAsync(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Candidato candidato)
        {
            _context.Candidatos.Update(candidato);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var candidato = await BuscarPorIdAsync(id);
            if (candidato != null)
            {
                _context.Candidatos.Remove(candidato);
                await _context.SaveChangesAsync();
            }
        }
    }
}
