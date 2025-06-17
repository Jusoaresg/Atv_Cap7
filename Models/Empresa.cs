namespace Atv_Cap7WebAPI.Models;

public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Setor { get; set; } = string.Empty;

    // Relacionamento 1:N (Empresa -> Vagas)
    public ICollection<Vaga> Vagas { get; set; } = new List<Vaga>();
    public ICollection<ProgramaDiversidade> ProgramasDiversidade { get; set; } = new List<ProgramaDiversidade>();

}
