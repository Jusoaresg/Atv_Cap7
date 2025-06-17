using Microsoft.EntityFrameworkCore;
using Atv_Cap7WebAPI.Data.Context;
using Atv_Cap7WebAPI.Models;
using Atv_Cap7WebAPI.Repository.Repositories;
using Atv_Cap7WebAPI.Models.DTOs;

namespace Atv_Cap7WebAPI.Repository
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

        public async Task AdicionarAsync(VagaCreateDTO vagaDTO)
        {
            Vaga vaga = new()
            {
                Id = vagaDTO.Id,
                Titulo = vagaDTO.Titulo,
                Descricao = vagaDTO.Descricao,
                Local = vagaDTO.Local,
                Aberta = vagaDTO.Aberta,
                EmpresaId = vagaDTO.EmpresaId
            };
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

        public async Task<int> ContarTotalAsync(int id)
        {
            Vaga vaga = await _context.Vagas.Include(v => v.Inscricoes).FirstOrDefaultAsync(v => v.Id == id);

            if (vaga == null) return 0;
            if (vaga.Inscricoes == null) return 0;

            return vaga.Inscricoes.Count;
        }
    }
}
