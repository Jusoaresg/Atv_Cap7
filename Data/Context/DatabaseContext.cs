using Microsoft.EntityFrameworkCore;
using RecrutamentoDiversidade.Models;

namespace RecrutamentoDiversidade.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<ProgramaDiversidade> ProgramasDiversidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("FIAP");

            // === Empresa -> Vaga (1:N)
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Vagas)
                .WithOne(v => v.Empresa)
                .HasForeignKey(v => v.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Candidato -> Avaliacao (1:1)
            modelBuilder.Entity<Candidato>()
                .HasOne(c => c.Avaliacao)
                .WithOne(a => a.Candidato)
                .HasForeignKey<Avaliacao>(a => a.CandidatoId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Candidato -> Inscricao (1:N)
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.Inscricoes)
                .WithOne(i => i.Candidato)
                .HasForeignKey(i => i.CandidatoId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Vaga -> Inscricao (1:N)
            modelBuilder.Entity<Vaga>()
                .HasMany(v => v.Inscricoes)
                .WithOne(i => i.Vaga)
                .HasForeignKey(i => i.VagaId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Empresa <-> ProgramaDiversidade (N:M)
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.ProgramasDiversidade)
                .WithMany(p => p.Empresas)
                .UsingEntity(j => j.ToTable("Empresa_ProgramaDiversidade"));

            // === Vaga <-> ProgramaDiversidade (N:M)
            modelBuilder.Entity<Vaga>()
                .HasMany(v => v.ProgramasDiversidade)
                .WithMany(p => p.Vagas)
                .UsingEntity(j => j.ToTable("Vaga_ProgramaDiversidade"));
        }
    }
}
