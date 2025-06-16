namespace RecrutamentoDiversidade.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public bool Aberta { get; set; } = true;
        public DateTime DataPublicacao { get; set; }

        // Chave estrangeira para Empresa
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        // Relacionamento 1:N (Vaga -> Inscrições)
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
        public ICollection<ProgramaDiversidade> ProgramasDiversidade { get; set; } = new List<ProgramaDiversidade>();

    }
}
