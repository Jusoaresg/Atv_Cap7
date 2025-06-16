namespace RecrutamentoDiversidade.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Avaliacao Avaliacao { get; set; }
        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}

