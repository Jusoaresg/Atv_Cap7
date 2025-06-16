using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao?> BuscarPorCandidatoIdAsync(int candidatoId);
        Task AdicionarOuAtualizarAsync(Avaliacao avaliacao);
        Task RemoverAsync(int candidatoId);
    }
}
