namespace Atv_Cap7WebAPI.Models.DTOs;

public class EmpresaCreateDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Setor { get; set; } = string.Empty;
}
