using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;
using Atv_Cap7WebAPI.Helpers;

namespace Atv_Cap7WebAPI.Repository
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

        public async Task AdicionarAsync(InscricaoCreateDTO inscricaoDTO)
        {
            Inscricao inscricao = new()
            {
                Id = inscricaoDTO.Id,
                DataInscricao = inscricaoDTO.DataInscricao,
                CandidatoId = inscricaoDTO.CandidatoId,
                VagaId = inscricaoDTO.VagaId,
                Status = inscricaoDTO.Status
            };

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

        public async Task<IEnumerable<Inscricao>> GetInscricoesAsync(PaginationParameters pagination)
        {
            return await _context.Inscricoes
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
    }
}
