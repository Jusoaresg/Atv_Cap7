using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;
using Atv_Cap7WebAPI.Models.DTOs;
using Atv_Cap7WebAPI.Helpers;

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

        public async Task AdicionarOuAtualizarAsync(AvaliacaoCreateDTO avaliacaoDTO)
        {
            Avaliacao avaliacao = new()
            {
                CandidatoId = avaliacaoDTO.CandidatoId,
                NotaTecnica = avaliacaoDTO.NotaTecnica,
                NotaComportamental = avaliacaoDTO.NotaComportamental,
                Comentario = avaliacaoDTO.Comentario,
                DataAvaliacao = avaliacaoDTO.DataAvaliacao
            };

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

        public async Task<IEnumerable<Avaliacao>> GetAvaliacoesAsync(PaginationParameters pagination)
        {
            return await _context.Avaliacoes
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
    }
}
