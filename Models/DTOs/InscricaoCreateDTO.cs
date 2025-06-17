namespace Atv_Cap7WebAPI.Models;

public class InscricaoCreateDTO
{
    public int Id { get; set; }
    public DateTime DataInscricao { get; set; }

    // Relacionamento com Candidato
    public int CandidatoId { get; set; }

    // Relacionamento com Vaga
    public int VagaId { get; set; }

    // Opcional: status ou pontuação
    public string Status { get; set; } = "Pendente"; // ou "Avaliado", "Aprovado", etc.
}
