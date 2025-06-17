using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;

namespace Atv_Cap7WebAPI.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public AvaliacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Avaliacao?> BuscarPorCandidatoIdAsync(int candidatoId)
        {
            return await _context.Avaliacoes
                .Include(a => a.Candidato)
                .FirstOrDefaultAsync(a => a.CandidatoId == candidatoId);
        }

        public async Task AdicionarOuAtualizarAsync(Avaliacao avaliacao)
        {
            var existente = await BuscarPorCandidatoIdAsync(avaliacao.CandidatoId);
            if (existente == null)
                _context.Avaliacoes.Add(avaliacao);
            else
                _context.Avaliacoes.Update(avaliacao);

            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int candidatoId)
        {
            var avaliacao = await BuscarPorCandidatoIdAsync(candidatoId);
            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
