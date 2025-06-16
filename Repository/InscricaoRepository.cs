using Microsoft.EntityFrameworkCore;
using RecrutamentoDiversidade.Data;
using RecrutamentoDiversidade.Models;
using RecrutamentoDiversidade.Repositories.Interfaces;

namespace RecrutamentoDiversidade.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {
        private readonly AppDbContext _context;

        public InscricaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inscricao>> ListarTodasAsync()
        {
            return await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.Vaga)
                .ToListAsync();
        }

        public async Task<Inscricao?> BuscarPorIdAsync(int id)
        {
            return await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.Vaga)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AdicionarAsync(Inscricao inscricao)
        {
            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var inscricao = await BuscarPorIdAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
