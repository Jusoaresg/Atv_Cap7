namespace Atv_Cap7WebAPI.Models;

using System.Text.Json.Serialization;

public class Avaliacao
{
    public int Id { get; set; }
    public int CandidatoId { get; set; }
    [JsonIgnore]
    public Candidato? Candidato { get; set; }

    public int NotaTecnica { get; set; }  // 0 a 10
    public int NotaComportamental { get; set; }  // 0 a 10
    public string Comentario { get; set; } = string.Empty;
    public DateTime DataAvaliacao { get; set; }
}
