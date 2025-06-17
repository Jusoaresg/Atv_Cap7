namespace Atv_Cap7WebAPI.Models;

using System.Text.Json.Serialization;

public class Inscricao
{
    public int Id { get; set; }
    public DateTime DataInscricao { get; set; }

    // Relacionamento com Candidato
    public int CandidatoId { get; set; }
    [JsonIgnore]
    public Candidato? Candidato { get; set; }

    // Relacionamento com Vaga

    public int VagaId { get; set; }
    [JsonIgnore]
    public Vaga? Vaga { get; set; }

    // Opcional: status ou pontuação
    public string Status { get; set; } = "Pendente"; // ou "Avaliado", "Aprovado", etc.
}
