namespace Atv_Cap7WebAPI.Models.DTOs;

public class VagaCreateDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public bool Aberta { get; set; } = true;
    public DateTime DataPublicacao { get; set; }

    // Chave estrangeira para Empresa
    public int EmpresaId { get; set; }
}
