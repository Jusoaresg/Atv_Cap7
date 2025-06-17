namespace Atv_Cap7WebAPI.Models.DTOs;

public class AvaliacaoCreateDTO
{
    public int Id { get; set; }
    public int CandidatoId { get; set; }

    public int NotaTecnica { get; set; }  // 0 a 10
    public int NotaComportamental { get; set; }  // 0 a 10
    public string Comentario { get; set; } = string.Empty;
    public DateTime DataAvaliacao { get; set; }
}
