namespace Atv_Cap7WebAPI.Models;

public class ProgramaDiversidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    // N:M com Empresa
    public ICollection<Empresa>? Empresas { get; set; } = new List<Empresa>();

    // N:M com Vaga
    public ICollection<Vaga>? Vagas { get; set; } = new List<Vaga>();
}
