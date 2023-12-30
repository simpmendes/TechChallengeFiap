using TechChallengeFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TechChallengeFiap.Infra.Data.Context
{
    public partial class ConsultaAcoesDBContext : DbContext
    {
        public virtual DbSet<ConsultaAcoes> ConsultaAcoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public ConsultaAcoesDBContext(DbContextOptions<ConsultaAcoesDBContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade ConsultaAcoes
            modelBuilder.Entity<ConsultaAcoes>(entity =>
            {
                entity.Property(e => e.Symbol)
                      .IsRequired();

                entity.Property(e => e.DataConsulta)
                      .IsRequired();

                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.ConsultaAcoes)
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade); // Exemplo de deleção em cascata
            });

            // Configuração da entidade Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.NomeUsuario)
                      .IsRequired();

                entity.Property(e => e.Senha)
                      .IsRequired();

                entity.Property(e => e.Permissao)
                      .IsRequired();

                entity.HasMany(u => u.ConsultaAcoes)
                      .WithOne(ca => ca.Usuario)
                      .HasForeignKey(ca => ca.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade); // Exemplo de deleção em cascata
            });
        }

    }
}
