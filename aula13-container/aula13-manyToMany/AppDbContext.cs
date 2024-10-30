using Microsoft.EntityFrameworkCore;

namespace aula13_MTMPostgreSQL
{
    public class AppDbContext : DbContext
    {
        // DbSets que representam as tabelas no banco de dados
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }

        // Configura a conexão com o banco de dados PostgreSQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração do PostgreSQL, observe a string de conexão
            optionsBuilder.UseNpgsql("Host=localhost;Database=ManyToManyDB;Username=postgres;Password=postgres");
        }

        // Configuração das tabelas e relacionamento Many-to-Many
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação Many-to-Many entre Pessoa e Habilidade
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Habilidades)
                .WithMany(h => h.Pessoas)
                .UsingEntity<Dictionary<string, object>>(
                    "PessoaHabilidade", // Nome da tabela intermediária
                    j => j.HasOne<Habilidade>().WithMany().HasForeignKey("HabilidadeId"),
                    j => j.HasOne<Pessoa>().WithMany().HasForeignKey("PessoaId"));
        }
    }
}
